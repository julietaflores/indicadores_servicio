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
using IndicadoresCore.Models.tabla_9_primero_indicadores;



namespace IndicadoresCore.Models
{
    public class DatabaseContext : DbContext
    {
        string con = "Server=181.188.133.118,20200;Initial Catalog=BTCANALYTICS;Persist Security Info=False;User ID=URBBGN;Password=Bantic310188";

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

    
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public async Task<Usuario> verdatosusuario1(string UserName, string Password)
        {
            Usuario obj = new Usuario();
            UsuarioBC usuarioBC = new UsuarioBC();
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            MonedaEmpresaBC monedaEmpresaBC = new MonedaEmpresaBC();
            CompaniaBC companiaBC = new CompaniaBC();
            obj = await usuarioBC.verdatosusuario11(UserName, Password);
            if (obj.idUsuario > 0)
            {
                DBEmpresa dBEmpresaA = dBEmpresaBC.listadebasexEmpresa11(obj.IDRolUsuario);
                obj.Monedass = monedaEmpresaBC.listamonedaxempresa(dBEmpresaA.IdEmpresa);
                obj.Companiaa = companiaBC.listaCompaniaxEmoresa(dBEmpresaA.IdEmpresa);
            }

            return obj;
        }


        //registrra employtee
        public async Task<Employee> registraremployee(Employee employee)
        {
            Employee employee1 = new Employee();
            EmployeeBC employeeBC = new EmployeeBC();
            bool ff = employeeBC.Actualizar(ref employee);
            employee1 = await employeeBC.buscarxid(employee.Id);
            return employee1;
        }


        public async Task<List<Categoria_Rol>> categorirol11(decimal idrolusuario)
        {
            List<Categoria_Rol> obj = new List<Categoria_Rol>();
            Categoria_RolBC categoria_RolBC = new Categoria_RolBC();
            obj = categoria_RolBC.listadatoscategoriarolusuario1(idrolusuario);

            return obj;
        }




        public async Task<Detalle_receptor> DetalleCifrasNotables(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Detalle_receptor detalle_Receptor = new Detalle_receptor();
            TableroBC tableroBC = new TableroBC();
            detalle_Receptor.tablero = tableroBC.datostableroid(Convert.ToDecimal(1));
            List<Devolucion> devolucions = new List<Devolucion>();
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);

            for (int nn=1; nn<=9; nn++)
            {
                switch (nn)
                {
                    case 1:
                        Cantidad_1 cantidad_1 = new Cantidad_1();
                        Devolucion devolucion1 = cantidad_1.devolver_cantidad_1(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1);
                        devolucions.Add(devolucion1);


                        break;
                    case 2:
                        Ventas_2 ventas_2 = new Ventas_2();
                        Devolucion devolucion2 = ventas_2.devolver_ventas_2(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1);
                        devolucions.Add(devolucion2);

                        break;
                    case 3:
                        Precio_Promedio_3 precio_Promedio_3 = new Precio_Promedio_3();
                        Devolucion devolucion3 = precio_Promedio_3.devolver_Precio_Promedio_3(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1);
                        devolucions.Add(devolucion3);

                        break;
                    case 4:
                        Gross_Profit_4 gross_Profit_4 = new Gross_Profit_4();
                        Devolucion devolucion4 = gross_Profit_4.devolver_gross_profit_4(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1);
                        devolucions.Add(devolucion4);

                        break;
                    case 5:
                        Gross_Margin_5 gross_Margin_5 = new Gross_Margin_5();
                        Devolucion devolucion5 = gross_Margin_5.devolver_gross_margin_5(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1);
                        devolucions.Add(devolucion5);

                        break;
                    case 6:



                      
                        break;
                    case 7:
                      


                        break;
                    case 8:
                       


                        break;
                    case 9:
                     


                        break;
                }

            }

            detalle_Receptor.Lista = devolucions;
            return detalle_Receptor;

        }








        public async Task<Performance> Performancetopcinco_mes(int idrol, int anio, string mes, int compania, int monedadestino)
        {
           

            Performance performance = new Performance();
            TableroBC tableroBC = new TableroBC();
            performance.tablero = tableroBC.datostableroid(Convert.ToDecimal(4));
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);
            SqlConnection conexion = new SqlConnection(con);
          
