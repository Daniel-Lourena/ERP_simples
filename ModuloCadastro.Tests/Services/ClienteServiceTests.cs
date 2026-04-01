using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.Tests.Geral.Builders;

namespace ModuloCadastro.Tests.Services
{
    public class ClienteServiceTests
    {
        // Retorna um número aleatório entre 0 e 100 para usar como IdCliente inicial
        private static int GerarIdAleatorio() => new Random().Next(0, 101);

        private (ModuloCadastroContext context, int idClienteInicial) CriarContexto()
        {
            int idInicial = GerarIdAleatorio();

            var options = new DbContextOptionsBuilder<ModuloCadastroContext>()
                .UseInMemoryDatabase("ClienteServiceTests")
                .Options;

            var context = new ModuloCadastroContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Set<AutoNumeradorEntity>().Add(new AutoNumeradorEntity { IdCliente = idInicial });
            context.Set<EstadoEntity>().Add(new EstadoEntity { Cuf = 35, Uf = "SP", Nome = "São Paulo" });
            context.Set<CidadeEntity>().Add(new CidadeEntity { Id = 1, Cuf = 35, Cmunicipio = "3550308", Dmunicipio = "São Paulo" });
            context.SaveChanges();

            return (context, idInicial);
        }

        // ===== Get =====

        [Fact]
        public void Get_QuandoClienteExiste_DeveRetornarClienteComCidadeEEstado()
        {
            // Arrange
            var (context, _) = CriarContexto();
            var cliente = new ClienteBuilder().ComRazaoSocial("Empresa ABC").Build();
            cliente.Id = 1;
            context.Set<ClienteEntity>().Add(cliente);
            context.SaveChanges();

            var service = new ClienteService(context);

            // Act
            var resultado = service.Get(1);

            // Assert
            resultado.Should().NotBeNull();
            resultado.RazaoSocial.Should().Be("Empresa ABC");
            resultado.Cidade.Should().NotBeNull();
            resultado.Cidade!.DadosEstado.Should().NotBeNull();
        }

        [Fact]
        public void Get_QuandoClienteNaoExiste_DeveRetornarNull()
        {
            // Arrange
            var (context, _) = CriarContexto();
            var service = new ClienteService(context);

            // Act
            var resultado = service.Get(999);

            // Assert
            resultado.Should().BeNull();
        }

        // ===== GetList =====

        [Fact]
        public void GetList_QuandoExistemClientes_DeveRetornarTodosComRelacionamentos()
        {
            // Arrange
            var (context, _) = CriarContexto();

            var cliente1 = new ClienteBuilder().ComRazaoSocial("Cliente 1").Build();
            cliente1.Id = 1;
            var cliente2 = new ClienteBuilder().ComRazaoSocial("Cliente 2").Build();
            cliente2.Id = 2;
            context.Set<ClienteEntity>().AddRange(cliente1, cliente2);
            context.SaveChanges();

            var service = new ClienteService(context);

            // Act
            var resultado = service.GetList().ToList();

            // Assert
            resultado.Should().HaveCount(2);
            resultado.Should().AllSatisfy(c => c.Cidade.Should().NotBeNull());
        }

        [Fact]
        public void GetList_QuandoBancoVazio_DeveRetornarListaVazia()
        {
            // Arrange
            var (context, _) = CriarContexto();
            var service = new ClienteService(context);

            // Act
            var resultado = service.GetList().ToList();

            // Assert
            resultado.Should().BeEmpty();
        }

        // ===== Update =====

        [Fact]
        public void Update_QuandoClienteExiste_DeveAtualizarDadosNoBanco()
        {
            // Arrange
            var (context, _) = CriarContexto();
            var cliente = new ClienteBuilder().ComRazaoSocial("Nome Original").Build();
            cliente.Id = 1;
            context.Set<ClienteEntity>().Add(cliente);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            var clienteAtualizado = new ClienteBuilder().ComRazaoSocial("Nome Atualizado").Build();
            clienteAtualizado.Id = 1;
            var service = new ClienteService(context);

            // Act
            service.Update(clienteAtualizado);

            // Assert
            var clienteSalvo = context.Set<ClienteEntity>().Find(1);
            clienteSalvo!.RazaoSocial.Should().Be("Nome Atualizado");
        }

        // ===== Insert / UpdateParcial =====
        // Não testáveis sem refatoração:
        // - Insert chama ServiceMethods.UpdateParcial(numerador, ...) internamente
        // - UpdateParcial chama ServiceMethods.UpdateParcial(entity, ...)
        // Ambos criam new ModuloCadastroContext() sem provider configurado,
        // lançando InvalidOperationException em SaveChanges.
        // Para testar esses métodos, ServiceMethods deve receber injeção de contexto.
    }
}
