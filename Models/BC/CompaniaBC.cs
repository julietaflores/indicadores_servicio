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
    public class CompaniaBC
    {
        public List<Compania> CargarBE(DataRow[] dr)
        {
            List<Compania> lst = new List<Compania>();
            foreach (var item in dr)
            {
                lst.Add(CargarBE(item));
            }
            return lst;
        }
        public Compania CargarBE(DataRow dr)
        {
            Compania obj = new Compania();

            obj.IdCompania = Convert.ToDecimal(dr["IdCompania"].ToString());
            obj.IdEmpresa = Convert.ToDecimal(dr["IdEmpresa"].ToString());
            obj.IdCompaniaOdoo = Convert.ToDecimal(dr["IdCompaniaOdoo"].ToString());
            obj.Name = dr["Name"].ToString();
            obj.IdMonedaEmpresaOdoo = Convert.ToDecimal(dr["IdMonedaEmpresa"].ToString());
            obj.Estado = Convert.ToBoolean(dr["Estado"].ToString());


            return obj;
        }


        public List<Compania> listaCompaniaxEmoresa(decimal empresaid)
        {
            List<Compania> obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select cp.*  from Compania cp where cp.IdEmpresa={0}", Convert.ToInt32(empresaid));
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

        public Compania datosempresacompania(decimal empresaid, decimal compania)
        {
            Compania obj = null;
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                string sql = String.Format(@"select cp.*  from Compania cp where cp.IdEmpresa={0} and cp.IdCompaniaOdoo={1}", Convert.ToInt32(empresaid), Convert.ToInt32(compania));
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
