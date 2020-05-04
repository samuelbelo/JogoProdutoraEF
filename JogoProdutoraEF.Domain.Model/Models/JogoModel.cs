using System;
using System.ComponentModel.DataAnnotations;

namespace JogoProdutoraEF.Domain.Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do jogo é obrigatório.")]
        [StringLength(maximumLength:60, MinimumLength = 10, ErrorMessage = "Digite no mínimo {2} e no máximo {1} caracteres.")]
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de lançamento é obrigatória.")]
        [Display(Name = "Data de lançamento")]
        public DateTime Lancamento { get; set; }
    }
}
