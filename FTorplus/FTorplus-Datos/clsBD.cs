using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.EntityClient;
using System.Data;

namespace FTorplus_Datos
{
    public class ClsBd
    {
        #region CONEXION INICIAL

        private static MySqlConnection conexionIni = new MySqlConnection();
        public static MySqlConnection ConexionBdInicialOpen()
        {
            string server = "172.0.0.132";
            string basedatos = "companias";
            string usuario = "conexion_inicial";
            string contraseña = "**Admin**";
            if (conexionIni.State == System.Data.ConnectionState.Closed)
            {
                conexionIni.ConnectionString = string.Format("server={0}; database={1}; Uid={2}; pwd={3};",server,basedatos,usuario,contraseña);
                conexionIni.Open();
            }
            return conexionIni;
        }
        public static MySqlConnection ConexionBdInicialOpenCambio(string basedatos)
        {
            try
            {
                if (conexionIni.State == System.Data.ConnectionState.Open)
                {
                    conexionIni.ChangeDatabase(basedatos);
                }                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return conexionIni;
        }
        public static MySqlConnection ConexionBdInicialClosed()
        {
            try
            {
                conexionIni.Close();
                conexionIni.ClearAllPoolsAsync();
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return conexionIni;
        }

        #endregion

        #region CONXECION DEL USUARIO

        public static MySqlConnection ConUsuario = new MySqlConnection();
        public static MySqlConnection ConUsuarioOpen()
        {
            string baseDatos = "COMP01";
            string codUsu = "999";
            string server = "172.0.0.132";
            string contraseña = "masterkey";
            if (ConUsuario.State == System.Data.ConnectionState.Open)
            {
                return ConUsuario;
            }
            else
            {
                try
                {
                    ConUsuario.ConnectionString = (string.Format("server={0}; database={1}; Uid={2}; pwd={3};", server, baseDatos, baseDatos + "_" + codUsu, contraseña));
                    ConUsuario.Open();                    
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            return ConUsuario;
        }
        //public static MySqlConnection ConUsuarioConsultas()
        //{
        //    if (ConUsuario.State == System.Data.ConnectionState.Open)
        //    {
        //        ConUsuario.Close();
        //    }
        //    ConUsuario.Open();
        //    return ConUsuario;
        //}
       
        public static void ConUsuarioClosed()
        {
            if (ConUsuario != null)//si hay conexion procedo a cerrarla.
            {
                if (ConUsuario.State == System.Data.ConnectionState.Open)
                {
                    ConUsuario.Close();
                }
            }
        }
        #endregion
    }
}
