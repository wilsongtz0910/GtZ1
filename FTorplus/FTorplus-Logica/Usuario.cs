using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;

namespace FTorplus_Logica
{
    public class Usuario
    {
        public List<eNomusuario> CargarNombreUsuario(string codUsu, string compania)
        {
            return UsuarioDAL.CargarNombreUsuarioDAL(codUsu, compania);
        }
        public List<eFormularios> FormulariosUsuario(string basedatos, string codusu)
        {
            return UsuarioDAL.FormulariosUsuarioDAL(basedatos, codusu);
        }
        public List<eUsuario> VerificarUsuarios(string compania, string codusu, string clave)
        {
            return UsuarioDAL.VerificarUsuariosDAL(compania, codusu, clave);
        }

        /*ublic fUsuario verificarUsuarios(string compania, string codusu, string clave)
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