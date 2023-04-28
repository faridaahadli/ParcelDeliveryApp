using Auth.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Entities
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<UserToRole> UserToRoles { get; set; }
    }
}
