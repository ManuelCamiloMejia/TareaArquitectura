using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using FontAwesome.Sharp;
namespace CapaPresentacion


{
    public partial class Inicio : Form
    {

        
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio()
        {

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            
            lbUsiario.Text = "Administrador";
            txtIdusuario.Text = "1";

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if(FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }       

                   

      
        private void menuVehiculos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmVehiculo());
        }


       
        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
}
