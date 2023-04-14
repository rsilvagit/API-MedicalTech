using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalTech.Models
{
    [Table("Pessoa")]
    public class Pesssoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Cpf { get; set; } //unique
        public string Telefone { get; set;}
    }
}
