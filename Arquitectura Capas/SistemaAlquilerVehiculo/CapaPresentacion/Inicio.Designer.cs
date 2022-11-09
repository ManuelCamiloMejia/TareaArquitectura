
namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuVehiculos = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUsiario = new System.Windows.Forms.Label();
            this.txtIdusuario = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuVehiculos});
            this.menu.Location = new System.Drawing.Point(0, 70);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(1120, 79);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuVehiculos
            // 
            this.menuVehiculos.AutoSize = false;
            this.menuVehiculos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuVehiculos.IconChar = FontAwesome.Sharp.IconChar.CarSide;
            this.menuVehiculos.IconColor = System.Drawing.Color.Black;
            this.menuVehiculos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVehiculos.IconSize = 50;
            this.menuVehiculos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVehiculos.Name = "menuVehiculos";
            this.menuVehiculos.Size = new System.Drawing.Size(80, 75);
            this.menuVehiculos.Text = "Vehiculos";
            this.menuVehiculos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuVehiculos.Click += new System.EventHandler(this.menuVehiculos_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.Size = new System.Drawing.Size(1120, 70);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alquiler Vehiculos";
            // 
            // contenedor
            // 
            this.contenedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.contenedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contenedor.Location = new System.Drawing.Point(0, 169);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1120, 484);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Highlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(621, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario";
            // 
            // lbUsiario
            // 
            this.lbUsiario.AutoSize = true;
            this.lbUsiario.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbUsiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsiario.ForeColor = System.Drawing.Color.White;
            this.lbUsiario.Location = new System.Drawing.Point(687, 14);
            this.lbUsiario.Name = "lbUsiario";
            this.lbUsiario.Size = new System.Drawing.Size(66, 18);
            this.lbUsiario.TabIndex = 5;
            this.lbUsiario.Text = "lbUsiario";
            // 
            // txtIdusuario
            // 
            this.txtIdusuario.Location = new System.Drawing.Point(690, 36);
            this.txtIdusuario.Name = "txtIdusuario";
            this.txtIdusuario.Size = new System.Drawing.Size(100, 20);
            this.txtIdusuario.TabIndex = 6;
            this.txtIdusuario.Visible = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 618);
            this.Controls.Add(this.txtIdusuario);
            this.Controls.Add(this.lbUsiario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuVehiculos;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUsiario;
        private System.Windows.Forms.TextBox txtIdusuario;
    }
}

