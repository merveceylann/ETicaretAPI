using ETicaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        //visual studio kullanmiyor da olabilirdik. bu sekilde db olusturabiliriz powershell ile.
        //burada bu classi yazarak ikinci kez connection string kullanmis olduk. Bu sebeple bir json dosyasinda yazmak daha mantikliydi. appsettings.json da hali hazirda bunun icin kullanilabilir.
        //bu yapiyi kurabilmek icin de iki adet kütüphane yükledik
        //bu yapiyi da yine iki kere kullanmak yerine bir classa almaliyiz

        public ETicaretAPIDbContext CreateDbContext(string[] args)
        {
            //ConfigurationManager configurationManager = new();
            //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
            //configurationManager.AddJsonFile("appsetting.json");

            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
            //dbContextOptionsBuilder.UseNpgsql("PostgreSQL");
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);

            return new ETicaretAPIDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
