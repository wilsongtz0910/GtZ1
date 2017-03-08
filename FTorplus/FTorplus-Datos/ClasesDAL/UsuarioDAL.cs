using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class UsuarioDAL
    {
        public static List<eNomusuario> CargarNombreUsuarioDAL(string codUsu, string compania)
        {
            List<eNomusuario> n = new List<eNomusuario>();
            MySqlCommand comando = new MySqlCommand(string.Format("SELECT nomusu FROM descfusu WHERE codusu = '{0}'", codUsu), ClsBd.ConexionBdInicialOpenCambio(compania));
            MySqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                n.Add(new eNomusuario { NomUsu = leer.GetString("nomusu") });
            }
            leer.Dispose();
            return n;
        }

        //public static void parametrosConexion(string basedatos,string codusu)
        //{
        //    Datos.clsBD.conUsuario(basedatos, codusu);
        //}

        public static List<eFormularios> FormulariosUsuarioDAL(string basedatos, string codusu)
        {
            List<eFormularios> f = new List<eFormularios>();
            MySqlCommand comando = new MySqlCommand(string.Format(
            "SELECT a.grupo,c.codopcion,c.descripcion,c.nombre_form " +
            "FROM {0}.ftorres_descfusu a " +
            "INNER JOIN {0}.ftorres_descfder b ON a.codusu = b.codusuario " +
            "INNER JOIN companias.ftorrmenu c ON b.codopcion = c.codopcion " +
            "WHERE a.codusu = {1}", basedatos, codusu), ClsBd.ConUsuarioOpen());
            MySqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                f.Add(new eFormularios
                {
                    CodOpcion = leer.GetString("codopcion"),
                    Descripcion = leer.GetString("descripcion"),
                    NomForm = leer.GetString("nombre_form")
                });
            }
            ClsBd.ConexionBdInicialClosed();
            return f;
        }

        public static List<eUsuario> VerificarUsuariosDAL(string compania, string codusu, string clave)
        {
            List<eUsuario> u = new List<eUsuario>();
            MySqlCommand comando = new MySqlCommand(string.Format(
            "SELECT b.cod_grupo,b.nom_grupo,a.estado,IF(ISNULL(a.firma),'',a.firma) firma, " +
            "a.ruta_pdf,CONCAT('{0}','_',a.codusu) nomUserCone, a.clave_ft " +
            "FROM descfusu a " +
            "INNER JOIN desmagrusu b ON a.grupo = b.cod_grupo " +
            "WHERE a.codusu = '{1}'	AND a.clave_ft = MD5('{2}')", compania, codusu, clave), ClsBd.ConexionBdInicialOpenCambio(compania));
            MySqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                u.Add(new eUsuario
                {
                    CodGrupo = leer.GetString("cod_grupo"),
                    NomGrupo = leer.GetString("nom_grupo"),
                    Estado = leer.GetInt32("estado"),
                    Firma = leer.GetString("firma"),
                    RutaPdf = leer.GetString("ruta_pdf"),
                    UserMysql = leer.GetString("nomUserCone"),
                    PassMysql = leer.GetString("clave_ft")
                });
            }
            leer.Dispose();
            return u;
        }


        /*ublic static fUsuario verificarUsuarios(string compania, string codusu, string clave)
        {
            Datos.DefinicionDatos.comp01Entities db1 = new Datos.DefinicionDatos.comp01Entities();
            return (from usu in db1.descfusu
                    join grupoUsu in db1.desmagrusu on usu.GRUPO equals grupoUsu.COD_GRUPO
                    where usu.CODUSU == codusu && usu.CLAVE_FT == clave
                    select new fUsuario
                    {
                        codGrupo = grupoUsu.CO D_GRUPO,
                        nomGrupo = grupoUsu.NOM_GRUPO,
                        estado = usu.ESTADO.Value,
                        firma = usu.FIRMA,
                        rutaPdf = usu.RUTA_PDF,
                        userMysql = compania + "_" + usu.CODUSU,
                        passMysql = usu.CLAVE_FT

                    }).FirstOrDefault();
        }
        */
    }    
}
