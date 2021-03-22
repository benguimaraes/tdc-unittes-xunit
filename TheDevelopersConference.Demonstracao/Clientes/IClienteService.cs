using System;
using System.Collections.Generic;

namespace TheDevelopersConference.Demonstracao.Clientes
{
    public interface IClienteService : IDisposable
    {
        void Adicionar(Cliente cliente);       
        IEnumerable<Cliente> ObterTodosAtivos();
    }
}