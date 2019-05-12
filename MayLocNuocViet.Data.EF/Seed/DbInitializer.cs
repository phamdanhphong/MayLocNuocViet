using Fsoft.SKU.CoreApp.Data.EF;
using Microsoft.AspNetCore.Identity;
using MLT.MayLocNuocViet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLT.MayLocNuocViet.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<Employee> _userManager;
        private RoleManager<Role> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<Employee> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }


            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new Employee()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com"
                }, "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
          
          
            await _context.SaveChangesAsync();

        }
    }
}
