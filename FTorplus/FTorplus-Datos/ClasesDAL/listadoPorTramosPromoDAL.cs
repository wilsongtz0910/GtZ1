using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class listadoPorTramosPromoDAL
    {
        /// <summary>
        /// Busqueda por clasificacion
        /// </summary>
        /// <param name="incpro"></param>
        /// <param name="codcla"></param>
        /// <param name="grupoini"></param>
        /// <param name="grupofin"></param>
        /// <param name="codlis"></param>
        /// <param name="ranExiIni"></param>
        /// <param name="ranExiFin"></param>
        /// <returns></returns>
        public List<eListaTramosPromo> Generarlista(int incpro, string codcla, string grupoini, string grupofin, string codlis, int ranExiIni, int ranExiFin)
        {
            List<eListaTramosPromo> l = new List<eListaTramosPromo>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    string.Format("SELECT b.codref,b.nomref,a.ubicacion,a.lote,a.existen,c.vlrlist,b.dscto_max, " +
                    "c.vlrlist-(c.vlrlist*(b.dscto_max/100)) precioventa, f.costo*(ABS({0}/100-1)) preciopromo, " +
                    "(f.costo*(ABS({0}/100-1)))*a.existen vlrtotalpromo " +
                    "FROM desslubi a " +
                    "INNER JOIN desmaref b ON a.codref = b.codref " +
                    "INNER JOIN desslref c ON a.codref = c.codref " +
                    "INNER JOIN desmvcla d ON a.codref = d.codref " +
                    "INNER JOIN desslref f ON a.codref = f.codref AND f.ano=YEAR(CURDATE()) " +
                    "INNER JOIN desmagru g ON d.codgrupo = g.codgrupo " +
                    "WHERE d.codcla = '{1}' " +
                    "AND  d.codgrupo BETWEEN '{2}' AND '{3}' " +
                    "AND c.codlis = '{4}' " +
                    "AND a.existen BETWEEN {5} AND {6} " +
                    "ORDER BY b.nomref;", incpro, codcla, grupoini, grupofin, codlis, ranExiIni, ranExiFin), ClsBd.ConUsuarioOpen());
                MySqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    l.Add(new eListaTramosPromo
                    {
                        Codref = leer.GetString("codref"),
                        Nomref = leer.GetString("nomref"),
                        Ubicacion = leer.GetString("ubicacion"),
                        Lote = leer.GetString("lote"),
                        Existencia = leer.GetString("existen"),
                        PrecioLista = leer.GetDouble("vlrlist"),
                        Descuento = leer.GetString("dscto_max"),
                        PrecioVenta = leer.GetDouble("precioventa"),
                        PrecioPromo = leer.GetDouble("preciopromo"),
                        ValorTotal = leer.GetDouble("vlrtotalpromo")
                    });
                }
                return l;
            }
            catch (MySqlException ex)
            {
                return l;
            }
        }
        /// <summary>
        /// Busqueda por referencia
        /// </summary>
        /// <param name="incpro"></param>
        /// <param name="codref"></param>
        /// <param name="codlis"></param>
        /// <param name="ranExiIni"></param>
        /// <param name="ranExiFin"></param>
        /// <returns></returns>
        public List<eListaTramosPromo> Generarlista(int incpro, string codref, string codlis, int ranExiIni, int ranExiFin)
        {
            List<eListaTramosPromo> l = new List<eListaTramosPromo>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    string.Format("SELECT b.codref,b.nomref,a.ubicacion,a.lote,a.existen,c.vlrlist,b.dscto_max, " +
                    "c.vlrlist-(c.vlrlist*(b.dscto_max/100)) precioventa, f.costo*(ABS({0}/100-1)) preciopromo, " +
                    "(f.costo*(ABS({0}/100-1)))*a.existen vlrtotalpromo " +
                    "FROM desslubi a " +
                    "INNER JOIN desmaref b ON a.codref = b.codref " +
                    "INNER JOIN desmvlis c ON a.codref = c.codref " +
                    "INNER JOIN desslref f ON a.codref = f.codref AND f.ano=YEAR(CURDATE()) " +
                    "WHERE b.codref = '{1}' " +
                    "AND c.codlis = '{2}' " +
                    "AND a.existen BETWEEN {3} AND {4} " +
                    "ORDER BY b.nomref;", incpro, codref, codlis, ranExiIni, ranExiFin), ClsBd.ConUsuarioOpen());
                MySqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    l.Add(new eListaTramosPromo
                    {
                        Codref = leer.GetString("codref"),
                        Nomref = leer.GetString("nomref"),
                        Ubicacion = leer.GetString("ubicacion"),
                        Lote = leer.GetString("lote"),
                        Existencia = leer.GetString("existen"),
                        PrecioLista = leer.GetDouble("vlrlist"),
                        Descuento = leer.GetString("dscto_max"),
                        PrecioVenta = leer.GetDouble("precioventa"),
                        PrecioPromo = leer.GetDouble("preciopromo"),
                        ValorTotal = leer.GetDouble("vlrtotalpromo")
                    });
                }
                return l;
            }
            catch (MySqlException ex)
            {
                return l;
            }
        }   
    }
}
