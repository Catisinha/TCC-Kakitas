using System.Security.Claims;
using System.Text;
using MAContabilidade.Data;
using MAContabilidade.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.WebUtilities;

namespace MAContabilidade.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _contexto;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IEmailSender _emailSender;
    private readonly ILogger<UsuarioService> _logger;


    public UsuarioService(
        AppDbContext contexto,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        IUserStore<IdentityUser> userStore,
        IWebHostEnvironment hostEnvironment,
        IEmailSender emailSender,
        ILogger<UsuarioService> logger
    )
    {
        _contexto = contexto;
        _signInManager = signInManager;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _userStore = userStore;
        _emailStore = (IUserEmailStore<IdentityUser>)_userStore;
        _hostEnvironment = hostEnvironment;
        _emailSender = emailSender;
        _logger = logger;
    }

    public async Task<bool> ConfirmarEmail(string userId, string code)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return false;
        }
        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);
        return result.Succeeded;
    }

    public async Task<UsuarioVM> GetUsuarioLogado()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return null;
        }
        var userAccount = await _userManager.FindByEmailAsync(userId);
        var usuario = await _contexto.Usuarios.Where(uint => uint.UsuarioId == userId).SingleOrDefaultAsync();
        var perfis = string.Join(", ", await _userManager.GetRolesAsync(userAccount));
        var admin = await _userManager.IsInRoleAsync(userAccount, "Administrador");
        UsuarioVM usuarioVM = new()
        {
            UsuarioId = userId,
            Nome = usuario.Nome,
            DataNascimento = usuario.DataNascimento,
            Foto = usuario.Foto,
            Email = userAccount.Email,
            UserName = userAccount.UserName,
            Perfil = perfis,
            IsAdmin = admin
        };
        return usuarioVM;
    }

    public async Task<SignInResult> LoginUsuario(LoginVM login)
    {
        string userName = login.Email;
        if (Helper.IsValidEmail(login.Email))
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
                userName = user.UserName;
        }
        
        var result = await _signInManager.PasswordSignInAsync(
            userName, login.Senha, login.Lembrar, lockoutOnFailure: true
        );

        if (result.Succeeded)
            _logger.LogInformation($"Usuário {login.Email} acessou o sistema");
        if (result.IsLockedOut)
            _logger.LogWarning($"Usuário {login.Email} está bloqueado");

        return result;
    }

    public async Task LogoffUsuario()
    {
        _logger.LogInformation($"Usuário {ClaimTypes.Email} fez logoff");
        await _signInManager.SignOutAsync();
    }

    public async Task<List<string>> RegistrarUsuario(RegistroVM registro)
    {
        var user = Activator.CreateInstance<IdentityUser>();

        await _userStore.SetUserNameAsync(user, registro.Email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, registro.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, registro.Senha);

        if (result.Succeeded)
        {
            _logger.LogInformation($"Novo usuário registrado com o email {user.Email}.");

            var userId = await _userManager.GetUserIdAsync(user);
        }
    }
}