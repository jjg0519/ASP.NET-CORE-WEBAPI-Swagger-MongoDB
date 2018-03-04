using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.Models
{
    public class Projeto {
      
        public Projeto()
        {
            Ativo = true;
        }

        [BsonId]
        public ObjectId __Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public int Versao { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Situacao Situacao { get; set; }
        public Boolean Ativo { get; set; }
    }

    public class Situacao
    {
        public string nome { get; set; }
    }
}