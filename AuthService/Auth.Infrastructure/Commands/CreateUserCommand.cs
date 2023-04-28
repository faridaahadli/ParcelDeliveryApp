using Auth.Core.Interfaces.Commands;
using Auth.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Commands
{
    public class CreateUserCommand:ICommand<CreateUserResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsCourier { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
