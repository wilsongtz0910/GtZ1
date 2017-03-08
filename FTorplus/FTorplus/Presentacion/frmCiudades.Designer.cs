namespace FTorplus.Presentacion
{
    partial class FrmCiudades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdCiudades = new DevExpress.XtraGrid.GridControl();
            this.grvCiudades = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdCiudades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCiudades)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCiudades
            // 
            this.grdCiudades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCiudades.Location = new System.Drawing.Point(0, 0);
            this.grdCiudades.MainView = this.grvCiudades;
            this.grdCiudades.Name = "grdCiudades";
            this.grdCiudades.Size = new System.Drawing.Size(585, 328);
            this.grdCiudades.TabIndex = 0;
            this.grdCiudades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCiudades});
            // 
            // grvCiudades
            // 
            this.grvCiudades.GridControl = this.grdCiudades;
            this.grvCiudades.Name = "grvCiudades";
            // 
            // frmCiudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 328);
            this.Controls.Add(this.grdCiudades);
            this.Name = "FrmCiudades";
            this.Text = "Ciudades";
            this.Load += new System.EventHandler(this.frmCiudades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCiudades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCiudades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCiudades;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCiudades;
    }
}