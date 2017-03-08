using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTorplus_Entidades
{   
    public class eUsuario
    {
        public string CodGrupo { set; get; }
        public string NomGrupo {set; get; }
        public int Estado { set; get; }
        public string Firma { set; get; }
        public string RutaPdf { set; get; }
        public string UserMysql { set; get; }
        public string PassMysql { set; get; }
    }
    public class eNomusuario
    {
        public string NomUsu { set; get; }
    }
}
