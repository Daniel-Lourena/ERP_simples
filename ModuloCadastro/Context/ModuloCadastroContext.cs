using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        internal DbSet<BancoEntity> Bancos { get; set; }
        internal DbSet<CategoriaEntity> Categorias { get; set; }
        internal DbSet<SetorEstoqueEntity> SetoresEstoque { get; set; }
        internal DbSet<PedidoEntity> Pedidos { get; set; }
        internal DbSet<ProdutoPedidoEntity> ProdutosPedidos { get; set; }

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
                entity.HasKey(a => a.id);
            });

            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasKey(u => u.id);
                entity.Property(u => u.cargo).HasConversion<int>();
            });
            
            modelBuilder.Entity<ClienteEntity>(entity =>
            {
                entity.HasKey(c => c.id);

                entity.HasOne(c => c.DadosCidade)
                      .WithMany()
                      .HasForeignKey(c => c.end_cidade)
                      .HasPrincipalKey(key => new { key.id });
            });

            modelBuilder.Entity<CidadeEntity>(entity =>
            {
                entity.HasKey(c => c.id);
                
                entity.HasOne(c => c.DadosEstado)
                      .WithMany()
                      .HasForeignKey(c => c.cuf)
                      .HasPrincipalKey(key => new { key.cuf});
            });

            modelBuilder.Entity<EstadoEntity>(entity =>
            {
                entity.HasKey(c => c.cuf);
            });

            modelBuilder.Entity<ProdutoEntity>(entity =>
            {
                entity.HasKey(p => p.id);
                entity.Property(p => p.origem).HasConversion<int>();

                entity.HasOne(p => p.DadosCategoria)
                      .WithMany()
                      .HasForeignKey(p => p.categoria)
                      .HasPrincipalKey(key => new { key.id });
                
                entity.HasOne(p => p.DadosSetorEstoque)
                      .WithMany()
                      .HasForeignKey(p => p.setorEstoque)
                      .HasPrincipalKey(key => new { key.id });
            });

            modelBuilder.Entity<CategoriaEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });

            modelBuilder.Entity<SetorEstoqueEntity>(entity =>
            {
                entity.HasKey(c => c.id);
            });

            modelBuilder.Entity<BancoEntity>(entity =>
            {
                entity.HasKey(b => b.id);
                entity.Property(b => b.tipoConta).HasConversion<int>();
                entity.Property(b => b.pixTipoChave).HasConversion<int>();
            });

            modelBuilder.Entity<PedidoEntity>(entity =>
            {
                entity.HasKey(p => p.id);

                entity.HasOne(p => p.DadosCliente)
                      .WithMany()
                      .HasForeignKey(p => p.idCliente)
                      .HasPrincipalKey(key => new { key.id });
            });

            //modelBuilder.Entity<ProdutoPedidoEntity>(entity =>
            //{
            //    entity.HasKey(c => c.id);
                
            //    entity.HasOne(p => p.DadosProduto)
            //          .WithMany()
            //          .HasForeignKey(p => p.DadosProduto.id)
            //          .HasPrincipalKey(key => new { key.id });
            //});
        }
    }
}
