using System;
using System.ComponentModel.DataAnnotations;

namespace Treinamento.Models
{
    public class Cliente
    {

        public int ID { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string UF { get; set; }
        
        public string Date { get; set; }

        public Cliente(int id, string nome, string cpf, string uf, string date)
        {
            this.ID = id;
            this.Nome = nome;
            this.CPF = cpf;
            this.UF = uf;
            this.Date = date;
            Console.WriteLine(date);
        }
       
    }
}