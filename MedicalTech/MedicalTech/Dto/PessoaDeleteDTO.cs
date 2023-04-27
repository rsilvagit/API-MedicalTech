using Azure.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace MedicalTech.Dto
{
    public class PessoaDeleteDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        [Required]
        public DateTime DataNascimento { get ; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        
         
    }
    
}
