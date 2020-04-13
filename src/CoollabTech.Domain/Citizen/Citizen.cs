using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Domain.Citizen
{
    public class Citizen : Entity<Citizen>
    {
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public EGender Gender { get; private set; }
        public DateTime DateRegister { get; private set; }
        public bool Excluded { get; private set; }
        public bool Active { get; private set; }

        public Citizen(
            Guid id, 
            string name, 
            string nickName, 
            string document, 
            string email, EGender gender, DateTime dateRegister, bool excluded, bool active)
        {
            Id = id;
            Name = name;
            NickName = nickName;
            Document = document;
            Email = email;
            Gender = gender;
            DateRegister = dateRegister;
            Excluded = excluded;
            Active = active;
        }

        public Citizen() { }

        public void DeleteCitizen()
        {
            Excluded = true;
        }

        public void NotActive()
        {
            Active = false;
        }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        #region Validations
        private void Validate()
        {
            ValidateName();
            ValidateNickName();
            ValidateDocument();
            ValidateEmail();
            ValidateGender();
            ValidateDateRegister();
            ValidationResult = Validate(this);

        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome precisa ser fornecido")
                .Length(2, 100).WithMessage("O nome precisa ter entre 2 e 100 caracteres");
        }

        private void ValidateNickName()
        {
            RuleFor(c => c.NickName)
                 .NotEmpty().WithMessage("O apelido precisa ser fornecido")
                 .Length(2, 100).WithMessage("O apelido precisa ter entre 2 e 100 caracteres");
        }

        private void ValidateDocument()
        {
            RuleFor(c => c.Document)
                .Length(11).WithMessage("O CPF deve ter 11 digitos");
        }

        private void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("Email inválido");
        }

        private void ValidateGender()
        {
            RuleFor(c => c.Gender).IsInEnum().WithMessage("Escolha Masculino ou Feminino");
            RuleFor(c => c.Gender).NotNull().WithMessage("Escolha Masculino ou Feminino");

        }

        private void ValidateDateRegister()
        {
            RuleFor(c => c.DateRegister)
                .LessThan(DateTime.Now)
                .WithMessage("A data de cadastro não deve ser maior que a data atual");
        }


        #endregion
    }
}
