using System.ComponentModel.DataAnnotations;

namespace MassageCentr.ActionClass.HelperClass
{
    public class PersonDTO
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; internal set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
