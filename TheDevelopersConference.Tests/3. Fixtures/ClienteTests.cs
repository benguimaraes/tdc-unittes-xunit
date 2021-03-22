using Xunit;

namespace TheDevelopersConference.Tests.Fixture
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTests
    {
        private readonly ClienteTestsFixture _clienteTestsFixture;

        public ClienteTests(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }
        
        [Fact(DisplayName = "Fixtures - Novo Cliente Válido")]
        [Trait("Categoria", "Teste de Unidade")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = _clienteTestsFixture.GerarClienteValido();

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }
    }
}