using Siscs.MongoDB.Api.Domain.Entities;
using Siscs.MongoDB.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscs.MongoDB.Api.Mappers
{
    public static class MapProdutoCommand
    {
        public static ProdutoDto ToProdutoDto(this Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                CategoriaId = produto.CategoriaId,
                Categoria = produto.Categoria.ToCategoriaDto(),
                Descricao = produto.Descricao,
                Valor = produto.Valor
            };
        }

        public static Produto ToProdutoCommand(this ProdutoDto dto)
        {
            return new Produto
            {
                Id = dto.Id,
                Nome = dto.Nome,
                CategoriaId = dto.CategoriaId,
                Descricao = dto.Descricao,
                Valor = dto.Valor
            };
        }
         public static Produto ToCreateProdutoCommand(this ProdutoDto dto)
        {
            return new Produto
            {
                Nome = dto.Nome,
                CategoriaId = dto.CategoriaId,
                Descricao = dto.Descricao,
                Valor = dto.Valor
            };
        }

        public static List<ProdutoDto> ToListDto(this IEnumerable<Produto> list)
        {
            List<ProdutoDto> dtolist = new List<ProdutoDto>();

            foreach (var item in list)
            {
                dtolist.Add(item.ToProdutoDto());
            }

            return dtolist;
        }

    }
}
