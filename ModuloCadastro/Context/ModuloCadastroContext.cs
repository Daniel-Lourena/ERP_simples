using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class ModuloCadastroContext : DbContext
    {
        internal DbSet<AutoNumeradorEntity> AutoNumeradores { get; set; }
        internal DbSet<UsuarioEntity> Usuarios { get; set; }
        internal DbSet<ClienteEntity> Clientes { get; set; }
        internal DbSet<CidadeEntity> Cidades { get; set; }
        internal DbSet<EstadoEntity> Estados { get; set; }
        internal DbSet<ProdutoEntity> Produtos { get; set; }
        internal DbSet<CategoriaEntity> Categorias { get; set; }
        internal DbSet<SetorEstoqueEntity> SetoresEstoque { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Conexão com MySQL
            optionsBuilder.UseMySql(ModuloConfiguracoes.ConfiguracoesGerais.stringConexaoDB + "AllowLoadLocalInfile=true;",
                new MySqlServerVersion(new Version(5, 7)),  // Versão mínima suportada
                options => options.EnableRetryOnFailure()); // Configurações adicionais
        }

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

            modelBuilder.Entity<ProdutoEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });

            modelBuilder.Entity<CategoriaEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });

            modelBuilder.Entity<SetorEstoqueEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });
        }
    }
}
