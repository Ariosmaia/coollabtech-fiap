using CoollabTech.Domain.Core.Commands;
using CoollabTech.Domain.Core.Events;
using System.Threading.Tasks;

namespace CoollabTech.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task SendCommand<T>(T comando) where T : Command;
    }
}
