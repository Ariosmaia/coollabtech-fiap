using CoollabTech.Domain.Core.Events;

namespace CoollabTech.Domain.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}
