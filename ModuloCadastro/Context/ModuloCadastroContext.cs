using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;

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
        internal DbSet<PedidoVendaEntity> PedidosVendas { get; set; }
        internal DbSet<ProdutoVendaEntity> ProdutosVendas { get; set; }
        internal DbSet<EstoqueEntity> Estoques { get; set; }

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
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CidadeEntity>(entity =>
            {
                entity.HasKey(c => c.id);

                entity.HasOne(c => c.DadosEstado)
                      .WithMany()
                      .HasForeignKey(c => c.cuf)
                      .HasPrincipalKey(key => new { key.cuf })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<EstadoEntity>(entity =>
            {
                entity.HasKey(c => c.cuf);
            });

            modelBuilder.Entity<ProdutoEntity>(entity =>
            {
                entity.HasKey(p => p.id);
                entity.Property(p => p.origem).HasConversion<int>();
                entity.Property(p => p.idUnidade).HasConversion<int>();

                entity.HasOne(p => p.DadosCategoria)
                      .WithMany()
                      .HasForeignKey(p => p.categoria)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);
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

            modelBuilder.Entity<PedidoVendaEntity>(entity =>
            {
                entity.HasKey(p => p.id);

                entity.HasOne(p => p.DadosCliente)
                      .WithMany()
                      .HasForeignKey(p => p.idCliente)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.DadosUsuarioCriador)
                      .WithMany()
                      .HasForeignKey(p => p.idCriador)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.DadosUsuarioAtualizacao)
                      .WithMany()
                      .HasForeignKey(p => p.usuarioAtualizacao)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.DadosUsuarioFechamento)
                      .WithMany()
                      .HasForeignKey(p => p.usuarioFechamento)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<EstoqueEntity>(entity =>
            {
                entity.HasKey(c => new { c.idProduto, c.setorEstoque });

                entity.HasOne(e => e.DadosProduto)
                      .WithMany()
                      .HasForeignKey(e => e.idProduto)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.DadosSetorEstoque)
                      .WithMany()
                      .HasForeignKey(e => e.setorEstoque)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PedidoVendaEntity>(entity =>
            {
                entity.HasKey(pe => pe.id);

                entity.HasOne(pe => pe.DadosCliente)
                      .WithMany()
                      .HasForeignKey(pe => pe.idCliente)
                      .HasPrincipalKey(key => new { key.id })
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(pe => pe.listaProdutosVenda)
                      .WithOne(pp => pp.DadosPedidoVenda)
                      .HasForeignKey(pp => pp.idPedido)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            //modelBuilder.Entity<ProdutoVendaEntity>(entity =>
            //{
            //    entity.HasKey(p => p.id);

            //    entity.HasOne(p => p.DadosProduto)
            //          .WithMany()
            //          .HasForeignKey(p => p.idProduto)
            //          .HasPrincipalKey(key => new { key.id })
            //          .OnDelete(DeleteBehavior.NoAction);

            //    entity.HasOne(p => p.DadosPedidoVenda)
            //          .WithMany()
            //          .HasForeignKey(p => p.idPedido)
            //          .HasPrincipalKey(key => new { key.id })
            //          .OnDelete(DeleteBehavior.NoAction);
            //});
        }
    }
}
