using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;
using MedicalTech.Enum;

namespace MedicalTech.Models
{
    [Table("Medico")]
    public class Medico:Pesssoa
    {
       public string InstEnsinoForm { get; set; }
       public string? Crm { get; set; }
        public EspClinicaEnum EspClinica { get; set; }
       public StatusSistemaEnum StatusSistema { get; set; }
       public int TotalAtendimentos { get; set; }

    }
}
