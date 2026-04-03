using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Cadastro.Cliente;
using ModuloCadastro.Entity.Cadastro.Localizacao;
using ModuloCadastro.Service;
using ModuloCadastro.Service.Cadastro.Cliente;
using ModuloCadastro.Tests.Factory;
using ModuloCadastro.Tests.Geral.Builders;

namespace ModuloCadastro.Tests.Services
{
    public class ClienteServiceTests
    {
        // Retorna um número aleatório entre 0 e 100 para usar como IdCliente inicial
        private static int GerarIdAleatorio() => new Random().Next(0, 101);

        private (DbContextOptions<ModuloCadastroContext> options, ModuloCadastroContext context, int idClienteInicial) CriarContexto()
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

            return (options, context,idInicial);
        }

        // ===== Get =====

        [Fact]
        public void Get_QuandoClienteExiste_DeveRetornarClienteComCidadeEEstado()
        {
            // Arrange
            var (options, context,_) = CriarContexto();
            var cliente = new ClienteBuilder().ComRazaoSocial("Empresa ABC").Build();
            cliente.Id = 1;

            context.Set<ClienteEntity>().Add(cliente);
            context.SaveChanges();

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

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
            var (options, context, _) = CriarContexto();

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

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
            var (options, context, _) = CriarContexto();

            var cliente1 = new ClienteBuilder().ComRazaoSocial("Cliente 1").Build();
            cliente1.Id = 1;
            var cliente2 = new ClienteBuilder().ComRazaoSocial("Cliente 2").Build();
            cliente2.Id = 2;
            context.Set<ClienteEntity>().AddRange(cliente1, cliente2);
            context.SaveChanges();

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

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
            var (options, context, _) = CriarContexto();

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

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
            var (options, context, _) = CriarContexto();
            var cliente = new ClienteBuilder().ComRazaoSocial("Nome Original").Build();
            cliente.Id = 1;
            context.Set<ClienteEntity>().Add(cliente);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            var clienteAtualizado = new ClienteBuilder().ComRazaoSocial("Nome Atualizado").Build();
            clienteAtualizado.Id = 1;


            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

            // Act
            service.Update(clienteAtualizado);

            // Assert
            var clienteSalvo = context.Set<ClienteEntity>().Find(1);
            clienteSalvo!.RazaoSocial.Should().Be("Nome Atualizado");
        }

        // ===== Insert =====

        [Fact]
        public void Insert_QuandoDadosValidos_DevePersistirClienteERetornarId()
        {
            // Arrange
            var (options,context, idInicial) = CriarContexto();
            var cliente = new ClienteBuilder().ComRazaoSocial("Cliente Novo").Build();

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

            // Act
            var idRetornado = service.Insert(cliente);

            // Assert
            idRetornado.Should().Be(idInicial + 1);
            context.ChangeTracker.Clear();
            var clienteSalvo = context.Set<ClienteEntity>().Find(idRetornado);
            clienteSalvo.Should().NotBeNull();
            clienteSalvo!.RazaoSocial.Should().Be("Cliente Novo");
        }

        [Fact]
        public void Insert_QuandoInserido_DeveIncrementarIdNoAutoNumerador()
        {
            // Arrange
            var (options, context, idInicial) = CriarContexto();
            var cliente = new ClienteBuilder().Build();

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

            // Act
            service.Insert(cliente);

            // Assert
            context.ChangeTracker.Clear();
            var numerador = context.Set<AutoNumeradorEntity>().First();
            numerador.IdCliente.Should().Be(idInicial + 1);
        }

        [Fact]
        public void Insert_QuandoInseridoDoisClientes_DeveAtribuirIdsSequenciais()
        {
            // Arrange
            var (options, context, idInicial) = CriarContexto();
            var cliente1 = new ClienteBuilder().ComRazaoSocial("Cliente 1").Build();
            var cliente2 = new ClienteBuilder().ComRazaoSocial("Cliente 2").Build();

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

            // Act
            var id1 = service.Insert(cliente1);
            var id2 = service.Insert(cliente2);

            // Assert
            id1.Should().Be(idInicial + 1);
            id2.Should().Be(idInicial + 2);
        }

        // ===== UpdateParcial =====

        [Fact]
        public void UpdateParcial_QuandoPropriedadeEspecificada_DeveAtualizarApenasEssaPropriedade()
        {
            // Arrange
            var (options, context, _) = CriarContexto();
            var cliente = new ClienteBuilder()
                .ComRazaoSocial("Razao Original")
                .ComFantasia("Fantasia Original")
                .Build();
            cliente.Id = 1;
            context.Set<ClienteEntity>().Add(cliente);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            var clienteParaAtualizar = new ClienteBuilder()
                .ComRazaoSocial("Razao Atualizada")
                .ComFantasia("Fantasia Nao Deve Mudar")
                .Build();
            clienteParaAtualizar.Id = 1;

            var factory = new DbContextFactoryFake(options);
            var service = new ClienteService(factory);

            // Act
            service.UpdateParcial(clienteParaAtualizar, new List<string> { nameof(ClienteEntity.RazaoSocial) });

            // Assert
            context.ChangeTracker.Clear();
            var clienteSalvo = context.Set<ClienteEntity>().Find(1);
            clienteSalvo!.RazaoSocial.Should().Be("Razao Atualizada");
            clienteSalvo.Fantasia.Should().Be("Fantasia Original");
        }
    }
}
