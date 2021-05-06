using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreWebApp.Models;

namespace NetCoreWebApp.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<NetCoreWebApp.Models.Predmet> Predmet { get; set; }
    }
}
