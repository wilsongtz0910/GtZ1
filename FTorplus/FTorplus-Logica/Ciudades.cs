using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;

namespace FTorplus_Logica
{
    public class Ciudades
    {
        private CiudadesDAL CiudadesDAL = new CiudadesDAL();
        public List<eCiudades> CargarCiudades()
        {
            return CiudadesDAL.listarCiudades();
        }
    }
}
