using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicadoresCore.Models
{
    public class MonedaEmpresa
    {
        public decimal MonedaId { get; set; }

        public decimal IdEmpresa { get; set; }

        public decimal IdMonedaEmpresaOdoo { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double Rate { get; set; }
        public bool Estado { get; set; }
    }
}
