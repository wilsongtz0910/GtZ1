using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class ReferenciaDAL
    {
        public static List<eReferenciaMarca> CargarReferenciaDAL()
        {
            List<eReferenciaMarca> a = new List<eReferenciaMarca>();
            string q = string.Format("SELECT a.codref,a.nomref,a.referencia,c.nomgrupo " +
                           "FROM desmaref a " +
                           "INNER JOIN desmvcla b ON a.codref=b.codref AND b.codcla = '02' " +
                           "INNER JOIN desmagru c ON b.codgrupo=c.codgrupo " +
                           "ORDER BY a.nomref");
            using (MySqlCommand comando = new MySqlCommand(q, ClsBd.ConUsuarioOpen()))
            {
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    a.Add(new eReferenciaMarca
                    {
                        Codref = leer.GetString("codref"),
                        Nomref = leer.GetString("nomref"),
                        Referencia = leer.GetString("referencia"),
                        Nomgrupo = leer.GetString("nomgrupo")
                    });
                }
            }            
            return a;
        }
        public static List<eReferencia> CargarDescripcionDAL(string codref)
        {
            List<eReferencia> a = new List<eReferencia>();
            MySqlCommand comando = new MySqlCommand(
            string.Format("SELECT nomref FROM desmaref WHERE codref = '{0}';", codref), ClsBd.ConUsuarioOpen());
            MySqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                a.Add(new eReferencia { Nomref = leer.GetString("nomref") });
            }
            return a;
        }
    }
}
