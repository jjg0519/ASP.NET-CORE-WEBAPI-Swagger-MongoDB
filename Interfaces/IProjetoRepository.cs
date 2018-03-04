using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interfaces
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> GetAll();
        Task<Projeto> GetOne(string id);

        // add new note document
        Task AddOne(Projeto Projeto);

        // remove a single document / note
        Task<bool> RemoveOne(string id);

        // update just a single document / note
        Task<bool> UpdateAtivo(string id, Boolean Ativo);

        // demo interface - full document update
        Task<bool> UpdateGeneric(string id, Projeto item);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAll();

       
    }
}