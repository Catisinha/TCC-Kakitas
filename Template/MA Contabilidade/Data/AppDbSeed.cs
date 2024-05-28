using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCC-Kakitas.Models;

namespace TCC-Kakitas.Data;

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
                Email = "admin@amcontabilidadeMona.com",
                NormalizedEmail = "ADMIN@AMCONTABILIDADEMONA.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true,
            },

            List<IdentityUser> users = new()
            new IdentityUser(){
                Id = Guid.NewGuid().ToString(),
                Email = "admin@amcontabilidadealine.com",
                NormalizedEmail = "ADMIN@AMCONTABILIDADEALINE.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true,
            },
        };

        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "@Etec123");
        }
        builder.Entity<IdentityUser>().HasData(users);