using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IIHTSolClassLibrary
{
    class User_DB_Table
    {
        /*
1. Id
2. Username
3. Password
4. UserType(if Admin or normal User)
5. E-mail
6. Mobile number
7. Confirmed
         */
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //public IEnumerable UserType { get; set; } - I think we can IEnumerable
        public string UserType { get; set; }
        public EmailAddressAttribute Email { get; set; }  // Different Type - EmailAddressAttribute - validates if input is email 
        public PhoneAttribute PhoneNo { get; set; } //Different Type - PhoneAttribute - validates if input is phone no.
        public bool Confirmed { get; set; }
    }
}
