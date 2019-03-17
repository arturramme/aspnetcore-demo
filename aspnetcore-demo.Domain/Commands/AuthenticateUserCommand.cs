using aspnetcore_demo.Domain.Authentication;
using MediatR;

namespace aspnetcore_demo.Domain.Commands
{
    public class AuthenticateUserCommand : IRequest<JwtToken>
    {
        public string Email { get; }
        public string Password { get; }
        public string GrantType { get; }
        public string RefreshToken { get; }
    }
}
