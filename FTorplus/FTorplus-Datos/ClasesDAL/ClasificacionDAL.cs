using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class ClasificacionDAL
    {
        public List<eClasificacion> ListarClasificaciones()
        {
            List<eClasificacion> c = new List<eClasificacion>();
            string q = string.Format("SELECT codcla,nomcla FROM desmacla WHERE codcla = '01';");
            using (MySqlCommand comando = new MySqlCommand(q, ClsBd.ConUsuarioOpen()))
            {
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    c.Add(new eClasificacion { Codcla = leer.GetString("codcla"), Nomcla = leer.GetString("nomcla") });
                }
            }
            return c;
        }
    }
}
