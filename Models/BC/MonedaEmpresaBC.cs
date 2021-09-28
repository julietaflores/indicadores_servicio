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
    public class MonedaEmpresaBC
    {
        public List<MonedaEmpresa> CargarBE(DataRow[] dr)
        {
            List<MonedaEmpresa> lst = new List<MonedaEmpresa>();
            foreach (var item in dr)
            {
                lst.Add(CargarBE(item));
            }
            return lst;
        }
        public MonedaEmpresa CargarBE(DataRow dr)
        {
            MonedaEmpresa obj = new MonedaEmpresa();

            obj.MonedaId = Convert.ToDecimal(dr["MonedaId"].ToString());
            obj.IdEmpresa = Convert.ToDecimal(dr["IdEmpresa"].ToString());
            obj.IdMonedaEmpresaOdoo = Convert.ToDecimal(dr["IdMonedaOdoo"].ToString());
            obj.Name = dr["Name"].ToString();
            obj.Symbol = dr["Symbol"].ToString();
            obj.Rate = Convert.ToDouble(dr["Rate"].ToString());
            obj.Estado = Convert.ToBoolean(dr["Estado"].ToString());


            return obj;
        }


        public List<MonedaEmpresa> listamonedaxempresa(decimal empresaid)
        {
            List<MonedaEmpresa> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select mm.*  from MonedaEmpresa mm where mm.IdEmpresa={0}", Convert.ToInt32(empresaid));
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


        public MonedaEmpresa datosempresamoneda(decimal empresaid, decimal moneda)
        {
            MonedaEmpresa obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select mm.*  from MonedaEmpresa mm where mm.IdEmpresa={0}  and mm.IdMonedaOdoo={1}", Convert.ToInt32(empresaid), Convert.ToInt32(moneda));
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
