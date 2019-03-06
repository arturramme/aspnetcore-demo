using aspnetcore_demo.Domain.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace aspnetcore_demo.Domain.CommandHandlers
{
    public class CustomerCommandHandler : IRequestHandler<RegisterNewCustomerCommand, bool>
    {
        public Task<bool> Handle(RegisterNewCustomerCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
