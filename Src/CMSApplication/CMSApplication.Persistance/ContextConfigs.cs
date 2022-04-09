using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using CMSApplication.Domain.Entities.MainEntities.CategoryEntities;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Persistance
{
    public static class ContextConfigs
    {
        public static void ConfigEntityFilters(this ModelBuilder builder)
        {
            builder.Entity<Article>().HasQueryFilter(a => !a.IsDeleted);
            builder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            builder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
        }

        public static void ConfigRoleSeeds(this ModelBuilder builder)
        {

            // --- seed roles --- //
            builder.Entity<Role>().HasData(
                    new Role() { Id = "admin", IsDeleted = false, Name = "Admin", NormalizedName = "ADMIN" },
                    new Role() { Id = "user", IsDeleted = false, Name = "User", NormalizedName = "USER" }
                );




        }



        public static void ConfigUserSeeds(this ModelBuilder builder)
        {

            // --- seed user --- //
            var user = new User()
            {
                Id = "adminuser",
                Name = "MainAdmin",
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                RoleId = "admin",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN@ADMIN.COM"
            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "AliRashtbari123");


            builder.Entity<User>().HasData(
                    user
                );
        }



        public static void UserRolesSeeds(this ModelBuilder builder)
        {
            // --- seed user roles --- //
            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = "admin",
                        UserId = "adminuser"
                    });

            // --- adding the claims --- //

            builder.Entity<IdentityUserClaim<string>>().HasData(
                    new IdentityUserClaim<string>()
                    {
                        Id = 1,
                        UserId = "adminuser",
                        ClaimType = "UserName",
                        ClaimValue = "admin@admin.com"
                    },
                    new IdentityUserClaim<string>()
                    {
                        Id = 2,
                        UserId = "adminuser",
                        ClaimType = "Email",
                        ClaimValue = "admin@admin.com"
                    },
                    new IdentityUserClaim<string>()
                    {
                        Id = 3,
                        UserId = "adminuser",
                        ClaimType = "UserId",
                        ClaimValue = "adminuser"
                    },
                    new IdentityUserClaim<string>()
                    {
                        Id = 4,
                        UserId = "adminuser",
                        ClaimType = "Name",
                        ClaimValue = "MainAdmin"
                    },
                    new IdentityUserClaim<string>()
                    {
                        Id = 5,
                        UserId = "adminuser",
                        ClaimType = "Role",
                        ClaimValue = "Admin"
                    });

        }



        public static void ConfigEntityRelations(this ModelBuilder builder)
        {
            builder.Entity<User>().HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>().HasIndex(user => user.Email).IsUnique();





        }

    }
}
