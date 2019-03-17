using aspnetcore_demo.Domain.Authentication;
using aspnetcore_demo.Domain.Commands;
using aspnetcore_demo.Domain.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace aspnetcore_demo.Domain.CommandHandlers
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateUserCommand, JwtToken>
    {
        public Task<JwtToken> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = "teste",
                Email = "teste@teste.com.br",
                Password = "123"
            };

            var claims = new ClaimsIdentity(
                new GenericIdentity(request.Email),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Name)
                });

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = claims,
                
            });

            var accessToken = handler.WriteToken(securityToken);

            return Task.FromResult(new JwtToken());
        }
    }
}
