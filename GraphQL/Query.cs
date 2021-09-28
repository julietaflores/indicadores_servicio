using IndicadoresCore.Models;
using IndicadoresCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicadoresCore.GraphQL
{
    public class Query
    {
        private readonly IService _Service;
        public Query(IService Service)
        {
            _Service = Service;
        }
        public IQueryable<Usuario> Usuario => _Service.GetAll_user();

        public Task<Usuario> Validarlogin(string usuario, string clave) => _Service.ValidarLoginWeb1(usuario, clave);


        public Task<List<Categoria_Rol>> menu_Indicadores(int idrolusuario) => _Service.Menu_Indicadores1(idrolusuario);



        public Task<Detalle_receptor> DetalleCifrasNotables(int idrol,int anio, string mes, int compania ,int monedadestino) => _Service.DetalleCifrasNotables1(idrol,anio, mes,compania, monedadestino);





        public Task<Performance> Performancetopmes(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo) => _Service.Performancetop51_mes(idrol1, anioo, mess, companiaa, monedadestinoo);
        public Task<Performance> Performancetopanual(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo) => _Service.Performancetop51_anual(idrol1, anioo, mess, companiaa, monedadestinoo);
        public Task<Ranking_Lista> Raking_lista_mesanual(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo, int proidd) => _Service.Performancetopcinco_detalle(idrol1, anioo, mess, companiaa, monedadestinoo, proidd);
 




        public Task<PerformanceRegion> Performanceregionmes(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo) => _Service.Performanceregionmes(idrol1, anioo, mess, companiaa, monedadestinoo);
        public Task<PerformanceRegion> Performanceregionanual(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo) => _Service.Performanceregionanual(idrol1, anioo, mess, companiaa, monedadestinoo);
        public Task<Ranking_Lista> Raking_lista_mesanual_region(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo, int ciudadid) => _Service.Performanceregion_detalle(idrol1, anioo, mess, companiaa, monedadestinoo, ciudadid);




        public Task<Margen_bruto> Margenbruto_region(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo) => _Service.Margenbruto_region(idrol1, anioo, mess, companiaa, monedadestinoo);


        public Task<Margen_bruto> Margenbruto_top5(int idrol1, int anioo, string mess, int companiaa, int monedadestinoo) => _Service.Margenbruto_top5(idrol1, anioo, mess, companiaa, monedadestinoo);
  








    }
}
