using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FyJCel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FyJCel.Models.Contacto> Contactos { get; set; }

         public DbSet<FyJCel.Models.Producto> productos { get; set; }

         
         public DbSet<FyJCel.Models.Pedido> Pedidos { get; set; }
    }
}
