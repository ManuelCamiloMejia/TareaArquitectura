﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmVehiculo : Form
    {
        public frmVehiculo()
        {
            InitializeComponent();
        }
       

        private void frmVehiculo_Load(object sender, EventArgs e)
        {
            List<TipoVehiculo> listaTipo = new CN_TipoVehiculos().ListarTipoVehiculo();

            foreach (TipoVehiculo item in listaTipo)
            {
                cmbTipoVehiculos.Items.Add(new OpcionCombo() { Valor = item.idtipo, Texto = item.tipo });
            }

            cmbTipoVehiculos.DisplayMember = "Texto";
            cmbTipoVehiculos.ValueMember = "Valor";
            cmbTipoVehiculos.SelectedIndex = 0;

            List<EstadoVehiculo> listaEstado = new CN_EstadoVehiculo().Listar();

            foreach (EstadoVehiculo item in listaEstado)
            {
                cmbEstados.Items.Add(new OpcionCombo() { Valor = item.idEstado, Texto = item.nombre });
            }

            cmbEstados.DisplayMember = "Texto";
            cmbEstados.ValueMember = "Valor";
            cmbEstados.SelectedIndex = 0;

            List<vehiculos> vehiculos = new CN_Vehiculos().ListarVehiculos();

            foreach (vehiculos item in vehiculos)
            {
                gvData.Rows.Add(new object[] {"", item.idVehiculo,item.matricula,item.marca,item.modelo,item.oTipoVehiculo.idtipo,item.oTipoVehiculo.tipo
                    ,item.obEstadoVehiculo.nombre,item.obEstadoVehiculo.idEstado,item.PesoToneladas
            });
            }
        }

        private void gvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check__1_.Width;
                var h = Properties.Resources.check__1_.Height;

                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check__1_, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }


        private void gvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndece.Text = indice.ToString();
                    txtid.Text = gvData.Rows[indice].Cells["IdVehiculo"].Value.ToString();
                    txtMatricula.Text = gvData.Rows[indice].Cells["Matricula"].Value.ToString();
                    txtMarca.Text = gvData.Rows[indice].Cells["Marca"].Value.ToString();
                    txtModelo.Text = gvData.Rows[indice].Cells["Modelo"].Value.ToString();
                    txtToneladas.Text = gvData.Rows[indice].Cells["PesoToneladas"].Value.ToString();

                    foreach (OpcionCombo oc in cmbTipoVehiculos.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(gvData.Rows[indice].Cells["IdTipoVehiculo"].Value))
                        {
                            int indice_combo = cmbTipoVehiculos.Items.IndexOf(oc);
                            cmbTipoVehiculos.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cmbEstados.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(gvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cmbEstados.Items.IndexOf(oc);
                            cmbEstados.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String mensaje = string.Empty;

            vehiculos objVehiculo = new vehiculos()
            {
                idVehiculo = Convert.ToInt32(txtid.Text),
                matricula = txtMatricula.Text,
                marca = txtMarca.Text,
                modelo = txtModelo.Text,
                PesoToneladas = Convert.ToInt32(txtToneladas.Text),
                oTipoVehiculo = new TipoVehiculo() { idtipo = Convert.ToInt32(((OpcionCombo)cmbTipoVehiculos.SelectedItem).Valor), tipo = Convert.ToString(((OpcionCombo)cmbTipoVehiculos.SelectedItem).Texto) },
                obEstadoVehiculo = new EstadoVehiculo() { idEstado = Convert.ToInt32(((OpcionCombo)cmbEstados.SelectedItem).Valor), nombre = Convert.ToString(((OpcionCombo)cmbEstados.SelectedItem).Texto) }
            };

            if (objVehiculo.idVehiculo == 0)
            {
                int idVehiculoGenerado = new CN_Vehiculos().Registrar(objVehiculo, out mensaje);

                if (idVehiculoGenerado != 0)
                {
                    gvData.Rows.Add(new object[] {"", idVehiculoGenerado,txtMatricula.Text,txtMarca.Text,txtModelo.Text,
                ((OpcionCombo)cmbTipoVehiculos.SelectedItem).Valor.ToString(),
                 ((OpcionCombo)cmbTipoVehiculos.SelectedItem).Texto.ToString(),
                  ((OpcionCombo)cmbEstados.SelectedItem).Texto.ToString(),
                  ((OpcionCombo)cmbEstados.SelectedItem).Valor.ToString(),
                  txtToneladas.Text
                 });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                bool resultado = new CN_Vehiculos().Editar(objVehiculo, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = gvData.Rows[Convert.ToInt32(txtIndece.Text)];

                    row.Cells["IdVehiculo"].Value = txtid.Text;
                    row.Cells["Matricula"].Value = objVehiculo.matricula;
                    row.Cells["Marca"].Value = objVehiculo.marca;
                    row.Cells["Modelo"].Value = objVehiculo.modelo;
                    row.Cells["IdTipoVehiculo"].Value = objVehiculo.oTipoVehiculo.idtipo;
                    row.Cells["Tipo"].Value = objVehiculo.oTipoVehiculo.tipo;
                    row.Cells["Estado"].Value = objVehiculo.obEstadoVehiculo.nombre;
                    row.Cells["EstadoValor"].Value = objVehiculo.obEstadoVehiculo.idEstado;
                    row.Cells["PesoToneladas"].Value = objVehiculo.PesoToneladas;

                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void Limpiar()
        {
            txtIndece.Text = "-1";
            txtid.Text = "0";
            txtMatricula.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";            
            cmbTipoVehiculos.SelectedIndex = 0;
            cmbEstados.SelectedIndex = 0;        

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String mensaje = string.Empty;

            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar el usuario", "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    vehiculos objVehiculos= new vehiculos()
                    {
                        idVehiculo = Convert.ToInt32(txtid.Text),
                    };

                    bool resultado = new CN_Vehiculos().Eliminar(objVehiculos, out mensaje);

                    if (resultado)
                    {
                        gvData.Rows.RemoveAt(Convert.ToInt32(txtIndece.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cmbTipoVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoVehiculos.SelectedIndex == 2) {
                txtToneladas.Enabled = true;                
            }
            else
            {
                txtToneladas.Enabled = false;
                txtToneladas.Text = "0";
            }
        }

        private void txtToneladas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
