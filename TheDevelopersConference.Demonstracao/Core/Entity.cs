using System;
using FluentValidation.Results;

namespace TheDeveloperConference.Demonstracao.Core
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}