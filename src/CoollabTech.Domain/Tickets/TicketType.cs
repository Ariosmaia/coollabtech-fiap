using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoollabTech.Domain.Tickets
{
    public class TicketType : Entity<TicketType>
    {
        public string Name { get; set; }
        public Guid ServiceProviderId { get; set; }
        public DateTime DateRegister { get; set; }

        /* EF Relation */
        [NotMapped]
        public ServiceProvider ServiceProvider { get; set; }

        public TicketType(Guid id, string name, Guid serviceProviderId, DateTime dateRegister)
        {
            Id = id;
            Name = name;
            ServiceProviderId = serviceProviderId;
            DateRegister = dateRegister;
        }

        public TicketType() { }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidateServiceProvider();
            ValidateDateRegister();
            ValidationResult = Validate(this);
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome precisa ser fornecido")
                .Length(2, 100).WithMessage("O nome precisa ter entre 2 e 100 caracteres");
        }

        private void ValidateServiceProvider()
        {
            RuleFor(c => c.ServiceProviderId)
                .NotEmpty().WithMessage("O prestador precisa ser fornecido");
        }

        private void ValidateDateRegister()
        {
            RuleFor(c => c.DateRegister)
                .LessThan(DateTime.Now)
                .WithMessage("A data de cadastro não deve ser maior que a data atual");
        }
    }
}
