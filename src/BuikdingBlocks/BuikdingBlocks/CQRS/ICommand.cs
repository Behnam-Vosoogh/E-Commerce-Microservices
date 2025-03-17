
using MediatR;

namespace BuikdingBlocks.CQRS
{
    // command interface
    public interface ICommand:ICommand<Unit>
    {
        
    }
    // command interface with response
    public interface ICommand<out TResponse> :IRequest<TResponse>
    {
    }
}
