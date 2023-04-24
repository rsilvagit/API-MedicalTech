using MedicalTech.Enum;
using Microsoft.Build.Framework;

namespace MedicalTech.Dto
{
    public class PacientePutStatusDTO
    {
        [Required]        
        public StatusAtendimentoEnum StatusAtendimento { get; set; }
        
   
    }
}
