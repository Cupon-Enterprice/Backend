using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cupon> Cupones { get; set;}
        public DbSet<Admin> Admins { get; set;}
        public DbSet<TipoCupon> TipoCupones { get; set;}
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Redencion> Redenciones { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoCupon>()
                .HasMany(e => e.Cupones)
                .WithOne(e => e.TipoCupon)
                .HasForeignKey(e => e.Tipo_Cupones_Id)
                .HasPrincipalKey(e => e.Id);
        }
        
    }
}