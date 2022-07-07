using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThirdSample.Models;
using Type = ThirdSample.Models.Type;

namespace ThirdSample.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext>options):
        base (options)
        {
            
        }
        public DbSet<Item> items {get; set;}
        public DbSet<Type> types {get; set;}
        public DbSet<Instrument> instruments {get; set;}
        public DbSet<login> logins {get; set;}
        public DbSet<register> registers {get; set;}
    }
}