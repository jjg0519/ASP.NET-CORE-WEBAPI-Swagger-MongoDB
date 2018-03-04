using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Contexts;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackEnd.Services
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ScadaContext _context = null;

        public ProjetoRepository(IOptions<Settings> settings)
        {
            _context = new ScadaContext(settings);
        }

        public async  Task<IEnumerable<Projeto>> GetAll()
        {
            try
            {
                return await _context.Projeto.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after internal or internal id
        //
        public async Task<Projeto> GetOne(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Projeto
                                .Find(a => a.__Id == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task AddOne(Projeto item)
        {
            try
            {
                await _context.Projeto.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveOne(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                DeleteResult actionResult = await _context.Projeto.DeleteOneAsync(
                     Builders<Projeto>.Filter.Eq("__Id", internalId));

                return actionResult.IsAcknowledged 
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateAtivo(string id, Boolean Ativo)
        {
            ObjectId internalId = GetInternalId(id);
            var filter = Builders<Projeto>.Filter.Eq(s => s.__Id, internalId);
            var update = Builders<Projeto>.Update
                            .Set(s => s.Ativo, Ativo)
                            .CurrentDate(s => s.UpdatedOn);

            try
            {
                UpdateResult actionResult = await _context.Projeto.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateGeneric(string id, Projeto item)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                ReplaceOneResult actionResult = await _context.Projeto
                                                .ReplaceOneAsync(n => n.__Id.Equals(id)
                                                                , item
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

      
        public async Task<bool> RemoveAll()
        {
            try
            {
                DeleteResult actionResult = await _context.Projeto.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        
    }
}