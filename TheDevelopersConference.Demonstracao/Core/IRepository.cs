using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TheDeveloperConference.Demonstracao.Core
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);
        IEnumerable<TEntity> ObterTodos();       
    }
}