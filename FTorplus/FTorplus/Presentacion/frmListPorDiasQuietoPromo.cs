using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTorplus_Entidades;
using FTorplus_Logica;

namespace FTorplus.Presentacion
{
    public partial class frmListPorDiasQuietoPromo : Form
    {

        public frmListPorDiasQuietoPromo()
        {
            InitializeComponent();
        }
        private void frmListPorDiasQuietoPromo_Load(object sender, EventArgs e)
        {
            OcultarColumnas();
            CargarClasificacion();
            CargarListas();
        }

        private readonly Clasificacion clasificacion = new Clasificacion();
        private readonly Grupo grupo = new Grupo();
        private readonly ListaPrecio lp = new ListaPrecio();
        private readonly ListadoPorDiasQuietosPromo listTramos = new ListadoPorDiasQuietosPromo();
        private void CargarClasificacion()
        {
            List<eClasificacion> c = clasificacion.ListarClasificaciones(); 
            if (c.Count <= 0)
            {
                XtraMessageBox.Show("Error al cargar las clasificaciones");
            }
            else
            {
                listaCodCla.Properties.DataSource = c;
                listaCodCla.Properties.ValueMember = "Codcla";
                listaCodCla.Properties.DisplayMember = "Nomcla";
            }
        }        
        private void CargarGrupo(string codcla)
        {
            List<eGrupo> a = grupo.listarGrupos(codcla);
            if (a.Count <= 0)
            {
                XtraMessageBox.Show("Esta clasificacion no tiene grupos");
            }
            else
            {
                ListaGrupos.Properties.DataSource = a;
                ListaGrupos.Properties.ValueMember = "Codgrupo";
                ListaGrupos.Properties.DisplayMember = "Nomgrupo";
            }
        }
        private void CargarListas()
        {
            List<eListaPrecio> a = lp.CargarListasPrecio();
            if (a.Count <= 0)
            {
                XtraMessageBox.Show("No hay Listas Creadas en el Maestro");
            }
            else
            {
                listaPrecio.Properties.NullText = "Seleccione una lista";
                listaPrecio.Properties.DataSource = a;
                listaPrecio.Properties.DisplayMember = "Nomlis";
                listaPrecio.Properties.ValueMember = "Codlis";
            }
        }
        private void listaCodCla_EditValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.listaCodCla.EditValue.ToString()))
            {
                ListaGrupos.ResetText();
            }
            else
            {
                CargarGrupo(this.listaCodCla.EditValue.ToString());
            }
        }
        private static int incPromo;
        private static string codlis;
        private static string grupos;

        private void AsignarValores()
        {
            incPromo = int.Parse(txtIncrePromo.Text);
            codlis = listaPrecio.EditValue.ToString();
            ListaGrupos.Properties.SeparatorChar = ',';
            grupos = ListaGrupos.EditValue.ToString();
        }

        private void OcultarColumnas()
        {
            if (chkDiasQuietos.Checked == true)
            {
                gridViewListaDiasQuieto.Columns[2].Visible = true;
            }
            else
	        {
                gridViewListaDiasQuieto.Columns[2].Visible = false;
	        }
            if (chkStockMin.Checked == true)
            {
                gridViewListaDiasQuieto.Columns[7].Visible = true;
            }
            else
            {
                gridViewListaDiasQuieto.Columns[7].Visible = false;
            }
        }
        private void chkDiasQuietos_CheckedChanged(object sender, EventArgs e)
        {
            OcultarColumnas();
        }
        private void chkStockMin_CheckedChanged(object sender, EventArgs e)
        {
            OcultarColumnas();
        }

        private bool Validacion()
        {
            if (String.IsNullOrEmpty(listaCodCla.Text))
            {
                XtraMessageBox.Show("Debe seleccionar una clasificacion", "Validacion de datos");
                listaCodCla.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ListaGrupos.Text))
            {
                XtraMessageBox.Show("Debe seleccionar uno ó mas grupos", "Validacion de datos");
                ListaGrupos.Focus();
                return false;
            }
            if (listaPrecio.Text == "Seleccione una lista")
            {
                XtraMessageBox.Show("Seleccione Una Lista de Precios", "Validacion de datos");
                listaPrecio.Focus();
                return false;
            }              
            return true;
        }
        private void HabilitarBotones()
        {
            btnNueBusqueda.Enabled = true;
            btnVerPantalla.Enabled = true;
            btnExcel.Enabled = true;
            btnPdf.Enabled = true;
        }
        private void DesabilitarBotones()
        {
            btnVerPantalla.Enabled = false;
            btnExcel.Enabled = false;
            btnPdf.Enabled = false;
        }
        private void NuevaBusqueda()
        {
            gridControlListaDiasQuietos.DataSource = null;
            listaCodCla.Text = "";
            ListaGrupos.EditValue = null;
            ListaGrupos.Text = "";
            listaPrecio.EditValue = null;
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                AsignarValores();
                List<eListaDiasQuietosPromo> resultado = listTramos.generarLista(incPromo, listaCodCla.EditValue.ToString(), grupos, listaPrecio.EditValue.ToString());
                if (resultado.Count == 0)
                {
                    XtraMessageBox.Show("Esta consulta no a devuelto ningun resultado","FTorplus");
                    gridControlListaDiasQuietos.DataSource = null;
                }
                else
                {
                    gridControlListaDiasQuietos.DataSource = resultado;
                    gridViewListaDiasQuieto.BestFitColumns();
                    HabilitarBotones();
                }
            }
        }

        private void btnNueBusqueda_Click(object sender, EventArgs e)
        {
            DesabilitarBotones();
            NuevaBusqueda();
        } 
    }
}

