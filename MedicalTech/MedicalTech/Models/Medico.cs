using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;

namespace MedicalTech.Models
{
    [Table("Medico")]
    public class Medico:Pesssoa
    {
       public string InstEnsinoForm { get; set; }
       public string? Crm { get; set; }
        public string? EspClinica { get; set; }
       public bool StatusSistema { get; set; }
       public int TotalAtendimentos { get; set; }

    }
}
