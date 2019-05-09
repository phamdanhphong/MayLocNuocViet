using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fsoft.SKU.CoreApp.Data.Entities;
using Fsoft.SKU.CoreApp.Data.Enums;
using Fsoft.SKU.CoreApp.Utilities.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Fsoft.SKU.CoreApp.Data.EF.Repositories;
using Fsoft.SKU.CoreApp.DatabaseUtility.EntityFramework.Repositories;

namespace Fsoft.SKU.CoreApp.Data.EF.Seed
{
    public class DbInitializer
    {
        private AppDbContext _context;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;
        private IRepository<UserRole> _userRoleRepository;

        public DbInitializer(AppDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, IRepository<UserRole> userRoleRepository)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRoleRepository = userRoleRepository;

        }

        public async Task SeedAsync()
        {
            try
            {
                AddGroups();
                AddMenu();
                await AddRolesAsync();
                await AddUsersAsync();

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when initial db", ex);
            }

        }
        public void AddGroups()
        {
            if (_context.Groups.Count() == 0)
            {
                List<Group> listGroups = new List<Group>()
                {
                    new Group() { Name="SuperAdmins", Description="", Status="Active" },
                      new Group() { Name="GroupAdmins", Description="", Status="Active" },
                        new Group() { Name="UserAdmins", Description="", Status="Active" },
                          new Group() { Name="Users", Description="", Status="Active" }
                };
                _context.Groups.AddRange(listGroups);
            }
        }


        public void AddMenu()
        {
            if (_context.Menus.Count() == 0)
            {
                List<Menu> listMenu = new List<Menu>()
                {
                    new Menu() { Name="EmailAccount",  Status="Active" },
                    new Menu() { Name="EmailTemplate",  Status="Active" },
                    new Menu() { Name="User",  Status="Active" },
                    new Menu() { Name="Role",  Status="Active" },
                    new Menu() { Name="Group",  Status="Active" }
                };
                _context.Menus.AddRange(listMenu);
            }
        }

        public async Task AddRolesAsync()
        {
            if (!_context.Roles.Any())
            {
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Global Access",
                    Status = "Active"
                });

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "CanEditUser",
                    NormalizedName = "CanEditUser",
                    Description = "Add, modify, and delete Users",
                    Status = "Active"
                });

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "CanEditGroup",
                    NormalizedName = "CanEditGroup",
                    Description = "Add, modify, and delete Groups",
                    Status = "Active"
                });

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "CanEditRole",
                    NormalizedName = "CanEditRole",
                    Description = "Add, modify, and delete roles",
                    Status = "Active"
                });

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Description = "Restricted to business domain activity",
                    Status = "Active"
                });

            }
        }

        private async Task AddUsersAsync()
        {
            if (!_context.Users.Any())
            {
                await _userManager.CreateAsync(new User()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@fsoft.com.vn",
                    Status = CommonConstants.StatusActive
                }, "123456");

                var user = await _userManager.FindByNameAsync("admin");
                var role = await _roleManager.FindByNameAsync("Admin");

                UserRole userRole = new UserRole();
                userRole.UserId = user.Id;
                userRole.RoleId = role.Id;
                userRole.CreatedDate = DateTime.Now;
                userRole.UpdatedDate = DateTime.Now;
                userRole.Discriminator = UserRoleConstant.Discriminator_Default;
                _userRoleRepository.Insert(userRole);
            }
        }
    }
}
