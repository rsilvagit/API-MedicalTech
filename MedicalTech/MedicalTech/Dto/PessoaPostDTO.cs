using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace MedicalTech.Dto
{
    public class PessoaPostDTO
    {
        [MaxLength(50)]
        [StringLength(35)]
        public string? NomeCompleto { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo Data de Nascimento é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:DD.MM.AAAA}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo CPF é obrigatório e precisa ter no minimo 11 caracteres"), MinLength(11)]
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }
}
