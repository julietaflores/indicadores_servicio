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
    public class TableroBC
    {
        public TableroBC() : base()
        {
        }

        public TableroBC(string cadConx)
        {

        }
        public ClaseConexion dbConexion { get; set; }


        public List<Tablero> CargarBE(DataRow[] dr)
        {
            List<Tablero> lst = new List<Tablero>();
            foreach (var item in dr)
            {
                lst.Add(CargarBE(item));
            }
            return lst;
        }
        public Tablero CargarBE(DataRow dr)
        {
            Tablero obj = new Tablero();

            obj.idTablero = Convert.ToDecimal(dr["idTablero"].ToString());
            obj.nombreTablero = dr["nombreTablero"].ToString();
            obj.estadoTablero = Convert.ToBoolean(dr["estadoTablero"].ToString());
            obj.urlTablero = dr["urlTablero"].ToString();
            obj.IdCategoria = Convert.ToDecimal(dr["IdCategoria"].ToString());

            return obj;
        }


        public List<Tablero> listadatostablero(decimal id_categoria)
        {
            List<Tablero> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select tb.* from Tablero  tb where tb.IdCategoria={0}", Convert.ToInt32(id_categoria));
                DataRow[] dr = conx.ObtenerFilas(sql);
                if (dr != null)
                {
                    obj = CargarBE(dr);

                    CargarRelacionesindicadores(ref obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }


        public void CargarRelacionesindicadores(ref List<Tablero> obj)
        {

            foreach (var lista1 in obj)
            {
                decimal tableroid = lista1.idTablero;

                IndicadorBC bcIndicador = new BC.IndicadorBC("cadenaCnx");

                lista1.indicadores = bcIndicador.listadatosindricaresxtablero(tableroid);
                bcIndicador = null;


            }
        }


        public Tablero datostableroid(decimal idtablero)
        {
            Tablero obj = new Tablero();
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select t.* from Tablero t where t.idTablero={0}", Convert.ToInt32(idtablero));
                DataRow dr = conx.ObtenerFila(sql);
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



    }
}
