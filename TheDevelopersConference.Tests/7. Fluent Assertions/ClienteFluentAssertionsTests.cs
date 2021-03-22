using FluentAssertions;
using TheDevelopersConference.Tests;
using TheDevelopersConference.Tests.Bogus;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteBogusTests
    {
        private readonly ClienteBogusTestsFixture _clienteTestsFixture;

        public ClienteBogusTests(ClienteBogusTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }


        [Fact(DisplayName = "Fluent Assertions - Novo Cliente Válido")]
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

            // FluentAssertions 
            result.Should().BeTrue();
            cliente.ValidationResult.Errors.Should().HaveCount(0);
        }
    }
}