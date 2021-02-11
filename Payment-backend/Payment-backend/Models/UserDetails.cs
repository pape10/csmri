using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_backend.Models
{
    public class UserDetails
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string userAdd { get; set; }
        public  string UserState { get; set; }

        public string UserCountry { get; set; }

        public string ReferredPersonName { get; set; }
        public string ReferredPersonMail { get; set; }

        public int ZIP { get; set; }

    }
}
