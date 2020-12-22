using Microsoft.EntityFrameworkCore;
using ProjetoBRQ.Domain.Entities;
using ProjetoBRQ.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
