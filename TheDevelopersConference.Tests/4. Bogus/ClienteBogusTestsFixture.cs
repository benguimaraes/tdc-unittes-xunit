﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using TheDevelopersConference.Demonstracao.Clientes;
using Xunit;

namespace TheDevelopersConference.Tests.Bogus
{
    [CollectionDefinition(nameof(ClienteBogusCollection))]
    public class ClienteBogusCollection : ICollectionFixture<ClienteBogusTestsFixture>
    {}

    public class ClienteBogusTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarClientes(50, true).ToList());
            clientes.AddRange(GerarClientes(50, false).ToList());

            return clientes;
        }

        public IEnumerable<Cliente> GerarClientes(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var clientes = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(), 
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(80,DateTime.Now.AddYears(-18)),
                    "",
                    ativo,
                    DateTime.Now))
                .RuleFor(c=>c.Email, (f,c) => 
                    f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));

            return clientes.Generate(quantidade);
        }

        public void Dispose()
        {
        }
    }
}