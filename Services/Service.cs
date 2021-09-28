using IndicadoresCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using IndicadoresCore.Models.BC;

namespace IndicadoresCore.Services
{
    public class Service : IService
    {
        private readonly DatabaseContext _dbContext;
  

        public Service(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }



        public async Task<Employee> Creacionn(Employee employee)
        {
          
            Task<Employee> employee1 = _dbContext.registraremployee(employee);
            return  await  employee1;
        }


        public IQueryable<Usuario> GetAll_user()
        {
            return _dbContext.Usuario.AsQueryable();
        }

        public async Task<Usuario> ValidarLoginWeb1(string Usuario, string Clave)
        {
            Task<Usuario> usuario1 = _dbContext.verdatosusuario1(Usuario, Clave);
            return await usuario1;
        }


        public async Task<List<Categoria_Rol>> Menu_Indicadores1(int irolusuario1)
        {
            decimal irolusuario = Convert.ToDecimal(irolusuario1);
            Task<List<Categoria_Rol>> categoriarol = _dbContext.categorirol11(irolusuario);
            return await categoriarol;
        }








        public async Task<Detalle_receptor> DetalleCifrasNotables1(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Task<Detalle_receptor> detallecifrasnotabless = _dbContext.DetalleCifrasNotables(idrol, anio, mes, compania,monedadestino);

            return await detallecifrasnotabless;
        }





        public async Task<Performance> Performancetop51_mes(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Task<Performance> detallecis = _dbContext.Performancetopcinco_mes(idrol, anio, mes, compania, monedadestino);
            return await detallecis;
        }
        public async Task<Performance> Performancetop51_anual(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Task<Performance> detallecis = _dbContext.Performancetopcinco_anual(idrol, anio, mes, compania, monedadestino);
            return await detallecis;
        }
        public async Task<Ranking_Lista> Performancetopcinco_detalle(int idrol, int anio, string mes, int compania, int monedadestino, int proidd)
        {
            decimal poo = Convert.ToInt32(proidd);
            Task<Ranking_Lista> detallecis = _dbContext.Performancetopcinco_detalle(idrol, anio, mes, compania, monedadestino,poo);
            return await detallecis;
        }











        public async Task<PerformanceRegion> Performanceregionmes(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Task<PerformanceRegion> detallecis = _dbContext.Performanceregionmes(idrol, anio, mes, compania, monedadestino);
            return await detallecis;
        }
        public async Task<PerformanceRegion> Performanceregionanual(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Task<PerformanceRegion> detallecis = _dbContext.Performanceregionanual(idrol, anio, mes, compania, monedadestino);
            return await detallecis;
        }
        public async Task<Ranking_Lista> Performanceregion_detalle(int idrol, int anio, string mes, int compania, int monedadestino, int ciudadid)
        {
            decimal poo = Convert.ToInt32(ciudadid);
            Task<Ranking_Lista> detallecis = _dbContext.Performanceregion_detalle(idrol, anio, mes, compania, monedadestino, poo);
            return await detallecis;
        }






        public async Task<Margen_bruto> Margenbruto_region(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Task<Margen_bruto> detallecis = _dbContext.Margen_bruto_region(idrol, anio, mes, compania, monedadestino);
            return await detallecis;
        }
 



        public async Task<Margen_bruto> Margenbruto_top5(int idrol, int anio, string mes, int compania, int monedadestino)
        {
            Task<Margen_bruto> detallecis = _dbContext.Margen_bruto_top5(idrol, anio, mes, compania, monedadestino);
            return await detallecis;
        }



     


    


    }
}
