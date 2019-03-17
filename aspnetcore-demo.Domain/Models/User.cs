using System;
using System.Collections.Generic;

namespace aspnetcore_demo.Domain.Models
{
    public class User
    {
        private readonly IList<string> _roles = new List<string>();
        private readonly IList<string> _permissions = new List<string>();

        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles => _roles;
        public IEnumerable<string> Permissions => _permissions;

        public string Password { get; set; }
    }
}
