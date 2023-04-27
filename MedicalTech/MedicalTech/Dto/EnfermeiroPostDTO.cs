using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace MedicalTech.Dto
{
    public class EnfermeiroPostDTO:PessoaPostDTO
    {
        [Required(ErrorMessage ="InstEnsFormacao não preenchido ou com dados inválidos")]
        [StringLength(35)]
        public string InstEnsFormacao { get; set; }
        [Required(ErrorMessage ="Cofen não preenchido ou com dados inválidos ")]
        [StringLength(15)]
        public string Cofen { get; set; }

        
    }
}
