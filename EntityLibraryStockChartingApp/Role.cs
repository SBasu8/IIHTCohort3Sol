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
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public RoleTypes RoleType { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public long Mobile { get; set; }
        public bool Confirmed { get; set; }
    }
}
