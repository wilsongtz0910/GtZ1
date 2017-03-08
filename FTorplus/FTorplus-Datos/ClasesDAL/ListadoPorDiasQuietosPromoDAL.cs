using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FTorplus_Entidades;

namespace FTorplus_Datos.ClasesDAL
{
    public class ListadoPorDiasQuietosPromoDAL
    {
        public static List<eListaDiasQuietosPromo> generarListaDAL(double incpro, string codcla, string grupos, string codlis)
        {
            List<eListaDiasQuietosPromo> l = new List<eListaDiasQuietosPromo>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    string.Format("SELECT B.codref,B.nomref,DATEDIFF(CURDATE(),A.ult_fec_com) diasquieto," +
                    "A.lote,A.ubicacion,COUNT(A.ubicacion) vecesvendido,A.existen,C.stock_min,G.vlrlist,B.dscto_max," +
                    "G.vlrlist-(G.vlrlist*(B.dscto_max/100)) precioventa,E.costo*(ABS({0}/100-1)) preciopromo," +
                    "(E.costo*(ABS({0}/100-1)))*A.existen vlrtotalpromo " +
                    "FROM ft_inv_sl_ubi A " +
                    "INNER JOIN desmaref B ON A.codref = B.codref " +
                    "INNER JOIN ft_inv_mv_stock C ON A.codref = C.codref " +
                    "INNER JOIN desmvcla D ON A.codref = D.codref " +
                    "INNER JOIN desslref E ON A.codref = E.codref " +
                    "INNER JOIN desmagru F ON D.codgrupo = F.codgrupo " +
                    "INNER JOIN ft_ped_mv_pre G ON A.codref = G.codref " +
                    "WHERE D.codcla = '{1}' " +
                    "AND G.codlis = '{2}' " +
                    "AND F.codgrupo IN ('{3}') " +
                    "AND A.existen > 0 " +
                    "GROUP BY A.codref " +
                    "ORDER BY B.nomref;", incpro, codcla, codlis, grupos), ClsBd.ConUsuarioOpen());
                MySqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    l.Add(new eListaDiasQuietosPromo
                    {
                        Codref = leer.GetString("codref"),
                        Nomref = leer.GetString("nomref"),
                        DiasQuieto = leer.GetString("diasquieto"),
                        Ubicacion = leer.GetString("ubicacion"),
                        VecesVendido = leer.GetString("vecesvendido"),
                        Lote = leer.GetString("lote"),
                        Existencia = leer.GetString("existen"),
                        StockMin = leer.GetString("stock_min"),
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
