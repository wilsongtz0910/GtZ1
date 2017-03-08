using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;


namespace FTorplus_Logica
{
    public class ListaPrecio
    {
        public List<eListaPrecio> CargarListasPrecio()
        {
            return ListaPrecioDAL.CargarListasPrecioDAL();
        }
    }
}
