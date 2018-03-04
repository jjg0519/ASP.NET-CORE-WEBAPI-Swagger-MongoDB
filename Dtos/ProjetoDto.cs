using System;
using MongoDB.Bson;

namespace BackEnd.Dtos
{
    public class ProjetoDto
    {
        public ObjectId __Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Versao { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Boolean Ativo { get; set; }
    }
}