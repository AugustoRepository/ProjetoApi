using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApi.Presentation.Models
{
    public class ProdutoConsultaModel
    {
        public string IdProdudo { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Quantidade { get; set; }
        public string Total { get; set; }
        public string DataCadastro { get; set; }
        public string DataUltimaAlteracao { get; set; }
    }
}
