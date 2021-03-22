using System;
using TheDevelopersConference.Demonstracao.Clientes;
using Xunit;

namespace TheDevelopersConference.Tests.Traits
{
    public class ClienteTests
    {
        [Fact]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Fulano",
                "Silva",
                DateTime.Now.AddYears(-30),
                "fulano@gmail.com",
                true,
                DateTime.Now);

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }
    }
}