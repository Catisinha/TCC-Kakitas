using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCCKakitas.Models;

namespace TCCKakitas.Data;

#region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate IdentityUser
        List<IdentityUser> users = new(){
            new IdentityUser(){
                Id = Guid.NewGuid().ToString(),
                Email = "contatoampmcontabilidade@gmail.com",
                NormalizedEmail = "CONTATOAMPMCONTABILIDADE@GMAIL.COM",
                UserName = "Admin",,
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true,
            },
        };

        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "@AMcontabilidade123");
        }
        builder.Entity<IdentityUser>().HasData(users);

        #region Populate Servico
        List<Servico> Servicos = new() {
            new Servico() {
                Id = 1,
                Nome = "Abertura de Empresa",
                Foto = "",
                Filtrar = true,
                Banner = true
            },
            new Servico() {
                Id = 2,
                Nome = "Encerramento de Empresa",
                Foto = "",
                Filtrar = true,
                Banner = true
            },
            new Servico() {
                Id = 3,
                Nome = "Escrituração Contábil/Tributária",
                Foto = "",
                Filtrar = true,
                Banner = true
            },
            new Servico() {
                Id = 4,
                Nome = "Assessoria para Gestão Financeira",
                Foto = "",
                Filtrar = true,
                Banner = true,
            },
            new Servico() {
                Id = 5,
                Nome = "Assessoria Trabalhista",
                Foto = "",
                Filtrar = true,
                Banner = true,
            },
        };
        builder.Entity<Categoria>().HasData(servicos);
        #endregion