using IndicadoresCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicadoresCore.Services
{
    public interface IService
    {

        IQueryable<Usuario> GetAll_user();
        Task<Usuario> ValidarLoginWeb1(string nombre, string password);

        Task<List<Categoria_Rol>> Menu_Indicadores1(int idrolusuario);

        Task<Employee> Creacionn(Employee employee);

        Task<Detalle_receptor> DetalleCifrasNotables1(int idempresa,int anio, string mes, int compania, int monedadestino);






        Task<Performance> Performancetop51_mes(int idempresa, int anio, string mes, int compania, int monedadestino);
        Task<Performance> Performancetop51_anual(int idempresa, int anio, string mes, int compania, int monedadestino);     
        Task<Ranking_Lista> Performancetopcinco_detalle(int idempresa, int anio, string mes, int compania, int monedadestino, int proidd);
       




        Task<PerformanceRegion> Performanceregionmes(int idempresa, int anio, string mes, int compania, int monedadestino);
        Task<PerformanceRegion> Performanceregionanual(int idempresa, int anio, string mes, int compania, int monedadestino);
        Task<Ranking_Lista> Performanceregion_detalle(int idempresa, int anio, string mes, int compania, int monedadestino, int ciudadid);





        Task<Margen_bruto> Margenbruto_region(int idempresa, int anio, string mes, int compania, int monedadestino);

        Task<Margen_bruto> Margenbruto_top5(int idempresa, int anio, string mes, int compania, int monedadestino);
  
     

    }
}
