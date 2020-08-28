using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLibraryStockChartingApp
{
    public class Role
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

        //Value properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public RoleTypes RoleType { get; set; }
        public bool Confirmed { get; set; }
        [Required]
        public EmailAddressAttribute Email { get; set; }
        [Required]
        public PhoneAttribute PhoneNo { get; set; }
    }
}
