using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTech.Models
{
    [Table("Pessoa")]
    public class Pesssoa
    {
        [Key]
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public string Telefone { get; set;}
    }
}