            if (conexion.State != ConnectionState.Open) conexion.Open();
            SqlCommand sqlCmd = new SqlCommand("[Performacetop5mesactual]", conexion);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 0;
            sqlCmd.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
            sqlCmd.Parameters.AddWithValue("@companiaid", compania);
            sqlCmd.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
            sqlCmd.Parameters.AddWithValue("@anioact", anio);
            sqlCmd.Parameters.AddWithValue("@anioant", anioant);
            sqlCmd.Parameters.AddWithValue("@mess", mes);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Ranking> lst = Conversor.listaranking(dt.Select());
            double totap = Conversor.totalrakintop5(dt.Select());

            foreach (var lista_mes in lst)
            {

                if (lista_mes.precio > 0)
                {


                    int anioantant = anioant - 1;

                    double camop1 = lista_mes.precio * moneda1.Rate;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.precio = camop1;
                    double por = ((lista_mes.precio * 100) / totap);
                    por = Math.Round(por, 2);
                    lista_mes.porcentajetorta = por.ToString();


                    camop1 = camop1 / 1000;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.precio = camop1;

                    SqlCommand sqlCmd1 = new SqlCommand("[Performacetop5mesanterior_x_producto]", conexion);
                    sqlCmd1.CommandType = CommandType.StoredProcedure;
                    sqlCmd1.CommandTimeout = 0;
                    sqlCmd1.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                    sqlCmd1.Parameters.AddWithValue("@companiaid", compania);
                    sqlCmd1.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                    sqlCmd1.Parameters.AddWithValue("@anioact", anioant);
                    sqlCmd1.Parameters.AddWithValue("@anioant", anioantant);
                    sqlCmd1.Parameters.AddWithValue("@mess", mes);
                    sqlCmd1.Parameters.AddWithValue("@proid", lista_mes.idPosicion);
                    SqlDataAdapter da1 = new SqlDataAdapter(sqlCmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    Ranking lstr = Conversor.listaranking1(dt1.Select().FirstOrDefault());

                    if (lstr.precio > 0)
                    {
                        double camop11 = lstr.precio * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        camop11 = camop11 / 1000;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;


                    }
                    else
                    {
                        double camop11 = 0 * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;


                    }

                }
                else
                {
                    lista_mes.precio = 0;
                    lista_mes.importeanterior = 0;
                    lista_mes.porcentajetorta = "0";
                }

            }
            performance.Lista = lst;
            return performance;
        }




        public async Task<Performance> Performancetopcinco_anual(int idrol, int anio, string mes, int compania, int monedadestino)
        {

            Performance performance = new Performance();
            TableroBC tableroBC = new TableroBC();
            performance.tablero = tableroBC.datostableroid(Convert.ToDecimal(4));
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);
            SqlConnection conexion = new SqlConnection(con);

            if (conexion.State != ConnectionState.Open) conexion.Open();
            SqlCommand sqlCmd = new SqlCommand("[Performacetop5anioactual]", conexion);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 0;
            sqlCmd.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
            sqlCmd.Parameters.AddWithValue("@companiaid", compania);
            sqlCmd.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
            sqlCmd.Parameters.AddWithValue("@anioact", anio);
            sqlCmd.Parameters.AddWithValue("@anioant", anioant);
            sqlCmd.Parameters.AddWithValue("@mess", mes);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Ranking> lst = Conversor.listaranking(dt.Select());
            double totap = Conversor.totalrakintop5(dt.Select());

            foreach (var lista_mes in lst)
            {

                if (lista_mes.precio > 0)
                {


                    int anioantant = anioant - 1;

                    double camop1 = lista_mes.precio * moneda1.Rate;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.precio = camop1;
                    double por = ((lista_mes.precio * 100) / totap);
                    por = Math.Round(por, 2);
                    lista_mes.porcentajetorta = por.ToString();


                    camop1 = camop1 / 1000;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.precio = camop1;

                    SqlCommand sqlCmd1 = new SqlCommand("[Performacetop5anioanterior_x_producto]", conexion);
                    sqlCmd1.CommandType = CommandType.StoredProcedure;
                    sqlCmd1.CommandTimeout = 0;
                    sqlCmd1.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                    sqlCmd1.Parameters.AddWithValue("@companiaid", compania);
                    sqlCmd1.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                    sqlCmd1.Parameters.AddWithValue("@anioact", anioant);
                    sqlCmd1.Parameters.AddWithValue("@anioant", anioantant);
                    sqlCmd1.Parameters.AddWithValue("@mess", mes);
                    sqlCmd1.Parameters.AddWithValue("@proid", lista_mes.idPosicion);
                    SqlDataAdapter da1 = new SqlDataAdapter(sqlCmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    Ranking lstr = Conversor.listaranking1(dt1.Select().FirstOrDefault());

                    if (lstr.precio > 0)
                    {
                        double camop11 = lstr.precio * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        camop11 = camop11 / 1000;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;

                       
                    }
                    else
                    {
                        double camop11 = 0 * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;

                  
                    }
                  
                }
                else
                {
                    lista_mes.precio = 0;
                    lista_mes.importeanterior = 0;
                    lista_mes.porcentajetorta = "0";
                }



            }


            performance.Lista = lst;
            return performance;
        }









