using JogoProdutoraEF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoProdutoraEF.Domain.Model.Interfaces.Services
{
    public interface IJogoService
    {
        Task<IEnumerable<JogoModel>> GetAllAsync();
        Task<JogoModel> GetByIdAsync(int id);
        Task UpdateAsync(JogoModel updatedModel);
        Task InsertAsync(JogoModel insertedModel);
        Task DeleteAsync(int id);
    }
}
