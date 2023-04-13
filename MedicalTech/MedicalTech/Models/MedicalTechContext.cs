using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MedicalTech.Dto;

namespace MedicalTech.Models
{
    public class MedicalTechContext:DbContext
    {
        public MedicalTechContext(DbContextOptions<MedicalTechContext> options) : base(options) { } 
        public DbSet<Pesssoa> Pesssoas { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pesssoa>().HasIndex(p => new { p.Cpf }).IsUnique(true);
        }
        public DbSet<Medico> Medicos { get; set;}    
        public DbSet<Paciente> Pacientes { get; set;}
        public DbSet<Enfermeiro> Enfermeiros { get;set;}
        public DbSet<MedicalTech.Dto.PessoaDto> PessoaDto { get; set; } = default!;
    }
}
