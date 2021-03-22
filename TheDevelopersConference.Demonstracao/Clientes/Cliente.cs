using FluentValidation;
using System;
using TheDeveloperConference.Demonstracao.Core;

namespace TheDevelopersConference.Demonstracao.Clientes
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Cliente()
        {
        }

        public Cliente(Guid id, string nome, string sobrenome, DateTime dataNascimento, string email, bool ativo,
            DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Email = email;
            Ativo = ativo;
            DataCadastro = dataCadastro;
        }

        public string NomeCompleto() => $"{Nome} {Sobrenome}";
                
        public void Inativar() => Ativo = false;

        public override bool EhValido()
        {
            //return new ClienteValidacao().Validate(this).IsValid;
            ValidationResult = new ClienteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        public ClienteValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o sobrenome")
                .Length(2, 150).WithMessage("O Sobrenome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}