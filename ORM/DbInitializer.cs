using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Helpers;

namespace ORM
{
    public class DbInitializer : CreateDatabaseIfNotExists<EntityModel>
    {
        protected override void Seed(EntityModel context)
        {
            Role r1 = new Role {Id = 1, Name = "Администратор"};
            Role r2 = new Role {Id = 2, Name = "Пользователь"};
            Role r3 = new Role {Id = 3, Name = "Гость"};

            context.Roles.Add(r1);
            context.Roles.Add(r2);
            context.Roles.Add(r3);

            User admin = new User {Id = 1, Login = "admin", Password = Crypto.HashPassword("admin"), Roles = new List<Role>(){r1}};
            User user = new User {Id = 2, Login = "anna96", Password = Crypto.HashPassword("anna96"), Roles = new List<Role>() {r2}};

            context.Users.Add(admin);
            context.Users.Add(user);

            base.Seed(context);
        }
    }
}
