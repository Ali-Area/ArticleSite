using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
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
        }

        public static void ConfigEntitySeeds(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                    new Role () { Id = Guid.NewGuid().ToString(), IsDeleted = false, Name = "Admin" },
                    new Role () { Id = Guid.NewGuid().ToString(), IsDeleted = false, Name = "User" }
                );
        }

        public static void ConfigEntityRelations(this ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasOne(r => r.User)
                .WithOne(u => u.Role)
                .HasForeignKey<Role>(r => r.UserId);
        }

    }
}
