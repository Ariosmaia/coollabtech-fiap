using CoollabTech.Domain.Tickets;
using System;
using Xunit;

namespace CoolabTech.Tests.Domain
{

    public class TicketTests
    {
        [Fact]
        public void ShouldReturnErrorWhenNametIsInvalid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "", "Rua teste, 123", Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            Assert.False(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenNametIsValid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            Assert.True(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenDescriptiontIsInvalid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "", Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            Assert.False(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenDescriptionIsValid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            Assert.True(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenTicketStatusIsInvalid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.Empty, Guid.NewGuid(), DateTime.Now);
            Assert.False(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenTicketStatusIsValid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            Assert.True(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenTicketTypeIsInvalid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.NewGuid(), Guid.Empty, DateTime.Now);
            Assert.False(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenTicketTypeIsValid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            Assert.True(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnErrorWhenDateRegisterIsInvalid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.NewGuid(), Guid.Empty, DateTime.Now.AddDays(1));
            Assert.False(ticket.IsValid());
        }

        [Fact]
        public void ShouldReturnSuccessWhenDateRegisterIsValid()
        {
            var ticket = new Ticket(Guid.NewGuid(), "Chamado teste", "Rua teste, 123", Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
            Assert.True(ticket.IsValid());
        }
    }
}