using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
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

        //Busca todos os clientes cadastrados
        public List<Cliente> Get()
        {
            return clientes;
        }

        //Busca todos os clientes pela UF procurada
        public List<Cliente> Get(string uf)
        {
            var existingUF = clientes.FindAll(
               delegate (Cliente cli)
               {
                   return cli.UF.Equals(uf);
               }
               );
            return existingUF;
        }

        //Busca o cliente com o ID procurado
        public IHttpActionResult Get(int id)
        {
            //Conferindo se o ID esta na lista
            var existingID = clientes.FirstOrDefault((p) => p.ID == id);
            if (existingID == null)
            {
                return Content(HttpStatusCode.NotFound, "ID não encontrado.");
            }
            return Ok(existingID);
        }

        //Cadastra um cliente
        public IHttpActionResult Post(int id, string nome, string cpf, string uf, string date)
        {
            //Um Boolean para verificar se o ID já foi cadastrado
            Boolean IDverification = clientes.Exists(x => x.ID.Equals(id));
            int? insertionID = id;
            
            if ((IDverification == false) && insertionID.HasValue)
            {
                //Verificando se todos os campos estão preenchidos
                if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(cpf) && !string.IsNullOrEmpty(uf) && !string.IsNullOrEmpty(date))
                {
                    clientes.Add(new Cliente(id, nome, cpf, uf, date));

                    return Ok("Salvo com sucesso!");
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Preencha todos os campos: Nome, CPF, UF, Data!!");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "ID já cadastrado, confira o seu valor.");
            }
        }

        //Atualiza os dados do cliente respectivo do ID
        public IHttpActionResult Put(int id, string nome, string cpf, string uf, string date)
        {
            //Buscando o ID, verificando a sua posição na lista 
            var alterationID = clientes.Find(p => p.ID == id);
            int alterationIDX = clientes.IndexOf(alterationID);

            //Se o ID não for encontrado ele terá um index negativo
            if (alterationIDX <= -1)
                return Content(HttpStatusCode.NotFound, "ID não encontrado.");
            
            if (!string.IsNullOrEmpty(nome))
                clientes[alterationIDX].Nome = nome;

            if(!string.IsNullOrEmpty(cpf))
                clientes[alterationIDX].CPF = cpf;
            
            if(!string.IsNullOrEmpty(uf))
                clientes[alterationIDX].UF = uf;
            
            if(!string.IsNullOrEmpty(date))
                clientes[alterationIDX].Date = date;

            return Ok(clientes[alterationIDX]);
        }

        //Deleta os dados de um cliente pelo ID
        public IHttpActionResult Delete(int id)
        {
            //Buscando o ID desejado e verificando se esta na lista
            var existingID = clientes.FirstOrDefault((p) => p.ID == id);
            if (existingID == null)
            {
                return Content(HttpStatusCode.NotFound, "ID não encontrado.");
            } else
            {
                clientes.Remove(existingID);
                return Ok("Deletado com sucesso!");
            }


        }
    }
}
