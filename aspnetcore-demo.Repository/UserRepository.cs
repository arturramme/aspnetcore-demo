using aspnetcore_demo.Domain.Interfaces;
using aspnetcore_demo.Domain.Models;

namespace aspnetcore_demo.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Get(string email)
        {
            return new User();
        }
    }
}
