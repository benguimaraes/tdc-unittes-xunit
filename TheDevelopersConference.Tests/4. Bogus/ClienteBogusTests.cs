using Xunit;

namespace TheDevelopersConference.Tests.Bogus
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteBogusTests
    {
        private readonly ClienteBogusTestsFixture _clienteTestsFixture;

        public ClienteBogusTests(ClienteBogusTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }
        

        [Fact(DisplayName = "Bogus - Novo Cliente Válido")]
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