using System.ComponentModel.DataAnnotations;

namespace MAContabilidade.ViewModels;

public class LoginVM
{
    [Display(Name = "Email ou Nome de Usuário", Prompt = "Email ou Nome de Usuário")]
    [Required(ErrorMessage = "Por favor, infome seu email ou nome de usuário")]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    [Display(Name = "Senha de Acesso", Prompt = "Senha")]
    [Required(ErrorMessage = "Por favor, infome sua senha")]
    public string Senha { get; set; }

    [Display(Name = "Manter Conectado?")]
    public bool Lembrar { get; set; } = false;

    public string UrlRetorno { get; set; }
}