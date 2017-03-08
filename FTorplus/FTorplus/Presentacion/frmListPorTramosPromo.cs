using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using FTorplus_Entidades;
using FTorplus_Logica;



namespace FTorplus.Presentacion
{
    public partial class FrmListPorTramosPromo : DevExpress.XtraEditors.XtraForm
    {
        private readonly Referencia referencia = new Referencia();
        private readonly Clasificacion clasificacion = new Clasificacion();
        private readonly Grupo grupo = new Grupo();

        private readonly ListaPrecio lp = new ListaPrecio();
        private readonly ListadoPorTramosPromo listPorTramos = new ListadoPorTramosPromo();

        private static List<eListaTramosPromo> resultado;      

        public FrmListPorTramosPromo()
        {
            InitializeComponent();
        }
        //PATRON SINGLENTON
        private static FrmListPorTramosPromo instanciaForm = null;
        public static FrmListPorTramosPromo Instacia()
        {
            if (instanciaForm == null)
            {
                instanciaForm = new FrmListPorTramosPromo();
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
        private void frmListTramosPromocion_Load(object sender, EventArgs e)
        {
            listaGruIni.Properties.NullText = "";
            listaGruFin.Properties.NullText = "";
            CargarClasificacion();
            CargarReferencia();
            CargarListas();
        }
        private void CargarReferencia()
        {
            List<eReferenciaMarca> a = referencia.ListarReferencias();
            if (a.Count <= 0)
            {
                XtraMessageBox.Show("No hay referencia creadas es el sistema","FTorplus");
            }
            else
            {
                //listaBusquedaReferencia.Properties.NullValuePrompt = "Buscar Referencia";
                listaBusquedaReferencia.Properties.ValueMember = "Codref";
                listaBusquedaReferencia.Properties.DisplayMember = "Codref";
                listaBusquedaReferencia.Properties.DataSource = a;
            }
        }
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
                listaGruIni.Properties.DataSource = a;
                listaGruIni.Properties.DisplayMember = "Nomgrupo";
                listaGruIni.Properties.ValueMember = "Codgrupo";
                listaGruFin.Properties.DataSource = a;
                listaGruFin.Properties.DisplayMember = "Nomgrupo";
                listaGruFin.Properties.ValueMember = "Codgrupo";
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
        //CADA VES QUE LA CLASIFICACION CAMBIA SE COONSULTA POR LOS GRUPOS
        //LOS LISTADO DE GRUPOS CARGAN SEGUN LA CLASIFICACION ESCOGIDA
        private void listaCodCla_EditValueChanged_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.listaCodCla.EditValue.ToString()))
            {
                listaGruIni.ResetText();
                listaGruFin.ResetText();
            }
            else
            {
                CargarGrupo(this.listaCodCla.EditValue.ToString());
                listaBusquedaReferencia.Enabled = false;
            }
        }        
        
