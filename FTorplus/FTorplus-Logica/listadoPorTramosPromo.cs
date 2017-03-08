using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;

namespace FTorplus_Logica
{
    public class ListadoPorTramosPromo
    {
        public StringBuilder mensaje = new StringBuilder();

        private listadoPorTramosPromoDAL listadoPorTramosPromoDAL = new listadoPorTramosPromoDAL();
        public List<eListaTramosPromo> GenerarLista(int incpro, string codcla, string grupoini, string grupofin, string codlis, int ranExiIni, int ranExiFin)
        {
            if (ValidacionesPorClasificacion(incpro, codcla, grupoini, grupofin, codlis, ranExiIni, ranExiFin))
            {
                return listadoPorTramosPromoDAL.Generarlista(incpro, codcla, grupoini, grupofin, codlis, ranExiIni, ranExiFin);
            }
            else
            {
                return null;
            }
        }
        public List<eListaTramosPromo> GenerarLista(int incpro, string codref, string codlis, int ranExiIni, int ranExiFin)
        {
            if (ValidacionPorReferencia(incpro, codref, codlis, ranExiIni, ranExiFin) == true)
            {
                return listadoPorTramosPromoDAL.Generarlista(incpro, codref, codlis, ranExiIni, ranExiFin);
            }
            else
            {
                return null;
            }
        }

        //VALIDACIONES POR CLASIFICACION
        private bool ValidacionesPorClasificacion(int incpro, string codcla, string grupoini, string grupofin, string codlis, int ranExiIni, int ranExiFin)
        {
            if (incpro <= 0)
            {
                mensaje.Append("Digite un porcentage de incremento valido");
                return false;
            }
            if (string.IsNullOrEmpty(codcla))
            {
                mensaje.Append("Debe elegir una clasificacion");
                return false;
            }
            if (string.IsNullOrEmpty(grupoini))
            {
                mensaje.Append("Seleccione desde que grupo se hara la consulta");
                return false;
            }            
            if (string.IsNullOrEmpty(grupofin))
            {
                mensaje.Append("Seleccione hasta que grupo se hara la consulta");                
                return false;
            }
            if (codlis == "Seleccione una lista")
            {
                mensaje.Append("Seleccione Una Lista de Precios");
                return false;
            }
            if (ranExiIni > ranExiFin)
            {
                mensaje.Append("El Rango de inicio debe ser menor que el rango final");
                return false;
            }            
            return true;
        }
        //VALIDACIONES POR REFERENCIA
        private bool ValidacionPorReferencia(int incpro, string codref, string codlis, int ranExiIni, int ranExiFin)
        {
            if (incpro <= 0)
            {
                mensaje.Append("Digite un porcentage de incremento valido");
                return false;
            }
            if (string.IsNullOrEmpty(codref))
            {
                mensaje.Append("Debe digitar un porcentaje valido de incremento para promoción");                
                return false;
            }
            if (codlis == "Seleccione una lista")
            {
                mensaje.Append("Seleccione Una Lista de Precios");
                return false;
            }
            if (ranExiIni > ranExiFin)
            {
                mensaje.Append("El Rango de inicio debe ser menor que el rango final");                
                return false;
            }            
            return true;
        }
    }         
}

