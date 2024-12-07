using System.ComponentModel.DataAnnotations;

namespace MassageCentr.ActionClass.HelperClass
{
    public class AccountUpdateDTO
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
