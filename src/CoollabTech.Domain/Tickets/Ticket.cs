using CoollabTech.Domain.Core.Models;
using FluentValidation;
using System;

namespace CoollabTech.Domain.Tickets
{
    public class Ticket : Entity<Ticket>
    {
        public string Description { get; set; }
        public string Localization { get; set; }
        public Guid TicketStatusId { get; set; }
        public Guid TicketTypeId { get; set; }
        public DateTime DateRegister { get; set; }

        /* EF Relation */
        public virtual TicketStatus TicketStatus { get; set; }

        public virtual TicketType TicketType { get; set; }

        public Ticket(Guid id, string description, string localization, Guid ticketStatusId, Guid ticketTypeId, DateTime dateRegister)
        {
            Id = id;
            Description = description;
            Localization = localization;
            TicketStatusId = ticketStatusId;
            TicketTypeId = ticketTypeId;
            DateRegister = dateRegister;
        }

        public Ticket() { }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateDescription();
            ValidateLocalization();
            ValidateTicketStatus();
            ValidateTicketType();
            ValidateDateRegister();
            ValidationResult = Validate(this);

        }

        private void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("O nome precisa ser fornecido")
                .Length(2, 100).WithMessage("O nome precisa ter entre 2 e 100 caracteres");
        }

        private void ValidateLocalization()
        {
            RuleFor(c => c.Localization)
                 .NotEmpty().WithMessage("A localização precisa ser fornecida");
        }

        private void ValidateTicketStatus()
        {
            RuleFor(c => c.TicketStatusId)
                .NotEmpty().WithMessage("O status precisa ser fornecido");
        }

        private void ValidateTicketType()
        {
            RuleFor(c => c.TicketTypeId)
                .NotEmpty().WithMessage("O tipo precisa ser fornecido");
        }

        private void ValidateDateRegister()
        {
            RuleFor(c => c.DateRegister)
                .LessThan(DateTime.Now)
                .WithMessage("A data de cadastro não deve ser maior que a data atual");
        }
    }
}
