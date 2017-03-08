using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class CiudadesDAL
    {
        public List<eCiudades> listarCiudades()
        {
            List<eCiudades> c = new List<eCiudades>();
            string q = string.Format("SELECT codciu,nomciu FROM desmaciu;");
                using(MySqlCommand comando = new MySqlCommand(q, ClsBd.ConUsuarioOpen()))
                {
                    MySqlDataReader leer = comando.ExecuteReader();
                    while (leer.Read())
                    {
                        c.Add(new eCiudades { CodCiu = leer.GetString("codciu"), NomCiu = leer.GetString("nomciu") });
                    }                      
                }                
            return c;
        }
    }
}

