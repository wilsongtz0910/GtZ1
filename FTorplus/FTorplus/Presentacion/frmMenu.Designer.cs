namespace FTorplus.Presentacion
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.listaOpciones = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.gMenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnListPorTramos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.gDatosBasico = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnCiudades = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.btnListPorDiasQuietos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.listaOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // listaOpciones
            // 
            this.listaOpciones.AnimationType = DevExpress.XtraBars.Navigation.AnimationType.Office2016;
            this.listaOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.listaOpciones.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.gMenu,
            this.gDatosBasico});
            this.listaOpciones.Location = new System.Drawing.Point(0, 0);
            this.listaOpciones.Name = "listaOpciones";
            this.listaOpciones.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.listaOpciones.Size = new System.Drawing.Size(210, 461);
            this.listaOpciones.TabIndex = 0;
            this.listaOpciones.ElementClick += new DevExpress.XtraBars.Navigation.ElementClickEventHandler(this.listaOpciones_ElementClick);
            // 
            // gMenu
            // 
            this.gMenu.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gMenu.Appearance.Normal.Options.UseFont = true;
            this.gMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnListPorTramos,
            this.btnListPorDiasQuietos});
            this.gMenu.Expanded = true;
            this.gMenu.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl)});
            this.gMenu.Name = "gMenu";
            this.gMenu.Text = "Menu";
            // 
            // btnListPorTramos
            // 
            this.btnListPorTramos.Name = "btnListPorTramos";
            this.btnListPorTramos.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnListPorTramos.Text = "Listado de Existencias por Tramos";
            this.btnListPorTramos.Click += new System.EventHandler(this.btnListPorTramos_Click);
            // 
            // gDatosBasico
            // 
            this.gDatosBasico.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnCiudades,
            this.accordionControlElement1});
            this.gDatosBasico.Expanded = true;
            this.gDatosBasico.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl)});
            this.gDatosBasico.Name = "gDatosBasico";
            this.gDatosBasico.Text = "Datos Basicos";
            // 
            // btnCiudades
            // 
            this.btnCiudades.Name = "btnCiudades";
            this.btnCiudades.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnCiudades.Text = "Ciudades";
            this.btnCiudades.Click += new System.EventHandler(this.btnCiudades_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Element1";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // btnListPorDiasQuietos
            // 
            this.btnListPorDiasQuietos.Name = "btnListPorDiasQuietos";
            this.btnListPorDiasQuietos.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnListPorDiasQuietos.Text = "Listado de Existencia por dias quietos";
            this.btnListPorDiasQuietos.Click += new System.EventHandler(this.btnListPorDiasQuietos_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.listaOpciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTorplus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaOpciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl listaOpciones;
        private DevExpress.XtraBars.Navigation.AccordionControlElement gMenu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnListPorTramos;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement gDatosBasico;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnCiudades;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnListPorDiasQuietos;

    }
}

