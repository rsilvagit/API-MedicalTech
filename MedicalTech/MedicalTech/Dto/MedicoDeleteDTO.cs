﻿using MedicalTech.Enum;
using System.ComponentModel.DataAnnotations;

namespace MedicalTech.Dto
{
    public class MedicoDeleteDTO:PessoaDeleteDTO
    {
        [Required]
        [StringLength(100)]
        public string InstEnsinoForm { get; set; }
        [Required]
        [StringLength(20)]
        public string Crm { get; set; }
        [Required]
        [MaxLength(20)]
        public EspClinicaEnum EspClinica { get; set; }
        [MaxLength(10)]
        public StatusSistemaEnum StatusSistema { get; set; }
        [MaxLength]
        public int TotalAtendimentos { get; set; }
    }
}
