using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class GrupoDAL
    {
        public List<eGrupo> CargarGrupo(string codcla)
        {
            List<eGrupo> c = new List<eGrupo>();
            string q = string.Format("SELECT codgrupo,nomgrupo FROM desmagru WHERE codcla = '{0}';",codcla);
            using (MySqlCommand comando = new MySqlCommand(q, ClsBd.ConUsuarioOpen()))
            {
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    c.Add(new eGrupo { Codgrupo = leer.GetString("codgrupo"), Nomgrupo = leer.GetString("nomgrupo") });
                }
            }
            return c;
        }
        public void CrearGrupo(eGrupo nuevoGrupo)
        {
            string q = string.Format("INSERT INTO desmagru (codgrupo,nomgrupo) VALUES ('{0}','{1}');",nuevoGrupo.Codgrupo,nuevoGrupo.Nomgrupo);
            using (MySqlCommand comando = new MySqlCommand(q, ClsBd.ConUsuarioOpen()))
            {
                comando.ExecuteNonQuery();
            }
            
        }
        public void ActualizarGrupo(eGrupo Grupo)
        {
            string q = string.Format("UPDATE desmagru SET nomgrupo = '{0}' WHERE codgrupo = '{1}');", Grupo.Nomgrupo,Grupo.Codgrupo);
            using (MySqlCommand comando = new MySqlCommand(q, ClsBd.ConUsuarioOpen()))
            {
                comando.ExecuteNonQuery();
            }

        }
    }
}
