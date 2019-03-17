using MediatR;

namespace aspnetcore_demo.Domain.Commands
{
    public class RegisterNewCustomerCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
