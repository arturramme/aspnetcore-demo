using aspnetcore_demo.Domain.Models;

namespace aspnetcore_demo.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Get(string email);
    }
}
