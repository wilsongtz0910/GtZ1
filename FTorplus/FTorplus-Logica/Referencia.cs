using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;

namespace FTorplus_Logica
{
    public class Referencia
    {        
        public List<eReferenciaMarca> ListarReferencias()
        {
            return ReferenciaDAL.CargarReferenciaDAL();
        }
        public List<eReferencia> CargarDescripcion(string codref)
        {
            return ReferenciaDAL.CargarDescripcionDAL(codref);
        }


        //ENTITY CUANDO LA CONEXION SEA LOCAL
        //public static List<fReferenciaMarca> cargarReferencia()
        //{
        //    using (Datos.DefinicionDatos.comp01Entities db = new Datos.DefinicionDatos.comp01Entities())
        //    {
        //        List<fReferenciaMarca> referencias = (from refe in db.desmaref
        //                                         join cla in db.desmvcla on refe.codref equals cla.codref
        //                                         join gru in db.desmagru on cla.CODGRUPO equals gru.CODGRUPO
        //                                         orderby refe.NOMREF
        //                                         where cla.CODCLA == "02"
        //                                        select new fReferenciaMarca
        //                                         {
        //                                             codref = refe.codref,
        //                                             nomref = refe.NOMREF,
        //                                             referencia = refe.REFERENCIA,
        //                                             nomgrupo = gru.NOMGRUPO
        //                                         }).ToList();
        //        return referencias;
        //    }
        //}
    }
}
