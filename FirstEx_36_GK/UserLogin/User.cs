using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FacNum { get; set; }

        public UserRoles UserRole { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? DateActive { get; set; }

    public override string ToString()
        {
            string result = Username + " " + Password + " " + FacNum + " " + UserRole;

            return result;
        }

        
    }
}
