using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscs.MongoDB.Api.DTO
{
    public class DespesaDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Documento { get; set; }
        public int Parcela { get; set; }
        public double Valor { get; set; }
        public DateTime? Vencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public double ValorPago { get; set; }
        public string Descricao { get; set; }
    }
}
