using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bbk.Data.EntityFramework
{
    public class BBKDbContextFactory : IDesignTimeDbContextFactory<BBKDbContext>
    {
        public BBKDbContext CreateDbContext(string[] args)
        {
            //lấy ra thông tin trong file cấu hình  
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            // lấy ra thông tin connection string 
            string connectionString = configuration.GetConnectionString("BbkConnectionString"); 

            var optionsBuilder = new DbContextOptionsBuilder<BBKDbContext>();

            optionsBuilder.UseSqlServer(connectionString); 

            return new BBKDbContext(optionsBuilder.Options); 

        }
    }
}
