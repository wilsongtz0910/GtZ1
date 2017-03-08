using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTorplus_Entidades;
using FTorplus_Logica;

namespace FTorplus.Presentacion
{
    public partial class FrmInicio : DevExpress.XtraEditors.XtraForm
    {
        public static string UsuInicia { set; get; }
        public FrmInicio()
        {
            InitializeComponent();
        }

        private readonly Usuario usuario = new Usuario();
        private readonly DatosInicio datosInicio = new DatosInicio();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }
        private void CargarDatosIniciales()
        {         
            listaCom.Properties.DataSource = datosInicio.CargarCompanias();
            listaCom.Properties.ValueMember = "Codcom";
            listaCom.Properties.DisplayMember = "Nomcom";
            listaCom.ItemIndex = 0;           
            conFechaSis.EditValue = DateTime.Now;
            txtAnoPeriCon.EditValue = DateTime.Now.Year;
            txtNumMesPeriCon.EditValue = DateTime.Now.Month;
        }

        private void CargarMenu()
        {
            this.Hide();
            FrmMenu menu = new FrmMenu(listaCom.EditValue.ToString(),txtCodUsu.Text);
            menu.Show();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            ValidacionUsuario();
        }

        private void ValidacionUsuario()
        {
            List<eUsuario> u = usuario.VerificarUsuarios(listaCom.EditValue.ToString(), txtCodUsu.Text, txtClaveUsu.Text);
            if (string.IsNullOrEmpty(txtCodUsu.Text) || string.IsNullOrEmpty(txtClaveUsu.Text))
            {
                XtraMessageBox.Show("Escriba un codigo y nombre de usuario", "FTorplus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (u.Count() <= 0)
            {
                XtraMessageBox.Show("Contraseña incorecta porfavor verifique", "FTorplus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {                
                CargarMenu();
            }
        }

        private void txtCodUsu_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCodUsu.Text.Length == 3)
            {
                List<eNomusuario> n = usuario.CargarNombreUsuario(txtCodUsu.Text,listaCom.EditValue.ToString());
                if (n.Count <= 0 || txtCodUsu.Text == "")
                {
                    txtNomUsu.Text = "Nombre de Usuario";
                }
                else
                {
                    txtNomUsu.Text = n.FirstOrDefault().NomUsu;
                }
                txtClaveUsu.Focus();
            }
        } 		
    }
}