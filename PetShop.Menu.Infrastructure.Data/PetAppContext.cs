using Microsoft.EntityFrameworkCore;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Menu.Infrastructure.Data
{
    public class PetAppContext : DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt)
            : base(opt) { }

        public DbSet<PetEntity> pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
