using Microsoft.EntityFrameworkCore;
using RegistroCompleto2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCompleto2.BAL
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = DATA\Usuarios.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolID = 1,
                Descripcion = "Aministrador"
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolID = 2,
                Descripcion = "Supervisor"
            });
        }
    }
}