        //CADA VEZ QUE LA REFERENCIA CAMBIE CONSULTA POR SU DESCRIPCION
        private void busquedaReferencia_EditValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(listaBusquedaReferencia.Text))
            {
                listaCodCla.Enabled = false;
                listaGruIni.Enabled = false;
                listaGruFin.Enabled = false;
            }
            List<eReferencia> a = referencia.CargarDescripcion(listaBusquedaReferencia.Text);
            if (a.Count <= 0)
            {
                txtRefDescrip.Text = "Descripcion de la referencia";
            }
            else
            {
                txtRefDescrip.Text = a.FirstOrDefault().Nomref;
            }
        }
        private void btnNueBusqueda_Click(object sender, EventArgs e)
        {
            DesabilitarCampos();
            gridControlListaTramos.DataSource = null;
            Habilita();            
        }
        private void Habilita()
        {
            listaCodCla.Enabled = true;
            listaCodCla.ResetText();
            listaGruIni.Enabled = true;
            listaGruFin.Enabled = true;
            listaBusquedaReferencia.Enabled = true;
            listaBusquedaReferencia.ResetText();
            txtRefDescrip.Text = "Descripcion de la referencia";
            txtIncrePromo.Text = "5";
            txtRanExisIni.Value = 1;
            txtRanExisFin.Value = 99;
        }
        private void HabilitarCampos()
        {
           btnVerPantalla.Enabled = true;
           btnExcel.Enabled = true;
           btnPdf.Enabled = true;
        }
        private void DesabilitarCampos()
        {
            btnVerPantalla.Enabled = false;
            btnExcel.Enabled = false;
            btnPdf.Enabled = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(listaBusquedaReferencia.Text) && string.IsNullOrEmpty(listaCodCla.Text))
            {
                XtraMessageBox.Show("Debe seleccionar un criterio de busqueda (Clasificacion ó Referencia)", "FTorplus",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);                
            }
            else
            {
                if (listaCodCla.Enabled == true)
                {
                    resultado = listPorTramos.GenerarLista(int.Parse(txtIncrePromo.Text), listaCodCla.EditValue.ToString(), listaGruIni.EditValue.ToString(), listaGruFin.EditValue.ToString(), listaPrecio.EditValue.ToString(), int.Parse(txtRanExisIni.Text), int.Parse(txtRanExisFin.Text));                    
                }
                else
                {
                    if (listaBusquedaReferencia.Enabled == true)
                    {  
                        resultado = listPorTramos.GenerarLista(int.Parse(txtIncrePromo.Text),listaBusquedaReferencia.Text, listaPrecio.EditValue.ToString() , int.Parse(txtRanExisIni.Text), int.Parse(txtRanExisFin.Text));
                    }
                }
                if (resultado==null)
                {
                    XtraMessageBox.Show("Esta consulta no a devuelto ningun resultado","FTorplus");
                    gridControlListaTramos.DataSource = null;
                    DesabilitarCampos();
                }
                else
                {
                    gridControlListaTramos.DataSource = resultado;
                    gridViewListaTramos.BestFitColumns();
                    HabilitarCampos();
                }
            }   
        }    

        private void VisualizarReporte(int opc)
        {
            Reportes.RptListaTramos2 l = new Reportes.RptListaTramos2();
            l.DataSource = resultado;

            var codcla = (String.IsNullOrEmpty(listaCodCla.Text) ? "N/A" : listaCodCla.EditValue.ToString());
            var ranGruIni = (String.IsNullOrEmpty(listaGruIni.Text) ? "N/A" : listaGruIni.EditValue.ToString());
            var ranGruFin = (String.IsNullOrEmpty(listaGruFin.Text) ? "N/A" : listaGruFin.EditValue.ToString());
            var nomclasi = (codcla == "N/A" ? "" : listaCodCla.Text);
            var nomGruIni = (String.IsNullOrEmpty(listaGruIni.Text) ? "N/A" : listaGruIni.Text);
            var nomGruFin = (String.IsNullOrEmpty(listaGruFin.Text) ? "N/A" : listaGruFin.Text);

            if (String.IsNullOrEmpty(listaCodCla.Text))
            {
                l.referenciaOgrupo.Text = "Referencia:";
                l.nomGrupo.Visible = false;
                l.nomReferencia.Text = listaBusquedaReferencia.EditValue.ToString();
            }
            else
            {
                l.nomReferencia.Visible = false;
            }

            l.codCla.Text = codcla;
            l.nomClasi.Text = nomclasi;
            l.ranGrupoIni.Text = ranGruIni;
            l.ranGrupoFin.Text = ranGruFin;
            l.nomGrupoIni.Text = nomGruIni;
            l.nomGrupoFin.Text = nomGruFin;
            l.porCen.Text = txtIncrePromo.EditValue.ToString();
            l.ranExisIni.Text = txtRanExisIni.EditValue.ToString();
            l.ranExisFin.Text = txtRanExisFin.EditValue.ToString();
            l.codLis.Text = listaPrecio.EditValue.ToString();
            

            string tipoArch = "";
            string ruta = "";
            switch (opc)
            {
                case 1://Excel
                    tipoArch = "Libro de excel (*.xls) | *.xlsx";
                    gridViewListaTramos.BestFitColumns();
                    ruta = PedirRuta(tipoArch);
                    if (!string.IsNullOrEmpty(ruta))//Si viene lleno exporta si no, no hace nada
                    {
                        gridControlListaTramos.ExportToXlsx(ruta);
                        Process.Start(Path.Combine(Application.StartupPath, ruta));
                    }                    
                    break;
                case 2://PDF
                    tipoArch = "PDF (*.pdf) | *.pdf";
                    ruta = PedirRuta(tipoArch);
                    if (!string.IsNullOrEmpty(ruta))
                    {
                        l.ExportToPdf(ruta);
                        Process.Start(Path.Combine(Application.StartupPath, ruta));
                    }                                     
                    break;
                case 3:
                    l.ShowPreview();
                    break;                
            }
        }

        private string PedirRuta(string tipoArc)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Guardar Listado de tramos";
            sfd.Filter = tipoArc;
            sfd.ShowDialog();
            if (sfd.FileName != null)
                return sfd.FileName;
            else
                return "";
        }

        private void btnVerPantalla_Click(object sender, EventArgs e)
        {
            VisualizarReporte(3);
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            VisualizarReporte(1);
        }
        private void btnPdf_Click(object sender, EventArgs e)
        {
            VisualizarReporte(2);
        }                 
    }
}
