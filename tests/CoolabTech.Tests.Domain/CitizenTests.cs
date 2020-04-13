using CoollabTech.Domain.Citizen;
using CoollabTech.Domain.Citizen.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoolabTech.Tests.Domain
{
    
    public class CitizenTests
    {
        [Fact]
        public void ShouldReturnErrorWhenNametIsInvalid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "", "ariosmaia", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.False(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenNametIsValid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.True(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenNickNametIsInvalid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.False(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenNickNametIsValid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.True(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenDocumentIsInvalid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345", "ariosgmail", EGender.Masculino, DateTime.Now, false, true);
            Assert.False(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenDocumentIsValid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.True(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenEmailIsInvalid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345678945", "ariosgmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.False(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenEmailIsValid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.True(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenDateRegisterIsInvalid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.True(citizen.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenDateRegisterIsValid()
        {
            var citizen = new Citizen(Guid.NewGuid(), "Allan", "ariosmaia", "12345678945", "arios@gmail.com", EGender.Masculino, DateTime.Now, false, true);
            Assert.True(citizen.IsValid());
        }
    }
}