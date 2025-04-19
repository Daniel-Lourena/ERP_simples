using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    internal class ModuloCadastroContext : DbContext
    {
        internal DbSet<AutoNumeradorEntity> AutoNumeradores { get; set; }
        internal DbSet<UsuarioEntity> Usuarios { get; set; }
        internal DbSet<ClienteEntity> Clientes { get; set; }
        internal DbSet<CidadeEntity> Cidades { get; set; }
        internal DbSet<EstadoEntity> Estados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoNumeradorEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });

            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });
            
            modelBuilder.Entity<ClienteEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });

            modelBuilder.Entity<CidadeEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });

            modelBuilder.Entity<EstadoEntity>(entity =>
            {
                entity.HasKey(c => c.cuf);
            });
        }
    }
}
