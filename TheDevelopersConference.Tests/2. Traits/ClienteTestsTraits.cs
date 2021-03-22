using System;
using TheDevelopersConference.Demonstracao.Clientes;
using Xunit;

namespace TheDevelopersConference.Tests.Traits
{
    public class ClienteTestsTraits
    {
        [Fact(DisplayName = "Traits - Novo Cliente Válido")]
        [Trait("Categoria", "Teste de Unidade")]
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
