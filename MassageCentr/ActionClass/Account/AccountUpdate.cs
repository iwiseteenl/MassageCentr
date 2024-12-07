using System.ComponentModel.DataAnnotations;

namespace MassageCentr.ActionClass.Account
{
    public class AccountUpdate
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
    }
}
