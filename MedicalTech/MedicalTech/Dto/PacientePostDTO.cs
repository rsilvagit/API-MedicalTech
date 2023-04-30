using MedicalTech.Enum;
using System.ComponentModel.DataAnnotations;

namespace MedicalTech.Dto
{
    public class PacientePostDTO : PessoaPostDTO
    {
        [Required(ErrorMessage ="O preenchimento do campo Contato de Emergência é obrigatório",AllowEmptyStrings =false)]
        [StringLength(25)]
        public string ContatoDeEmergencia { get; set; }
        [MaxLength]
        public List <string> ListaDeAlergias { get; set; }
        [MaxLength]
        public List <string> ListaCuidadosEspecificos { get; set; }
        [StringLength(25)]
        public string Convenio { get; set; }
        [MaxLength]
        public StatusAtendimentoEnum StatusAtendimento { get; set; }
        [MaxLength]
        public int ContadorTotalAtendimentos { get; set; }
    }
}

