﻿using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Avtomivka.A.Logic
{
    public static class Seeder
    {
        
        public static void Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            Roles(roleManager);
            Users(userManager);
            Sites(context);
            Workers(context);
            Programs(context);
        }

        public static void Sites(ApplicationDbContext context)
        {
            DateTime closeTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 8, 0, 0);
            if (context.Sites.Count() <= 0)
            {
                context.Sites.AddRange(new Site[]
                {
                    new Site {Name = "Site1", Description = "Site1 description", OpenTime = DateTime.Now, CloseTime = closeTime},
                    new Site {Name = "Site2", Description = "Site2 description", OpenTime = DateTime.Now, CloseTime = closeTime},
                    new Site {Name = "Site3", Description = "Site3 description", OpenTime = DateTime.Now, CloseTime = closeTime},
                });
            }

            context.SaveChanges();
        }

        public static void Workers(ApplicationDbContext context)
        {
            if (context.Workers.Count() <= 0)
            {
                context.Workers.AddRange(new Worker[]
                {
                    new Worker{Id = "1", Name = "Gosho", Age = 30, Description = "Gosho description", Image = "default.png"},
                    new Worker{Id = "2", Name = "Pesho", Age = 20, Description = "Pesho description", Image = "default.png"},
                    new Worker{Id = "3", Name = "Tosho", Age = 40, Description = "Tosho description", Image = "default.png"},
                });
            }

            context.SaveChanges();
        }

        public static void Programs(ApplicationDbContext context)
        {
            if (context.Programs.Count() <= 0)
            {
                context.Programs.AddRange(new Data.Models.Program[]
                {
                    new Data.Models.Program{Name = "Program1", Description = "Program1 description", Price = 20, WorkerId = "1"},
                    new Data.Models.Program{Name = "Program2", Description = "Program2 description", Price = 30, WorkerId = "2"},
                    new Data.Models.Program{Name = "Program3", Description = "Program3 description", Price = 40, WorkerId = "3"},
                });
            }
        }

        public static void Users(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("User1@gmail.com").Result == null)
            {
                var account = new User
                {
                    UserName = "User1@gmail.com",
                    EmailConfirmed = true,
                    Email = "User1@gmail.com"
                };
                var result = userManager.CreateAsync(account, "User1@gmail.com.").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(account, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("User2@gmail.com").Result == null)
            {
                var account = new User
                {
                    UserName = "User2@gmail.com",
                    EmailConfirmed = true,
                    Email = "User2@gmail.com"
                };
                var result = userManager.CreateAsync(account, "User2@gmail.com.").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(account, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("Admin1@gmail.com").Result == null)
            {
                var account = new User
                {
                    UserName = "Admin1@gmail.com",
                    EmailConfirmed = true,
                    Email = "Admin1@gmail.com"
                };
                var result = userManager.CreateAsync(account, "Admin1@gmail.com.").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(account, "Admin").Wait();
                }
            }
        }

        public static void Roles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole() { Name = "User" };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole() { Name = "Admin" };
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}