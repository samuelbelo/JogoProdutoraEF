using JogoProdutoraEF.Domain.Model.Interfaces.Repositories;
using JogoProdutoraEF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JogoProdutoraEF.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogoProdutoraContext _context;

        public JogoRepository(JogoProdutoraContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var jogoModel = await _context.Jogos.FindAsync(id);
            _context.Jogos.Remove(jogoModel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JogoModel>> GetAllAsync()
        {
            return await _context.Jogos.ToListAsync();
            ;
        }

        public async Task<JogoModel> GetByIdAsync(int id)
        {
            return await _context.Jogos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(JogoModel insertedModel)
        {
            _context.Add(insertedModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JogoModel updatedModel)
        {
            _context.Update(updatedModel);
            await _context.SaveChangesAsync();
        }
    }
}