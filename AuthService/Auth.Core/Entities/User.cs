using Auth.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserToRole> UserToRoles { get; set; }=new List<UserToRole>();
        public virtual Employee Employee { get; set; }
    }
}
