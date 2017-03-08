using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTplus_Presentacion.Utilidades
{
    public static class Utilitarios
    {
        public static String formatearTextoIN(string cadenaDeEntrada)
        {
            string res = "";            
            char[] caracteresDelimitadores = { ',','.',':','\t' };
            string[] palabras = cadenaDeEntrada.Split(caracteresDelimitadores);
            foreach (string s in palabras)
            {
                res += @"'" + s.Trim() + @"',";
            }            
            return res.Substring(0,res.Length-1);
        }    
    }
}
