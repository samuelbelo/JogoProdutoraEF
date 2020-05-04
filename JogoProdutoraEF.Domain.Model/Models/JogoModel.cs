using System;
using System.ComponentModel.DataAnnotations;

namespace JogoProdutoraEF.Domain.Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        
        public DateTime Lancamento { get; set; }
    }
}
