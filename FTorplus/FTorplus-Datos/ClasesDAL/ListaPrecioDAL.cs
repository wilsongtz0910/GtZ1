using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class ListaPrecioDAL
    {
        public static List<eListaPrecio> CargarListasPrecioDAL()
        {
            List<eListaPrecio> lp = new List<eListaPrecio>();
            MySqlCommand comando = new MySqlCommand(
            string.Format("SELECT CODLIS,NOMLIS FROM desmalis ORDER BY CODLIS;"), ClsBd.ConUsuarioOpen());
            MySqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                lp.Add(new eListaPrecio { Codlis = leer.GetString("codlis"), Nomlis = leer.GetString("nomlis") });
            }
            return lp;
        }
    }
}
