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
    public class UsuarioBC
    {
        public async Task<Usuario> verdatosusuario11(string UserName, string Password)
        {
            Usuario obj = new Usuario();
            ClaseConexion conx = new ClaseConexion("cadenaCnx");
            try
            {
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(Password));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                string ff = sb.ToString();
                string sql = String.Format(@"select u.* from Usuario u where u.usuario= '{0}' and u.passwordd='{1}' and u.Estado=1", UserName, ff);
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


        public List<Usuario> CargarBE(DataRow[] dr)
        {
            List<Usuario> lst = new List<Usuario>();
            foreach (var item in dr)
            {
                lst.Add(CargarBE(item));
            }
            return lst;
        }
        public Usuario CargarBE(DataRow dr)
        {
            Usuario obj = new Usuario();

            obj.idUsuario = Convert.ToDecimal(dr["idUsuario"].ToString());
            obj.nombreUsuario = dr["nombreUsuario"].ToString();
            obj.usuario = dr["usuario"].ToString();
            obj.passwordd = dr["passwordd"].ToString();
            obj.fechacreacionusuario = Convert.ToDateTime(dr["fechaCreacionUsuario"].ToString());
            obj.IDRolUsuario = Convert.ToDecimal(dr["IDRolUsuario"].ToString());
            obj.CodIdioma = Convert.ToDecimal(dr["CODIdioma"].ToString());
            obj.Estado = Convert.ToBoolean(dr["Estado"].ToString());
            return obj;
        }
    }
}
