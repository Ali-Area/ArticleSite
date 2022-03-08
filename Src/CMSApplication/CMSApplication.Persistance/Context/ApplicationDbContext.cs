using CMSApplication.Domain.Entities.MainEntities.ArticleEntities;
using CMSApplication.Domain.Entities.MainEntities.UserEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Persistance.Context
{
    public class ApplicationDbContext : IdentityDbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: "Server = (localdb)\\MSSQLLocalDB; DataBase = CMSApplicationDataBase; Integrated Security = true;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>().HasQueryFilter(a => !a.IsDeleted);
            builder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);


        }


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
