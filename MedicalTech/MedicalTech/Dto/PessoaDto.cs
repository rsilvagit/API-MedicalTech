﻿namespace MedicalTech.Dto
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public string Telefone { get; set; }
    }
}