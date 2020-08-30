using System;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;

namespace Treinamento.Models
{
    public class Cliente
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string CPF { get; set; }
        
        [Required]
        public string UF { get; set; }
        
        [Required]
        public string Date { get; set; }

        public Cliente(int id, string nome, string cpf, string uf, string date)
        {
            this.ID = id;
            this.Nome = nome;
            this.CPF = cpf;
            this.UF = uf;
            this.Date = date;
        }
       
    }
}