using System;
using System.Collections.Generic;
using System.Text;

namespace Wayki.Models
{
    public class UserInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; } 
        public bool IsActive { get; set; } 
        public string Dni { get; set; }
    }
}
