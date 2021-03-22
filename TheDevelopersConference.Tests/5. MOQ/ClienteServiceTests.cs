using Moq;
using System.Linq;
using TheDevelopersConference.Demonstracao.Clientes;
using TheDevelopersConference.Tests.Bogus;
using Xunit;

namespace TheDevelopersConference.Tests.MOQ
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceTests
    {
        readonly ClienteBogusTestsFixture _clienteTestsBogus;

        public ClienteServiceTests(ClienteBogusTestsFixture clienteTestsFixture)
        {
            _clienteTestsBogus = clienteTestsFixture;
        }        

        [Fact(DisplayName = "MOQ - Obter Clientes Ativos")]
        [Trait("Categoria", "Teste de Unidade")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            var clienteRepo = new Mock<IClienteRepository>();

            clienteRepo.Setup(c => c.ObterTodos())
                .Returns(_clienteTestsBogus.ObterClientesVariados());

            var clienteService = new ClienteService(clienteRepo.Object);

            // Act
            var clientes = clienteService.ObterTodosAtivos();

            // Assert 
            clienteRepo.Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.True(clientes.Count(c => c.Ativo) > 0);
        }
    }
}