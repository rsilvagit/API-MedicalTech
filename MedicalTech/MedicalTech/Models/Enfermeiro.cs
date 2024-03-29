﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;

namespace MedicalTech.Models
{
    [Table("Enfermeiro")]
    public class Enfermeiro:Pesssoa
    {
        [Required]
        [StringLength(35)]
        public string InstEnsFormacao { get; set; }
        [Required]
        [StringLength(15)]
        public string Cofen { get; set; }
    }
}
