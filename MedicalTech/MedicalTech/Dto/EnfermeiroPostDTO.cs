using System.ComponentModel.DataAnnotations;

namespace MedicalTech.Dto
{
    public class EnfermeiroPostDTO:PessoaPostDTO
    {
        [Required]
        [StringLength(35)]
        public string InstEnsFormacao { get; set; }
        [Required]
        [StringLength(15)]
        public string Cofen { get; set; }
    }
}
