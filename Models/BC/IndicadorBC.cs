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
    public class IndicadorBC
    {
        public IndicadorBC() : base()
        {
        }

        public IndicadorBC(string cadConx)
        {

        }
        public ClaseConexion dbConexion { get; set; }


        public List<Indicador> CargarBE(DataRow[] dr)
        {
            List<Indicador> lst = new List<Indicador>();
            foreach (var item in dr)
            {
                lst.Add(CargarBE(item));
            }
            return lst;
        }
        public Indicador CargarBE(DataRow dr)
        {
            Indicador obj = new Indicador();

            obj.idIndicador = Convert.ToDecimal(dr["idIndicador"].ToString());
            obj.nombreIndicador = dr["nombreIndicador"].ToString();
            obj.estadoIndicador = Convert.ToBoolean(dr["estadoIndicador"].ToString());
            obj.IDTablero = Convert.ToDecimal(dr["IDtablero"].ToString());

            return obj;
        }


        public List<Indicador> listadatosindricaresxtablero(decimal idtablero)
        {
            List<Indicador> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select i.* from Indicador i where i.IDtablero={0}", Convert.ToInt32(idtablero));
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


        public Indicador datosindicador(decimal indicadorid)
        {
            Indicador obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select ii.* from Indicador ii where ii.IdIndicador={0}", Convert.ToInt32(indicadorid));
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
