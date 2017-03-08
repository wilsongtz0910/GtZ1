using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTorplus_Entidades;
using FTorplus_Datos.ClasesDAL;

namespace FTorplus_Logica
{
    public class Grupo
    {
        private GrupoDAL _grupoDAL = new GrupoDAL();
        
        public List<eGrupo> listarGrupos(string codcla)
        {
            return _grupoDAL.CargarGrupo(codcla);
        }
        public void CrearGrupos(eGrupo grupo)
        {            
            _grupoDAL.CrearGrupo(grupo);
        }
        public void ActualizarGrupo(eGrupo grupo) 
        {
            _grupoDAL.ActualizarGrupo(grupo);
        }
    }
}
