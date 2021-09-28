using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicadoresCore.Models
{
    public class Compania
    {
        public decimal IdCompania { get; set; }

        public decimal IdEmpresa { get; set; }

        public decimal IdCompaniaOdoo { get; set; }

        public string Name { get; set; }

        public decimal IdMonedaEmpresaOdoo { get; set; }
        public bool Estado { get; set; }

        public MonedaEmpresa MonedaEmpresaa { get; set; }
    }
}
