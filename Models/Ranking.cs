using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicadoresCore.Models
{
    public class Ranking
    {
        public decimal idPosicion { get; set; }

        public string nombre { get; set; }

        public double precio { get; set; }

        public double importeanterior { get; set; }
        public string porcentajetorta { get; set; }

    }
}
