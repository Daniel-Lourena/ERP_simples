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
        internal DbSet<RecebimentoVendaEntity> RecebimentosVenda { get; set; }

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
                entity.HasKey(a => a.Id);
            });

            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Cargo).HasConversion<int>();
            });

            modelBuilder.Entity<ClienteEntity>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.Cidade)
                      .WithMany()
                      .HasForeignKey(c => c.CidadeId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CidadeEntity>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.DadosEstado)
                      .WithMany()
                      .HasForeignKey(c => c.Cuf)
                      .HasPrincipalKey(key => new { key.Cuf })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<EstadoEntity>(entity =>
            {
                entity.HasKey(c => c.Cuf);
            });

            modelBuilder.Entity<ProdutoEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Origem).HasConversion<int>();
                entity.Property(p => p.Cst_csosn).HasConversion<int>();
                entity.Property(p => p.UnidadeId).HasConversion<int>();

                entity.HasOne(p => p.Categoria)
                      .WithMany()
                      .HasForeignKey(p => p.CategoriaId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CategoriaEntity>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<SetorEstoqueEntity>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<BancoEntity>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.TipoConta).HasConversion<int>();
                entity.Property(b => b.PixTipoChave).HasConversion<int>();
            });

            modelBuilder.Entity<PedidoVendaEntity>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Cliente)
                      .WithMany()
                      .HasForeignKey(p => p.ClienteId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.UsuarioCriacao)
                      .WithMany()
                      .HasForeignKey(p => p.UsuarioCriacaoId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.UsuarioAtualizacao)
                      .WithMany()
                      .HasForeignKey(p => p.UsuarioAtualizacaoId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.UsuarioFechamento)
                      .WithMany()
                      .HasForeignKey(p => p.UsuarioFechamentoId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.UsuarioExclusao)
                      .WithMany()
                      .HasForeignKey(p => p.UsuarioExclusaoId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(pe => pe.ListaProdutosVenda)
                      .WithOne(pp => pp.PedidoVenda)
                      .HasForeignKey(pp => pp.PedidoVendaId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<EstoqueEntity>(entity =>
            {
                entity.HasKey(c => new { c.ProdutoId, c.SetorEstoqueId });

                entity.HasOne(e => e.Produto)
                      .WithMany()
                      .HasForeignKey(e => e.ProdutoId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.SetorEstoque)
                      .WithMany()
                      .HasForeignKey(e => e.SetorEstoqueId)
                      .HasPrincipalKey(key => new { key.Id })
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<RecebimentoVendaEntity>(entity =>
            {
                entity.HasKey(r => r.Id );
                entity.Property(r => r.Especie).HasConversion<int>();
            });
        }
    }
}
