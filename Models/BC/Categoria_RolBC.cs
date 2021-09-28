using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IndicadoresCore.Models;


namespace IndicadoresCore.Models.BC
{
    public class Categoria_RolBC
    {
        public List<Categoria_Rol> CargarBE(DataRow[] dr)
        {
            List<Categoria_Rol> lst = new List<Categoria_Rol>();
            foreach (var item in dr)
            {
                lst.Add(CargarBE(item));
            }
            return lst;
        }
        public Categoria_Rol CargarBE(DataRow dr)
        {
            Categoria_Rol obj = new Categoria_Rol();

            obj.id_categoriaRol = Convert.ToDecimal(dr["Id_categoriaRol"].ToString());
            obj.ID_categoria = Convert.ToDecimal(dr["ID_categoria"].ToString());
            obj.ID_rolUsuario = Convert.ToDecimal(dr["ID_rolUsuario"].ToString());

            return obj;
        }


        public List<Categoria_Rol> listadatoscategoriarolusuario(decimal id_rolusuario)
        {
            List<Categoria_Rol> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select cr.* from Categoria_Rol cr where cr.ID_rolUsuario={0}", Convert.ToInt32(id_rolusuario));
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBE(dr);


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public List<Categoria_Rol> listadatoscategoriarolusuario1(decimal id_rolusuario)
        {
            List<Categoria_Rol> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select cr.* from Categoria_Rol cr where cr.ID_rolUsuario={0}", Convert.ToInt32(id_rolusuario));
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBE(dr);
                    CargarRelaciones_categoria(ref obj);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public void CargarRelaciones_categoria(ref List<Categoria_Rol> obj)
        {

            foreach (var lista1 in obj)
            {
                decimal categoriaid = lista1.ID_categoria;

               CategoriaBC bccategoria = new CategoriaBC("cadenaCnx");

                lista1.categoriass = bccategoria.listadatoscategoriarolusuario1(categoriaid);
                bccategoria = null;


            }


        }

    }
}
