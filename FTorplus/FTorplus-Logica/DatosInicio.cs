using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;

namespace FTorplus_Logica
{
    public class DatosInicio
    {
        private DatosInicioDAL _datosInicio = new DatosInicioDAL();

        public List<eConpaniaslista> CargarCompanias()
        {
            return _datosInicio.CargarCompaniasDAL();
        }
    }
}
