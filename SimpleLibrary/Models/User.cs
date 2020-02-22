using System.Collections.Generic;
using System.Linq;

namespace SimpleLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public bool IsInRole(string role)
        {
            return Roles?.Any(x => x.Name == role) ?? false;
        }
    }
}