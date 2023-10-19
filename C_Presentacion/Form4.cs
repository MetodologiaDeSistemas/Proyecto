using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoLogin.C_Presentacion;

namespace AccesoLogin
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod;
            string nom;
            float precio;

            cod = cmbProducto.SelectedIndex;
            nom = cmbProducto.SelectedItem.ToString();
            precio = cmbProducto.SelectedIndex;

            switch (cod)

            {

                case 0: lblCodigo.Text = "0001"; break;
                case 1: lblNombre.Text = "0022"; break;
                case 2: lblCodigo.Text = "0033"; break;
                default: lblCodigo.Text = "0044"; break;
            }
        
            switch (nom)
            {
                case "Labial": lblNombre.Text = "Labial"; break;
                case "Tintura": lblNombre.Text = "Tintura"; break;
                case "Arqueador": lblNombre.Text = "Arqueador"; break;
                case "Pintura de uñas": lblNombre.Text = "Pintura de uñas"; break;
            }

            switch (precio)
            {
                case 0: lblPreci.Text = "110"; break;
                case 1: lblPreci.Text = "250"; break;
                case 2 : lblPreci.Text = "150"; break;
                default: lblPreci.Text = "300"; break;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*
                        C_Datos.Conexion Oconexion = new C_Datos.Conexion();
                        Oconexion.EstablecerConexion();*/
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dgvLista);

            file.Cells[0].Value = lblCodigo.Text;
            file.Cells[1].Value = lblNombre.Text;
            file.Cells[2].Value = lblPreci.Text;
            file.Cells[3].Value = txtCantidad.Text;
            file.Cells[4].Value = (float.Parse(lblPreci.Text) * float.Parse(txtCantidad.Text)).ToString();

            dgvLista.Rows.Add(file);

            lblCodigo.Text = lblNombre.Text = lblPreci.Text = txtCantidad.Text = "";

            ObtenerTotal();

        }

        public void ObtenerTotal()
        {
            float costot = 0;
            int contador = 0;

            contador = dgvLista.RowCount;


            for (int i = 0; i < contador; i++)
            {
                costot += float.Parse(dgvLista.Rows[i].Cells[4].Value.ToString());
            }

            lblTotal.Text = costot.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rppta = MessageBox.Show("¿Desea eliminar el producto?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (rppta == DialogResult.Yes)
                {
                    dgvLista.Rows.Remove(dgvLista.CurrentRow);
                }

            }
            catch { }
            ObtenerTotal();
        }


        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(lblTotal.Text)).ToString();
            }
            catch { }
        }
    }
}
