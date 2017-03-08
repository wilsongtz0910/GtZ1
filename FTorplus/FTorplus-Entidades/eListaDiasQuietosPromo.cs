using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTorplus_Entidades
{
    public class eListaDiasQuietosPromo
    {
        public string Codref { set; get; }
        public string Nomref { set; get; }
        public string DiasQuieto { set; get; }
        public string Lote { set; get; }
        public string Ubicacion { set; get; }
        public string VecesVendido { set; get; }
        public string Existencia { set; get; }        
        public string StockMin { set; get; }
        public double PrecioLista { set; get; }
        public string Descuento { set; get; }
        public double PrecioVenta { set; get; }
        public double PrecioPromo { set; get; }
        public double ValorTotal { set; get; }        
    }
}
