﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MedicalTech.Models
{
    public class MedicalTechContext:DbContext
    {
        public MedicalTechContext(DbContextOptions<MedicalTechContext> options) : base(options) { } 
        public DbSet<Pesssoa> Pesssoas { get; set;}
        public DbSet<Medico> Medicos { get; set;}    
        public DbSet<Paciente> Pacientes { get; set;}
        public DbSet<Enfermeiro> Enfermeiros { get;set;}
    }
}
