using System;
using TheDevelopersConference.Demonstracao.Clientes;
using Xunit;

namespace TheDevelopersConference.Tests.Fixture
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    {}

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Fulano ",
                "Silva",
                DateTime.Now.AddYears(-30),
                "fulano@gmail.com",
                true,
                DateTime.Now);

            return cliente;
        }    

        public void Dispose()
        {
        }
    }
}