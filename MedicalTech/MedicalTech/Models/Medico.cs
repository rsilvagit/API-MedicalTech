using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;
using MedicalTech.Enumerador;

namespace MedicalTech.Models
{
    [Table("Medico")]
    public class Medico:Pesssoa
    {
        
        [StringLength(100)]
       public string InstEnsinoForm { get; set; }
        
        [StringLength(20)]
       public string Crm { get; set; }
        
       
       public EspClinicaEnum EspClinica { get; set; }
        
       public StatusSistemaEnum StatusSistema { get; set; }
        [MaxLength]
       public int TotalAtendimentos { get; set; }
       
    }
}
