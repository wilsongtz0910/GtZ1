using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTorplus_Entidades;
using FTorplus_Logica;

namespace FTorplus.Presentacion
{
    public partial class FrmCiudades : DevExpress.XtraEditors.XtraForm
    {
        private readonly Ciudades ciudades = new Ciudades();

        public FrmCiudades()
        {
            InitializeComponent();
        }
        //PATRON SINGLENTON
        private static FrmCiudades instanciaForm = null;
        public static FrmCiudades Instacia()
        {
            if (instanciaForm == null)
            {
                instanciaForm = new FrmCiudades();
            }
            instanciaForm.BringToFront();
            return instanciaForm;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            instanciaForm = null;
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            grdCiudades.DataSource = ciudades.CargarCiudades();
        }
    }
}