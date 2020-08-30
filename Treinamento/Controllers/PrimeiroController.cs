using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Http.Description;
using Treinamento.Models;

namespace Treinamento.Controllers
{
    public class PrimeiroController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();


        public List<Cliente> Get()
        {
            return clientes;
        }

        public List<Cliente> Get(string uf)
        {
            List<Cliente> existingUF = new List<Cliente>();

            foreach(Cliente searchingUF in clientes)
            {
                if (searchingUF.UF.Equals(uf))
                    existingUF.Add(searchingUF);
            }
            return existingUF;
        }

        public List<Cliente> Get(int id)
        {
            List<Cliente> existingID = new List<Cliente>();
            
            foreach(Cliente seachingID in clientes)
            {
                if (seachingID.ID.Equals(id))
                    existingID.Add(seachingID);
            }

            return existingID;
        }

        public string Post(int id, string nome, string cpf, string uf, string date)
        {
            clientes.Add(new Cliente(id, nome, cpf, uf, date));

            string save = "Salvo";

            return save;
        }
        //public string Put()

        public void Delete(int id)
        {
            clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.ID.Equals(id))));
        }
    }
}
