using System.Collections.Generic;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;

namespace FTorplus_Logica
{
    public class Clasificacion
    {
        private ClasificacionDAL _clasificacion = new ClasificacionDAL();
        public List<eClasificacion> ListarClasificaciones()
        {
            return _clasificacion.ListarClasificaciones();
        } 
    }
}
