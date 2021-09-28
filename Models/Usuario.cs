using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IndicadoresCore.Models
{
    public class Usuario
    {
        [Key]
        public decimal idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string usuario { get; set; }
        public string passwordd { get; set; }
        public DateTime fechacreacionusuario { get; set; }
        public decimal IDRolUsuario { get; set; }
        public decimal CodIdioma { get; set; }
        public bool Estado { get; set; }
        public List<Categoria_Rol> categoria_roll { get; set; }
        public List<Compania> Companiaa { get; set; }
        public List<MonedaEmpresa> Monedass { get; set; }
    }
}
