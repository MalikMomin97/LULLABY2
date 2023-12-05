using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SERVICES.Authentication;
using SERVICES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Data
{
    public class LullabyDbContext:IdentityDbContext<ApplicationUser>
    {
        public LullabyDbContext(DbContextOptions<LullabyDbContext>options):base(options)
        {
            
        }

        public DbSet<Device>device { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
