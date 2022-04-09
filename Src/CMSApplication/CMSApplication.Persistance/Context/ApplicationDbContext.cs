using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using CMSApplication.Domain.Entities.MainEntities.CategoryEntities;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Persistance.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ConfigRoleSeeds();
            builder.ConfigUserSeeds();
            builder.UserRolesSeeds();
                

            builder.ConfigEntityFilters();
            builder.ConfigEntityRelations();

        }

         




        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }












        public bool IsBegan => (Database.CurrentTransaction != null);

        public void Begin()
        {
            Database.BeginTransaction();
        }

        public void Commit()
        {
            SaveChanges();
            Database.CommitTransaction();
        }

        public void RollBack()
        {
            Database.RollbackTransaction();
        }
    }
}
