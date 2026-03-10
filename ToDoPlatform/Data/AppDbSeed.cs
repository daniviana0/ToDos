using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoPlatform.Models;

namespace ToDoPlatform.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Popular Perfis de usuários
        List<IdentityRole> roles = new()
        {
            new()
            {
                Id = "45a2cb91-04c5-4160-8447-7a47f7534c0a",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new()
            {
                Id = "eb15bf5d-57f9-4bd1-b74f-4f5ef63555b6",
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Popular dados de Usuário
        List<AppUser> users = new()
        {
            new AppUser()
            {
                Id = "7aee7d67-0df0-4472-ade3-29f9ec4062b4",
                Email = "mariacoelhodias94@gmail.com",
                NormalizedEmail = "MARIACOELHODIAS94@GMAIL.COM",
                UserName = "mariacoelhodias94@gmail.com",
                NormalizedUserName = "MARIACOELHODIAS94@GMAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                Name = "Maria Luiza Coelho Dias",
                ProfilePicture = "",
            },
            new AppUser()
            {
                Id = "df106be2-2e1c-4bf6-b862-a420bf7236a2",
                Email = "danivianadecarvalho@gmail.com",
                NormalizedEmail = "DANIELVIANADECARVALHO@GMAIL.COM",
                UserName = "danivianadecarvalho@gmail.com",
                NormalizedUserName = "DANIELVIANADECARVALHO@GMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Name = "Daniel Viana de Carvalho",
                ProfilePicture = "",
            }
        };
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<AppUser>().HasData(users);
        #endregion

        #region Popular Dados de Usuário Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>()
            {
                UserId = users[1].Id,
                RoleId = roles[1].Id
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region Popular as Tarefas do usuário
        List<ToDo> toDos = new()
        {
            new ToDo()
            {
                Id = 1,
                Title = "Fazer redação da Meire",
                Description = "Produzir uma redação modelo ENEM.",
                UserId = users[0].Id
            },

            new ToDo()
            {
                Id = 2,
                Title = "Ligar na barbearia",
                Description = "Agendar corte de cabelo.",
                UserId = users[1].Id
            },

            new ToDo()
            {
                Id = 3,
                Title = "Estudar prova",
                Description = "Estudar para prova de Matemática.",
                UserId = users[1].Id
            },

        };
        builder.Entity<ToDo>().HasData(toDos);
        #endregion
    }
}