using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.Persistance.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = "Server = (localdb)\\MSSQLLocalDB; DataBase = CMSApplicationDataBase; Integrated Security = true;";

            optionsBuilder.UseSqlServer(connectionString, builder =>
            {

            });

            return new ApplicationDbContext(options: optionsBuilder.Options);
        }
    }
}
