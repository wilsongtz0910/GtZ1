using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class DatosInicioDAL
    {
        public List<eConpaniaslista> CargarCompaniasDAL()
        {        
         List<eConpaniaslista> c = new List<eConpaniaslista>();
                MySqlCommand comando = new MySqlCommand(
                string.Format("SELECT codcom,nomcom FROM descfcom;"), ClsBd.ConexionBdInicialOpen());
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    c.Add(new eConpaniaslista { Codcom = leer.GetString("codcom"), Nomcom = leer.GetString("nomcom") });
                }
                leer.Dispose();
                return c;
        }
    }
}
