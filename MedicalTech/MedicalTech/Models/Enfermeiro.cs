using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;

namespace MedicalTech.Models
{
    [Table("Enfermeiro")]
    public class Enfermeiro:Pesssoa
    {
        [Required]
        public string? InstEnsFormacao { get; set; }
        [Required]
        public string? Cofen { get; set; }
    }
}
