using System.Collections.Generic;
using System.Linq;

namespace TheDevelopersConference.Demonstracao.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterTodosAtivos()
        {
            return _clienteRepository.ObterTodos().Where(c => c.Ativo);
        }

        public void Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Adicionar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}