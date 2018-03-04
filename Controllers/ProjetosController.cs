using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Dtos;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProjetosController : Controller
    {
        private readonly IProjetoRepository _projetoRepository;
        public ProjetosController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Projeto>> Get()
        {
            return await _projetoRepository.GetAll();
        }

        
        [HttpGet("{id}")]
        public async Task<Projeto> Get(string id)
        {
            return await _projetoRepository.GetOne(id) ?? new Projeto();
        }

        // POST api/notes
        [HttpPost]
        public void Post([FromBody] ProjetoDto dto)
        {
            _projetoRepository.AddOne(new Projeto
                                        {
                                            Nome = dto.Nome,
                                            Descricao = dto.Descricao,
                                            Versao = dto.Versao,
                                            CreatedOn = DateTime.Now,
                                            UpdatedOn = DateTime.Now,
                                            Ativo = true
                                        });
        }

        
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Projeto item)
        {
            _projetoRepository.UpdateGeneric(id, item);
        }

       
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _projetoRepository.RemoveOne(id);
        }
    }
}
