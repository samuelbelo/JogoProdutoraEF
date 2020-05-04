using JogoProdutoraEF.Domain.Model.Interfaces.Services;
using JogoProdutoraEF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoProdutoraEF.Domain.Model.Interfaces.Repositories;

namespace JogoProdutoraEF.Domain.Service.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(
            IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task DeleteAsync(int id)
        {
            await _jogoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JogoModel>> GetAllAsync()
        {
            return await _jogoRepository.GetAllAsync();
        }

        public async Task<JogoModel> GetByIdAsync(int id)
        {
            return await _jogoRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(JogoModel insertedModel)
        {
            await _jogoRepository.InsertAsync(insertedModel);
        }

        public async Task UpdateAsync(JogoModel updatedModel)
        {
            await _jogoRepository.UpdateAsync(updatedModel);
        }
    }
}