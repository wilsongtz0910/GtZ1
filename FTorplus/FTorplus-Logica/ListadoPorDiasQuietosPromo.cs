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
    public class ListadoPorDiasQuietosPromo
    {
        public  List<eListaDiasQuietosPromo> generarLista(double incpro, string codcla, string grupos, string codlis)
        {
            return ListadoPorDiasQuietosPromoDAL.generarListaDAL(incpro, codcla, grupos, codlis);
        }
    }
}
