using System.ComponentModel.DataAnnotations;

namespace MassageCentr.ActionClass.Account
{
    public class AccountCreate
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
