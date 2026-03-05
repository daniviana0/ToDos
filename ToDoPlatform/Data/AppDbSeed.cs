using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        #region Popular Usuário

        #endregion
    }   
}
