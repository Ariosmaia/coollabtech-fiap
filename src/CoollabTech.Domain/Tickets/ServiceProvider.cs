using CoollabTech.Domain.Core.Models;
using FluentValidation;
using System;

namespace CoollabTech.Domain.Tickets
{
    public class ServiceProvider : Entity<ServiceProvider>
    {
        public string Name { get; set; }
        public DateTime DateRegister { get; set; }

        public ServiceProvider(Guid id, string name, DateTime dateRegister)
        {
            Id = id;
            Name = name;
            DateRegister = dateRegister;
        }

        public ServiceProvider() { }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidateDateRegister();
            ValidationResult = Validate(this);

        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome precisa ser fornecido")
                .Length(2, 100).WithMessage("O nome precisa ter entre 2 e 100 caracteres");
        }

        private void ValidateDateRegister()
        {
            RuleFor(c => c.DateRegister)
                .LessThan(DateTime.Now)
                .WithMessage("A data de cadastro não deve ser maior que a data atual");
        }

    }
}