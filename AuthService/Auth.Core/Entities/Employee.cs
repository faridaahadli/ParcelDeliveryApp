using Auth.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Entities
{
    public class Employee:BaseEntity
    {        
        public int Status { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
