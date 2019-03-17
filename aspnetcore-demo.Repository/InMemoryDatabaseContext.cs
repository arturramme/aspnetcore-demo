using aspnetcore_demo.Domain.Models;
using System.Collections.Generic;

namespace aspnetcore_demo.Repository
{
    public class InMemoryDatabaseContext
    {
        public ISet<User> Users { get; } = new HashSet<User>();
    }
}
