﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscs.MongoDB.Api.Dto
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid? CategoriaId { get; set; }
        public ProdutoCategoriaDto Categoria { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
    }

    public class ProdutoCategoriaDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
