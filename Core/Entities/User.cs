using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : Entity<int>
    {
        // GENEL USER FIELDLARI
        public int RoleId { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Approved { get; set; }
        public Role Role { get; set; }
    }
}