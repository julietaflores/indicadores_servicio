using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IndicadoresCore.Models.BC;
using System.Runtime.ExceptionServices;

namespace IndicadoresCore.Models.tabla_9_primero_indicadores
{
    public class Gross_Margin_5
    {
        string con = "Server=181.188.133.118,20200;Initial Catalog=BTCANALYTICS;Persist Security Info=False;User ID=URBBGN;Password=Bantic310188";
        IndicadorBC indicadorBC = new IndicadorBC();



        public Devolucion devolver_gross_margin_5(int anioant, int anio, string mes, Compania compania1, int compania, decimal idDB, MonedaEmpresa moneda1)
        {
            SqlConnection conexion = new SqlConnection(con);
            Devolucion devolucion = new Devolucion();
            Indicador indicadorf = new Indicador();
            indicadorf = indicadorBC.datosindicador(4);
            devolucion.idIndicador = indicadorf.idIndicador;
            devolucion.nombreIndicador = indicadorf.nombreIndicador;
            devolucion.vs = anioant.ToString();


            if (conexion.State != ConnectionState.Open) conexion.Open();
            SqlCommand sqlCmd = new SqlCommand("[CifrasNotables_Ventas_2]", conexion);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 0;
            sqlCmd.Parameters.AddWithValue("@iddbempresa", idDB);
            sqlCmd.Parameters.AddWithValue("@companiaid", compania);
            sqlCmd.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
            sqlCmd.Parameters.AddWithValue("@anioact", anio);
            sqlCmd.Parameters.AddWithValue("@anioant", anioant);
            sqlCmd.Parameters.AddWithValue("@mess", mes);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CampoVentas lst = Conversor.camposventas(dt.Rows[0]);

            if (conexion.State != ConnectionState.Open) conexion.Open();
            SqlCommand sqlCmd1 = new SqlCommand("[CifrasNotables_Costo_ventas]", conexion);
            sqlCmd1.CommandType = CommandType.StoredProcedure;
            sqlCmd1.CommandTimeout = 0;
            sqlCmd1.Parameters.AddWithValue("@iddbempresa", idDB);
            sqlCmd1.Parameters.AddWithValue("@companiaid", compania);
            sqlCmd1.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
            sqlCmd1.Parameters.AddWithValue("@anioact", anio);
            sqlCmd1.Parameters.AddWithValue("@anioant", anioant);
            sqlCmd1.Parameters.AddWithValue("@mess", mes);
            SqlDataAdapter da1 = new SqlDataAdapter(sqlCmd1);
            DataTable dtt = new DataTable();
            da1.Fill(dtt);
            CampoVentas lst1 = Conversor.camposventas(dtt.Rows[0]);

            double acumulado_anio_actual_calculado = lst.acumulado_anio_actual - lst1.acumulado_anio_actual;
            double acumulado_mes_actual_calculado = lst.acumulado_mes_actual - lst1.acumulado_mes_actual;
            double acumulado_anio_anterior_calculado = lst.acumulado_anio_anterior - lst1.acumulado_anio_anterior;
            double acumulado_mes_anterior_calculado = lst.acumulado_mes_anterior - lst1.acumulado_mes_anterior;


            if (acumulado_anio_actual_calculado>0  && lst.acumulado_anio_actual>0)
            {

                acumulado_anio_actual_calculado = acumulado_anio_actual_calculado / lst.acumulado_anio_actual;
            }
            else
            {
                acumulado_anio_actual_calculado = 0;
            }

            if (acumulado_mes_actual_calculado > 0 && lst.acumulado_mes_actual>0)
            {
                acumulado_mes_actual_calculado = acumulado_mes_actual_calculado / lst.acumulado_mes_actual;
            }
            else
            {
                acumulado_mes_actual_calculado = 0;
            }

            if (acumulado_anio_anterior_calculado > 0  && lst.acumulado_anio_anterior>0)
            {
                acumulado_anio_anterior_calculado = acumulado_anio_anterior_calculado / lst.acumulado_anio_anterior;
            }
            else
            {
                acumulado_anio_anterior_calculado = 0;
            }

            if (acumulado_mes_anterior_calculado > 0 && lst.acumulado_mes_anterior>0)
            {
                acumulado_mes_anterior_calculado = acumulado_mes_anterior_calculado / lst.acumulado_mes_anterior;
            }
            else
            {
                acumulado_mes_anterior_calculado = 0;

            }











            if (acumulado_anio_actual_calculado > 0 && acumulado_anio_anterior_calculado == 0)
            {
                double camop = acumulado_anio_actual_calculado * moneda1.Rate;
                camop = Math.Round(camop, 2);
                devolucion.Monto_Acumulado = camop.ToString();
                devolucion.Porcentaje_Monto_Acumulado = "100";
            }

            if (acumulado_anio_actual_calculado == 0 && acumulado_anio_anterior_calculado > 0)
            {
                double camop = acumulado_anio_actual_calculado * moneda1.Rate;
                camop = Math.Round(camop, 2);
                devolucion.Monto_Acumulado = camop.ToString();
                devolucion.Porcentaje_Monto_Acumulado = "0";
            }

            if (acumulado_anio_actual_calculado > 0 && acumulado_anio_anterior_calculado > 0)
            {
                double camop = acumulado_anio_actual_calculado * moneda1.Rate;
                camop = Math.Round(camop, 2);
                devolucion.Monto_Acumulado = camop.ToString();


                double diff = (((acumulado_anio_actual_calculado / acumulado_anio_anterior_calculado) - 1) * 100);
                double camopp = Math.Round(diff, 2);
                devolucion.Porcentaje_Monto_Acumulado = camopp.ToString();
            }

            if (acumulado_anio_actual_calculado == 0 && acumulado_anio_anterior_calculado == 0)
            {
                devolucion.Monto_Acumulado = "0";
                devolucion.Porcentaje_Monto_Acumulado = "0";
            }






            if (acumulado_mes_actual_calculado > 0 && acumulado_mes_anterior_calculado == 0)
            {
                double camop = acumulado_mes_actual_calculado * moneda1.Rate;
                camop = Math.Round(camop, 2);
                devolucion.Monto_Mes = camop.ToString();
                devolucion.Porcentaje_Monto_Mes = "100";
            }

            if (acumulado_mes_actual_calculado == 0 && acumulado_mes_anterior_calculado > 0)
            {
                double camop = acumulado_mes_actual_calculado * moneda1.Rate;
                camop = Math.Round(camop, 2);
                devolucion.Monto_Mes = camop.ToString();
                devolucion.Porcentaje_Monto_Mes = "0";
            }
            if (acumulado_mes_actual_calculado > 0 && acumulado_mes_anterior_calculado > 0)
            {
                double camop = acumulado_mes_actual_calculado * moneda1.Rate;
                camop = Math.Round(camop, 2);
                devolucion.Monto_Mes = camop.ToString();


                double diff = (((acumulado_mes_actual_calculado / acumulado_mes_anterior_calculado) - 1) * 100);
                double camopp = Math.Round(diff, 2);
                devolucion.Porcentaje_Monto_Mes = camopp.ToString();
            }

            if (acumulado_mes_actual_calculado == 0 && acumulado_mes_anterior_calculado == 0)
            {
                devolucion.Monto_Mes = "0";
                devolucion.Porcentaje_Monto_Mes = "0";
            }




            return devolucion;


        }
    }
}
