using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferCommand
{
    public class RegisterUserDto
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
