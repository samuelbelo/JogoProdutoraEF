using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoProdutoraEF.Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Lancamento { get; set; }
    }
}
