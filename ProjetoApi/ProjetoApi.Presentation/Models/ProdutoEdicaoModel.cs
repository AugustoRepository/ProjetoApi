using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoApi.Presentation.Models
{
    public class ProdutoEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do produto.")]
        public string IdProduto { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informeno mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informeno máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public string Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public string Quantidade { get; set; }
    }
}