        public async Task<Ranking_Lista> Performancetopcinco_detalle(int idrol, int anio, string mes, int compania, int monedadestino, decimal proidd)
        {
            Ranking_Lista detalle_Receptor = new Ranking_Lista();
            List<Devolucion> devolucions = new List<Devolucion>();
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);
            for (int nn = 1; nn <= 3; nn++)
            {
                switch (nn)
                {
                       case 1:
                        Cantidad_1 cantidad_1 = new Cantidad_1();
                    
                        Devolucion devolucion1 = cantidad_1.devolver_cantidad_mesanual(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1,proidd);
                        devolucions.Add(devolucion1);
                        break;
                    case 2:
                        Ventas_2 ventas_2 = new Ventas_2();
                        Devolucion devolucion2 = ventas_2.devolver_ventas_mesanual(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1, proidd);
                        devolucions.Add(devolucion2);
                        break;
                    case 3:
                        Precio_Promedio_3 precio_Promedio_3 = new Precio_Promedio_3();
                        Devolucion devolucion3 = precio_Promedio_3.devolver_Precio_Promedio_mesanual(anioant, anio, mes, compania1, compania, dBEmpresac.idDB,moneda1, proidd);
                        devolucions.Add(devolucion3);
                        break;
                }
            }
            detalle_Receptor.Lista = devolucions;
            return detalle_Receptor;
        }








        public async Task<PerformanceRegion> Performanceregionmes(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            PerformanceRegion performance = new PerformanceRegion();
            TableroBC tableroBC = new TableroBC();
            performance.tablero = tableroBC.datostableroid(Convert.ToDecimal(5));
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);
            SqlConnection conexion = new SqlConnection(con);
            if (conexion.State != ConnectionState.Open) conexion.Open();
            SqlCommand sqlCmd = new SqlCommand("[PerformaceRegionalmes]", conexion);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 0;
            sqlCmd.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
            sqlCmd.Parameters.AddWithValue("@companiaid", compania);
            sqlCmd.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
            sqlCmd.Parameters.AddWithValue("@anioact", anio);
            sqlCmd.Parameters.AddWithValue("@anioant", anioant);
            sqlCmd.Parameters.AddWithValue("@mess", mes);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Ranking_Region> lst = Conversor.listarankingregion(dt.Select());
            double totap= Conversor.totalrakinregion(dt.Select());
            foreach (var lista_mes in lst)
            {
            
                if (lista_mes.importeactual>0 )
                {
                    double camop1 = lista_mes.importeactual * moneda1.Rate;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.importeactual = camop1;


                    double por = ((lista_mes.importeactual * 100) / totap);
                    por = Math.Round(por, 2);
                    lista_mes.porcentajetorta = por.ToString();

                    camop1 = camop1 / 1000;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.importeactual = camop1;

                    if (lista_mes.importeanterior>0)
                    {

                        double camop11 = lista_mes.importeanterior * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        camop11 = camop11 / 1000;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;
                    }
                    else
                    {
                        lista_mes.importeanterior = 0;
                    }

                }
                else
                {
                    lista_mes.importeactual = 0;
                    lista_mes.porcentajetorta = "0";

                    if (lista_mes.importeanterior > 0)
                    {

                        double camop11 = lista_mes.importeanterior * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        camop11 = camop11 / 1000;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;
                    }
                    else
                    {
                        lista_mes.importeanterior = 0;
                    }
                }

            }
            performance.Lista = lst;
            return performance;
        }




        public async Task<PerformanceRegion> Performanceregionanual(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            PerformanceRegion performance = new PerformanceRegion();
            TableroBC tableroBC = new TableroBC();
            performance.tablero = tableroBC.datostableroid(Convert.ToDecimal(5));
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);
            SqlConnection conexion = new SqlConnection(con);
            if (conexion.State != ConnectionState.Open) conexion.Open();
            SqlCommand sqlCmd = new SqlCommand("[PerformaceRegionalanual]", conexion);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 0;
            sqlCmd.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
            sqlCmd.Parameters.AddWithValue("@companiaid", compania);
            sqlCmd.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
            sqlCmd.Parameters.AddWithValue("@anioact", anio);
            sqlCmd.Parameters.AddWithValue("@anioant", anioant);
            sqlCmd.Parameters.AddWithValue("@mess", mes);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Ranking_Region> lst = Conversor.listarankingregion(dt.Select());
            double totap = Conversor.totalrakinregion(dt.Select());
            foreach (var lista_mes in lst)
            {

                if (lista_mes.importeactual > 0)
                {
                    double camop1 = lista_mes.importeactual * moneda1.Rate;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.importeactual = camop1;


                    double por = ((lista_mes.importeactual * 100) / totap);
                    por = Math.Round(por, 2);
                    lista_mes.porcentajetorta = por.ToString();

                    camop1 = camop1 / 1000;
                    camop1 = Math.Round(camop1, 2);
                    lista_mes.importeactual = camop1;

                    if (lista_mes.importeanterior > 0)
                    {

                        double camop11 = lista_mes.importeanterior * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        camop11 = camop11 / 1000;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;
                    }
                    else
                    {
                        lista_mes.importeanterior = 0;
                    }

                }
                else
                {
                    lista_mes.importeactual = 0;
                    lista_mes.porcentajetorta = "0";

                    if (lista_mes.importeanterior > 0)
                    {

                        double camop11 = lista_mes.importeanterior * moneda1.Rate;
                        camop11 = Math.Round(camop11, 2);
                        camop11 = camop11 / 1000;
                        camop11 = Math.Round(camop11, 2);
                        lista_mes.importeanterior = camop11;
                    }
                    else
                    {
                        lista_mes.importeanterior = 0;
                    }
                }


            }
            performance.Lista = lst;
            return performance;
        }









        public async Task<Ranking_Lista> Performanceregion_detalle(int idrol, int anio, string mes, int compania, int monedadestino, decimal ciudadid)
        {
            Ranking_Lista detalle_Receptor = new Ranking_Lista();
            List<Devolucion> devolucions = new List<Devolucion>();
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);
            for (int nn = 1; nn <= 3; nn++)
            {
                switch (nn)
                {
                    case 1:
                        Cantidad_1 cantidad_1 = new Cantidad_1();
                        Devolucion devolucion1 = cantidad_1.devolver_cantidad_mesanual_performanceregion(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1, ciudadid);
                        devolucions.Add(devolucion1);
                        break;
                    case 2:
                        Ventas_2 ventas_2 = new Ventas_2();
                        Devolucion devolucion2 = ventas_2.devolver_ventas_mesanual_performanceregion(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1, ciudadid);
                        devolucions.Add(devolucion2);
                        break;
                    case 3:
                        Precio_Promedio_3 precio_Promedio_3 = new Precio_Promedio_3();
                        Devolucion devolucion3 = precio_Promedio_3.devolver_Precio_Promedio_mesanual_performanceregion(anioant, anio, mes, compania1, compania, dBEmpresac.idDB, moneda1, ciudadid);
                        devolucions.Add(devolucion3);
                        break;
                }
            }
            detalle_Receptor.Lista = devolucions;
            return detalle_Receptor;
        }








        public async Task<Margen_bruto> Margen_bruto_region(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Margen_bruto performance = new Margen_bruto();
            TableroBC tableroBC = new TableroBC();
            performance.tablero = tableroBC.datostableroid(Convert.ToDecimal(6));
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);
         


            for (int nn = 1; nn <= 2; nn++)
            {
                switch (nn)
                {
                    case 1:
                        SqlConnection conexion = new SqlConnection(con);

                        if (conexion.State != ConnectionState.Open) conexion.Open();
                        SqlCommand sqlCmd = new SqlCommand("[MargenBrutoRegionMes]", conexion);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandTimeout = 0;
                        sqlCmd.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                        sqlCmd.Parameters.AddWithValue("@companiaid", compania);
                        sqlCmd.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                        sqlCmd.Parameters.AddWithValue("@anioact", anio);
                        sqlCmd.Parameters.AddWithValue("@anioant", anioant);
                        sqlCmd.Parameters.AddWithValue("@mess", mes);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        List<Ranking_Margenes> lst = Conversor.listarankingmargen_bruto(dt.Select());
                        double totap = Conversor.totalrakinmargenbruto(dt.Select());
                        foreach (var lista_mes in lst)
                        {



                            if (lista_mes.importe_actual > 0 && lista_mes.coste_actual > 0)
                            {

                                int anioantant = anioant - 1;



                                double camop1 = lista_mes.importe_actual * moneda1.Rate;
                                camop1 = Math.Round(camop1, 2);
                                lista_mes.importe_actual = camop1;




                                double camopct = lista_mes.coste_actual * moneda1.Rate;
                                camopct = Math.Round(camopct, 2);
                                lista_mes.coste_actual = camopct;



                                SqlCommand sqlCmd1 = new SqlCommand("[MargenBrutoRegionMes_x_ciudad]", conexion);
                                sqlCmd1.CommandType = CommandType.StoredProcedure;
                                sqlCmd1.CommandTimeout = 0;
                                sqlCmd1.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                                sqlCmd1.Parameters.AddWithValue("@companiaid", compania);
                                sqlCmd1.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                                sqlCmd1.Parameters.AddWithValue("@anioact", anioant);
                                sqlCmd1.Parameters.AddWithValue("@anioant", anioantant);
                                sqlCmd1.Parameters.AddWithValue("@mess", mes);
                                sqlCmd1.Parameters.AddWithValue("@ciudadid", lista_mes.id);
                                SqlDataAdapter da1 = new SqlDataAdapter(sqlCmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                Ranking_Margenes lstr = Conversor.listarankingmargen_bruto1(dt1.Select().FirstOrDefault());

                                if (lstr.importe_actual > 0 && lstr.coste_actual > 0)
                                {

                                    double camop11 = lstr.importe_actual * moneda1.Rate;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    double camopctt = lstr.coste_actual * moneda1.Rate;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;


                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;

                                    double gross_profit_anterior = lista_mes.importe_anterior - lista_mes.coste_anterior;
                                    double gross_margin_anterior = gross_profit_anterior / lista_mes.importe_anterior;
                                    gross_margin_anterior = Math.Round(gross_margin_anterior, 2);
                                    lista_mes.porcentaje_margen_anterior = gross_margin_anterior;



                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;

                                    camop11 = camop11 / 1000;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    camopctt = camopctt / 1000;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;

                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totap);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();


                                }
                                else
                                {




                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;


                                    lista_mes.importe_anterior = 0;
                                    lista_mes.coste_anterior = 0;
                                    lista_mes.porcentaje_margen_anterior = 0;

                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;




                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totap);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();
                                }




                            }
                            else
                            {
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_actual = 0;
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_anterior = 0;
                                lista_mes.BPS = "0";
                                lista_mes.calculo_grafico = "0";
                                lista_mes.porcentajetorta = "0";
                            }


                        }
                        performance.Lista_mes = lst;


                        break;
                    case 2:


                        SqlConnection conexion1 = new SqlConnection(con);
                        if (conexion1.State != ConnectionState.Open) conexion1.Open();
                        SqlCommand sqlCmda = new SqlCommand("[MargenBrutoRegionAnual]", conexion1);
                        sqlCmda.CommandType = CommandType.StoredProcedure;
                        sqlCmda.CommandTimeout = 0;
                        sqlCmda.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                        sqlCmda.Parameters.AddWithValue("@companiaid", compania);
                        sqlCmda.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                        sqlCmda.Parameters.AddWithValue("@anioact", anio);
                        sqlCmda.Parameters.AddWithValue("@anioant", anioant);
                        sqlCmda.Parameters.AddWithValue("@mess", mes);
                        SqlDataAdapter daa = new SqlDataAdapter(sqlCmda);
                        DataTable dta = new DataTable();
                        daa.Fill(dta);
                        List<Ranking_Margenes> lsta = Conversor.listarankingmargen_bruto(dta.Select());
                        double totapa = Conversor.totalrakinmargenbruto(dta.Select());
                        foreach (var lista_mes in lsta)
                        {



                            if (lista_mes.importe_actual > 0 && lista_mes.coste_actual > 0)
                            {

                                int anioantant = anioant - 1;

                                double camop1 = lista_mes.importe_actual * moneda1.Rate;
                                camop1 = Math.Round(camop1, 2);
                                lista_mes.importe_actual = camop1;


                                double camopct = lista_mes.coste_actual * moneda1.Rate;
                                camopct = Math.Round(camopct, 2);
                                lista_mes.coste_actual = camopct;


                                SqlCommand sqlCmd1 = new SqlCommand("[MargenBrutoRegionAnual_x_ciudad]", conexion1);
                                sqlCmd1.CommandType = CommandType.StoredProcedure;
                                sqlCmd1.CommandTimeout = 0;
                                sqlCmd1.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                                sqlCmd1.Parameters.AddWithValue("@companiaid", compania);
                                sqlCmd1.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                                sqlCmd1.Parameters.AddWithValue("@anioact", anioant);
                                sqlCmd1.Parameters.AddWithValue("@anioant", anioantant);
                                sqlCmd1.Parameters.AddWithValue("@mess", mes);
                                sqlCmd1.Parameters.AddWithValue("@ciudadid", lista_mes.id);
                                SqlDataAdapter da1 = new SqlDataAdapter(sqlCmd1);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                Ranking_Margenes lstr = Conversor.listarankingmargen_bruto1(dt1.Select().FirstOrDefault());

                                if (lstr.importe_actual > 0 && lstr.coste_actual > 0)
                                {

                                    double camop11 = lstr.importe_actual * moneda1.Rate;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    double camopctt = lstr.coste_actual * moneda1.Rate;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;


                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;

                                    double gross_profit_anterior = lista_mes.importe_anterior - lista_mes.coste_anterior;
                                    double gross_margin_anterior = gross_profit_anterior / lista_mes.importe_anterior;
                                    gross_margin_anterior = Math.Round(gross_margin_anterior, 2);
                                    lista_mes.porcentaje_margen_anterior = gross_margin_anterior;



                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;

                                    camop11 = camop11 / 1000;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    camopctt = camopctt / 1000;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;


                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totapa);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();


                                }
                                else
                                {


                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;


                                    lista_mes.importe_anterior = 0;
                                    lista_mes.coste_anterior = 0;
                                    lista_mes.porcentaje_margen_anterior = 0;


                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;

                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totapa);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();
                                }




                            }
                            else
                            {
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_actual = 0;
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_anterior = 0;
                                lista_mes.BPS = "0";
                                lista_mes.calculo_grafico = "0";
                                lista_mes.porcentajetorta = "0";
                            }


                        }
                        performance.Lista_anual = lsta;


                        break;
                  
                }

            }

            return performance;
        }




        public async Task<Margen_bruto> Margen_bruto_top5(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Margen_bruto performance = new Margen_bruto();
            TableroBC tableroBC = new TableroBC();
            performance.tablero = tableroBC.datostableroid(Convert.ToDecimal(7));
            int anioant = anio - 1;
            DBEmpresaBC dBEmpresaBC = new DBEmpresaBC();
            DBEmpresa dBEmpresac = dBEmpresaBC.listadebasexEmpresa11(idrol);
            MonedaEmpresaBC monedaEmpresaBC1 = new MonedaEmpresaBC();
            MonedaEmpresa moneda1 = monedaEmpresaBC1.datosempresamoneda(dBEmpresac.IdEmpresa, monedadestino);
            CompaniaBC companiaBCc = new CompaniaBC();
            Compania compania1 = companiaBCc.datosempresacompania(dBEmpresac.IdEmpresa, compania);

            for (int nn = 1; nn <= 2; nn++)
            {
                switch (nn)
                {
                    case 1:


                        SqlConnection conexion = new SqlConnection(con);
                        if (conexion.State != ConnectionState.Open) conexion.Open();
                        SqlCommand sqlCmd = new SqlCommand("[MargenBrutoTop5Mes]", conexion);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandTimeout = 0;
                        sqlCmd.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                        sqlCmd.Parameters.AddWithValue("@companiaid", compania);
                        sqlCmd.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                        sqlCmd.Parameters.AddWithValue("@anioact", anio);
                        sqlCmd.Parameters.AddWithValue("@anioant", anioant);
                        sqlCmd.Parameters.AddWithValue("@mess", mes);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        List<Ranking_Margenes> lst = Conversor.listarankingmargen_brutotop5(dt.Select());
                        double totap = Conversor.totalrakinmargenbruto(dt.Select());
                        foreach (var lista_mes in lst)
                        {



                            if (lista_mes.importe_actual > 0 && lista_mes.coste_actual > 0)
                            {

                                int anioantant = anioant - 1;



                                double camop1 = lista_mes.importe_actual * moneda1.Rate;
                                camop1 = Math.Round(camop1, 2);
                                lista_mes.importe_actual = camop1;

                                double camopct = lista_mes.coste_actual * moneda1.Rate;
                                camopct = Math.Round(camopct, 2);
                                lista_mes.coste_actual = camopct;



                                SqlCommand sqlCmd1c = new SqlCommand("[MargenBrutoTop5Mes_x_producto]", conexion);
                                sqlCmd1c.CommandType = CommandType.StoredProcedure;
                                sqlCmd1c.CommandTimeout = 0;
                                sqlCmd1c.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                                sqlCmd1c.Parameters.AddWithValue("@companiaid", compania);
                                sqlCmd1c.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                                sqlCmd1c.Parameters.AddWithValue("@anioact", anioant);
                                sqlCmd1c.Parameters.AddWithValue("@anioant", anioantant);
                                sqlCmd1c.Parameters.AddWithValue("@mess", mes);
                                sqlCmd1c.Parameters.AddWithValue("@proidd", lista_mes.id);
                                SqlDataAdapter da1c = new SqlDataAdapter(sqlCmd1c);
                                DataTable dt1c = new DataTable();
                                da1c.Fill(dt1c);
                                Ranking_Margenes lstr = Conversor.listarankingmargen_brutotop51(dt1c.Select().FirstOrDefault());

                                if (lstr.importe_actual > 0 && lstr.coste_actual > 0)
                                {

                                    double camop11 = lstr.importe_actual * moneda1.Rate;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    double camopctt = lstr.coste_actual * moneda1.Rate;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;


                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;

                                    double gross_profit_anterior = lista_mes.importe_anterior - lista_mes.coste_anterior;
                                    double gross_margin_anterior = gross_profit_anterior / lista_mes.importe_anterior;
                                    gross_margin_anterior = Math.Round(gross_margin_anterior, 2);
                                    lista_mes.porcentaje_margen_anterior = gross_margin_anterior;

                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;

                                    camop11 = camop11 / 1000;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    camopctt = camopctt / 1000;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;





                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totap);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();


                                }
                                else
                                {




                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;


                                    lista_mes.importe_anterior = 0;
                                    lista_mes.coste_anterior = 0;
                                    lista_mes.porcentaje_margen_anterior = 0;


                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;


                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totap);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();
                                }




                            }
                            else
                            {
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_actual = 0;
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_anterior = 0;
                                lista_mes.BPS = "0";
                                lista_mes.calculo_grafico = "0";
                                lista_mes.porcentajetorta = "0";
                            }


                        }
                        performance.Lista_mes = lst;

                        break;
                    case 2:


                        SqlConnection conexion1 = new SqlConnection(con);
                        if (conexion1.State != ConnectionState.Open) conexion1.Open();
                        SqlCommand sqlCmd1 = new SqlCommand("[MargenBrutoTop5Anual]", conexion1);
                        sqlCmd1.CommandType = CommandType.StoredProcedure;
                        sqlCmd1.CommandTimeout = 0;
                        sqlCmd1.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                        sqlCmd1.Parameters.AddWithValue("@companiaid", compania);
                        sqlCmd1.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                        sqlCmd1.Parameters.AddWithValue("@anioact", anio);
                        sqlCmd1.Parameters.AddWithValue("@anioant", anioant);
                        sqlCmd1.Parameters.AddWithValue("@mess", mes);
                        SqlDataAdapter da1 = new SqlDataAdapter(sqlCmd1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        List<Ranking_Margenes> lst1 = Conversor.listarankingmargen_brutotop5(dt1.Select());
                        double totap1 = Conversor.totalrakinmargenbruto(dt1.Select());
                        foreach (var lista_mes in lst1)
                        {



                            if (lista_mes.importe_actual > 0 && lista_mes.coste_actual > 0)
                            {

                                int anioantant = anioant - 1;



                                double camop1 = lista_mes.importe_actual * moneda1.Rate;
                                camop1 = Math.Round(camop1, 2);
                                lista_mes.importe_actual = camop1;

                                double camopct = lista_mes.coste_actual * moneda1.Rate;
                                camopct = Math.Round(camopct, 2);
                                lista_mes.coste_actual = camopct;



                                SqlCommand sqlCmd11 = new SqlCommand("[MargenBrutoTop5Anual_x_producto]", conexion1);
                                sqlCmd11.CommandType = CommandType.StoredProcedure;
                                sqlCmd11.CommandTimeout = 0;
                                sqlCmd11.Parameters.AddWithValue("@iddbempresa", dBEmpresac.idDB);
                                sqlCmd11.Parameters.AddWithValue("@companiaid", compania);
                                sqlCmd11.Parameters.AddWithValue("@monedaid", compania1.IdMonedaEmpresaOdoo);
                                sqlCmd11.Parameters.AddWithValue("@anioact", anioant);
                                sqlCmd11.Parameters.AddWithValue("@anioant", anioantant);
                                sqlCmd11.Parameters.AddWithValue("@mess", mes);
                                sqlCmd11.Parameters.AddWithValue("@proidd", lista_mes.id);
                                SqlDataAdapter da11 = new SqlDataAdapter(sqlCmd11);
                                DataTable dt11 = new DataTable();
                                da11.Fill(dt11);
                                Ranking_Margenes lstr = Conversor.listarankingmargen_brutotop51(dt1.Select().FirstOrDefault());

                                if (lstr.importe_actual > 0 && lstr.coste_actual > 0)
                                {

                                    double camop11 = lstr.importe_actual * moneda1.Rate;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    double camopctt = lstr.coste_actual * moneda1.Rate;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;


                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;

                                    double gross_profit_anterior = lista_mes.importe_anterior - lista_mes.coste_anterior;
                                    double gross_margin_anterior = gross_profit_anterior / lista_mes.importe_anterior;
                                    gross_margin_anterior = Math.Round(gross_margin_anterior, 2);
                                    lista_mes.porcentaje_margen_anterior = gross_margin_anterior;




                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;

                                    camop11 = camop11 / 1000;
                                    camop11 = Math.Round(camop11, 2);
                                    lista_mes.importe_anterior = camop11;

                                    camopctt = camopctt / 1000;
                                    camopctt = Math.Round(camopctt, 2);
                                    lista_mes.coste_anterior = camopctt;




                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totap1);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();


                                }
                                else
                                {



                                    double gross_profit_actual = lista_mes.importe_actual - lista_mes.coste_actual;
                                    double gross_margin_actual = gross_profit_actual / lista_mes.importe_actual;
                                    gross_margin_actual = Math.Round(gross_margin_actual, 2);
                                    lista_mes.porcentaje_margen_actual = gross_margin_actual;


                                    lista_mes.importe_anterior = 0;
                                    lista_mes.coste_anterior = 0;
                                    lista_mes.porcentaje_margen_anterior = 0;



                                    camop1 = camop1 / 1000;
                                    camop1 = Math.Round(camop1, 2);
                                    lista_mes.importe_actual = camop1;

                                    camopct = camopct / 1000;
                                    camopct = Math.Round(camopct, 2);
                                    lista_mes.coste_actual = camopct;





                                    double bps = lista_mes.importe_actual - lista_mes.importe_anterior;
                                    bps = Math.Round(bps, 2);
                                    lista_mes.BPS = bps.ToString();

                                    double calculo_grafico = lista_mes.coste_actual - lista_mes.coste_anterior;
                                    calculo_grafico = Math.Round(calculo_grafico, 2);
                                    lista_mes.calculo_grafico = calculo_grafico.ToString();



                                    double por = ((lista_mes.porcentaje_margen_actual * 100) / totap1);
                                    por = Math.Round(por, 2);
                                    lista_mes.porcentajetorta = por.ToString();
                                }




                            }
                            else
                            {
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_actual = 0;
                                lista_mes.importe_anterior = 0;
                                lista_mes.coste_anterior = 0;
                                lista_mes.porcentaje_margen_anterior = 0;
                                lista_mes.BPS = "0";
                                lista_mes.calculo_grafico = "0";
                                lista_mes.porcentajetorta = "0";
                            }


                        }
                        performance.Lista_anual = lst1;

                        break;
                  
                }

            }




         
            return performance;
        }



























    }
}
