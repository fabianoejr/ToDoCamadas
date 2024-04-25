using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Tarefas> Tarefa { get; set; }
        public DbSet<Categorias> Categoria { get; set; }
        public DbSet<Historico> Historico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasKey(p => p.Id);
            modelBuilder.Entity<Tarefas>().HasKey(p => p.Id);
            modelBuilder.Entity<Categorias>().HasKey(p => p.Id);
            modelBuilder.Entity<Historico>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
