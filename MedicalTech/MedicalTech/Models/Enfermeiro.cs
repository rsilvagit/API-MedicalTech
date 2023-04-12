using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTech.Models
{
    [Table("Enfermeiro")]
    public class Enfermeiro:Pesssoa
    {
        public string? InstEnsFormacao { get; set; }
        public string? Cofen { get; set; }
    }
}
