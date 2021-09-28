using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicadoresCore.Models
{
    public class Categoria_Rol
    {
        public decimal id_categoriaRol { get; set; }

        public decimal ID_categoria { get; set; }
        public decimal ID_rolUsuario { get; set; }

        public Categoria categoriass { get; set; }
    }
}
