using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Siscs.MongoDB.Api.Domain.Entities;

namespace Siscs.MongoDB.Api.Infrastructure.Data.MongoContext
{
    public class MongoDbContextSeed
    {
        public static void SeedData(IMongoCollection<Produto> collection)
        {
            bool existsItens = collection.Find(p => true).Any();

            if (!existsItens)
            {
                collection.InsertManyAsync(GerarProdutosIniciais());
            }
        }

        private static List<Produto> GerarProdutosIniciais()
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto
                {
                    Nome = "Caneta bic azul",
                    Categoria = null, // canetas
                    Descricao = "Caneta esferográfica azul",
                    Imagem = null,
                    Valor = 3.20M
                },
                new Produto
                {
                    Nome = "Caneta bic vermelha",
                    Categoria = null, // canetas,
                    Descricao = "Caneta esferográfica vermelha",
                    Imagem = null,
                    Valor = 3.50M
                },
                new Produto
                {
                    Nome = "Caneta bic preta",
                    Categoria = null, // canetas,
                    Descricao = "Caneta esferográfica preta",
                    Imagem = null,
                    Valor = 3.15M
                },
                new Produto
                {
                    Nome = "Caderno brochura 50fls",
                    Categoria = null, // cadernos,
                    Descricao = "Caderno tipo brochura capa dura 50fls",
                    Imagem = null,
                    Valor = 24.15M
                },
                new Produto
                {
                    Nome = "Caderno brochura 100fls",
                    Categoria = null, // cadernos,
                    Descricao = "Caderno tipo brochura capa dura 100fls",
                    Imagem = null,
                    Valor = 48.73M
                },
                new Produto
                {
                    Nome = "Caderno brochura 10 materias 500fls",
                    Categoria = null, // cadernos,
                    Descricao = "Caderno tipo brochura capa dura 500fls 10 materias",
                    Imagem = null,
                    Valor = 75.32M
                }
            };

            return produtos;
        }

        public static void SeedData(IMongoCollection<Categoria> collection)
        {
            bool existsItens = collection.Find(p => true).Any();

            if (!existsItens)
            {
                collection.InsertManyAsync(GerarCategorias());
            }
        }

        private static List<Categoria> GerarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>
            {
                new Categoria
                {
                    Descricao = "Canetas",
                    Ativo = true
                },
                new Categoria
                {
                    Descricao = "Cadernos",
                    Ativo = true
                },
                new Categoria
                {
                    Descricao = "Lapis",
                    Ativo = true
                }
            };

            return categorias;
        }

    }
}
