using MAContabilidade.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MAContabilidade.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate IdentityUser
        List<IdentityUser> users = new(){
            new IdentityUser(){
                Id = Guid.NewGuid().ToString(),
                Email = "ampmcontabilidade@outlook.com",
                NormalizedEmail = "AMPMCONTABILIDADE@OUTLOOK.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true,
            }
        };
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "@AMContabilidade123");
        }
        builder.Entity<IdentityUser>().HasData(users);

        List<Usuario> usuarios = new(){
            new Usuario(){
                UsuarioId = users[0].Id,
                Nome = "Monalisa Martins",
                DataNascimento = DateTime.Parse("21/07/1994"),
                Foto = "/img/usuarios/avatar.png"
            }
        };
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Popular Serviços
        List<Servico> servicos = new() {
            new() {
                Id = 1,
                Nome = "Abertura de Empresa",
                Descricao = "É um serviço oferecido para novos empreendedores, cuida de todas as etapas burocráticas, desde a escolha do tipo de empresa, registro nos órgãos competentes até a obtenção de CNPJ."
            },
            new() {
                Id = 2,
                Nome = "Encerramento de Empresa",
                Descricao = "É um serviço que finaliza atividades empresariais de forma legal, cuidando de todos os procedimentos necessários."
            },
            new() {
                Id = 3,
                Nome = "Escrituração Contábil/Tributária",
                Descricao = "É um serviço que registra transações financeiras, garante conformidade fiscal e elabora demonstrações financeiras."
            },
            new() {
                Id = 4,
                Nome = "Assessoria para Gestão Financeira",
                Descricao = "Oferece suporte na administração financeira, incluindo planejamento, controle de caixa e análise de desempenho para garantir saúde financeira."
            },
            new() {
                Id = 5,
                Nome = "Assessoria Trabalhista",
                Descricao = "Oferece suporte completo na gestão de questões trabalhistas e assegura conformidade legal para sua empresa."
            },
        };
        builder.Entity<Servico>().HasData(servicos);
        #endregion
    }

}