using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraBars.Navigation;
using FTorplus_Entidades;
using FTorplus_Logica;

namespace FTorplus.Presentacion
{
    public partial class FrmMenu : DevExpress.XtraEditors.XtraForm
    {
        public FrmMenu(string basedatos,string codusu)
        {
            InitializeComponent();
            CodigoUsuario = codusu;
            BaseDeDatos = basedatos;
        }
        public string CodigoUsuario;
        public string BaseDeDatos;

        private readonly Usuario usuario = new Usuario();

        public AccordionControlElement Item;
        private void frmMenu_Load(object sender, EventArgs e)
        {
            gMenu.Expanded = false;
            gDatosBasico.Expanded = false;
            List<eFormularios> f = usuario.FormulariosUsuario(BaseDeDatos, CodigoUsuario);
            foreach (eFormularios formu in f)
            {
                Item = new AccordionControlElement(ElementStyle.Item);
                Item.Text = formu.Descripcion;
                Item.Name = formu.NomForm;
                Item.Tag = formu.NomForm;
                Item.Click += new EventHandler(item_Click);

                gMenu.Elements.Add(Item);
            }
        }

        //Este evento aplica aplica a todos los elementos del control
        private void listaOpciones_ElementClick(object sender, ElementClickEventArgs e)
        {            
            //try
            //{
            //    string name = listaOpciones.Elements.Element.Name;
            //    MessageBox.Show(name);
            //    Assembly asm = Assembly.GetEntryAssembly();
            //    Type formtype = asm.GetType(string.Format("FTorplus.Presentacion.{0}", name));

            //    Form formu = (Form)Activator.CreateInstance(formtype);
            //    formu.MdiParent = this;
            //    formu.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }       
        void item_Click(object sender, EventArgs e)
        {            
            
        }

        private void btnListPorTramos_Click(object sender, EventArgs e)
        {
            Presentacion.FrmListPorTramosPromo frmListaTramos = Presentacion.FrmListPorTramosPromo.Instacia();
            frmListaTramos.MdiParent = this;
            frmListaTramos.Show();
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        { 
            Presentacion.FrmCiudades frmCiudades = Presentacion.FrmCiudades.Instacia();
            frmCiudades.MdiParent = this;
            frmCiudades.Show();
        }

        private void btnListPorDiasQuietos_Click(object sender, EventArgs e)
        {
            Presentacion.frmListPorDiasQuietoPromo frmDiasQuietos = new Presentacion.frmListPorDiasQuietoPromo();
            frmDiasQuietos.MdiParent = this;
            frmDiasQuietos.Show();
        }
        
        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea cerrar el programa?","Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
