using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculodelAgua
{
    public partial class frmAgua : Form
    {
        public frmAgua()
        {
            InitializeComponent();
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        {


    {
       
                    
                    }

             
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            
            {
                // Hola que tal, un gusto que vean este codigo jsjsjsjsjjsjsjsjsjsj

                errorProvider1.Clear();

               
                if (!double.TryParse(txtConsumo.Text, out double metrosCubicos) || metrosCubicos <= 0)
                {
                    errorProvider1.SetError(txtConsumo, "Ingrese un numero de consumo válido mayor a 0.");
                    lblResultado.Text = "Cargo base: $3.00\nTotal a pagar: $0.00";
                    return;
                }

               
                double cuotaBase = 3.00;
                double totalPagar = cuotaBase;

                
                if (metrosCubicos <= 10)
                {
                    totalPagar += metrosCubicos * 0.30;
                }
                else if (metrosCubicos <= 25)
                {
                    totalPagar += (10 * 0.30) + ((metrosCubicos - 10) * 0.60);
                }
                else
                {
                    totalPagar += (10 * 0.30) + (15 * 0.60) + ((metrosCubicos - 25) * 1.20);
                }

               
                lblResultado.Text = $"Cargo base: ${cuotaBase:F2}\nTotal a pagar: ${totalPagar:F2}";
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        { 
            {
                txtConsumo.Clear();
                lblResultado.Text = "Cargo base: $3.00\nTotal a pagar: $0.00";
                errorProvider1.Clear();
                txtConsumo.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblConsumo_Click(object sender, EventArgs e)
        {

        }

        private void txtConsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            {
                
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
               
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
               
                else if (e.KeyChar == '.' && !((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = false;
                }
               
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
    

