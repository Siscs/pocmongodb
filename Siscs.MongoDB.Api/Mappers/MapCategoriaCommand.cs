using System;
using System.Collections.Generic;
using Siscs.MongoDB.Api.Domain.Entities;
using Siscs.MongoDB.Api.Dto;

namespace Siscs.MongoDB.Api.Mappers
{
    public static class MapCategoriaCommand
    {
        public static CategoriaDto ToCategoriaDto(this Categoria categoria)
        {
            if(categoria is null)
                return null;
                
            return new CategoriaDto
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao,
                Ativo = categoria.Ativo
            };
        }

        public static Categoria ToCategoriaCommand(this CategoriaDto categoriaDto)
        {
            if(categoriaDto is null)
                return null;

            return new Categoria
            {
                Id = categoriaDto.Id ?? Guid.Empty,
                Descricao = categoriaDto.Descricao,
                Ativo = categoriaDto.Ativo
            };
        }
        public static Categoria ToCreateCategoriaCommand(this CategoriaDto categoriaDto)
        {
            if(categoriaDto is null)
                return null;

            return new Categoria
            {
                Descricao = categoriaDto.Descricao,
                Ativo = categoriaDto.Ativo
            };
        }

        public static List<CategoriaDto> ToListDto(this IEnumerable<Categoria> list)
        {
            List<CategoriaDto> dtolist = new List<CategoriaDto>();

            foreach (var item in list)
            {
                dtolist.Add(item.ToCategoriaDto());
            }

            return dtolist;
        }
        
    }
}