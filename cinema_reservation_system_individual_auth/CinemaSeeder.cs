using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_reservation_system_individual_auth

{
    public class CinemaSeeder
    {
        private readonly CinemaDbContext _dbContext;

        public CinemaSeeder(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Users.Any(u => u.RoleId == 3)) {
                    _dbContext.Users.Add(new User()
                    {
                        Email = "admin@admin.com",
                        Password = "nqzvanqzva",
                        RoleId = 3

                    });
                    _dbContext.SaveChanges();
                }
             
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                Name = "Worker"
            },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }
    }
}
