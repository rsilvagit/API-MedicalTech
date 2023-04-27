using System.ComponentModel.DataAnnotations;

namespace MedicalTech.Dto
{
    public class EnfermeiroPutDTO:PessoaPutDTO
    {
        [Required]
        [StringLength(35)]
        public string InstEnsFormacao { get; set; }
        [Required]
        [StringLength(15)]
        public string Cofen { get; set; }
    }
}
