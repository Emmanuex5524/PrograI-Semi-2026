using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcialComputo2
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            // Ocultamos la contraseña con asteriscos por seguridad al arrancar
            txtClave.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la clave.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataSet ds = Conexion_base_datos.crearDs();
                bool accesoConcedido = false;

                if (ds != null && ds.Tables["usuarios"].Rows.Count > 0)
                {
                    foreach (DataRow fila in ds.Tables["usuarios"].Rows)
                    {
                        string dbUsuario = fila["usuario"].ToString();
                        string dbClave = fila["clave"].ToString();

                        if (dbUsuario == txtUsuario.Text.Trim() && dbClave == txtClave.Text.Trim())
                        {
                            accesoConcedido = true;
                            break;
                        }
                    }
                }

                if (accesoConcedido)
                {
                    MessageBox.Show("¡Bienvenido al sistema!", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrimos el formulario principal de gestión de usuarios
                    frm_usuario formUsuario = new frm_usuario();
                    formUsuario.Show();
                    this.Hide(); // Ocultamos el login
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Acceso denegado.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar el acceso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            // Abre el formulario de registro para crear cuentas nuevas
            frm_usuario registro = new frm_usuario();
            registro.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación por completo
            Application.Exit();
        }

        private void btnVerClave_Click(object sender, EventArgs e)
        {
            // Alterna entre mostrar y ocultar la clave con el botón del ojito
            if (txtClave.UseSystemPasswordChar)
            {
                txtClave.UseSystemPasswordChar = false;
            }
            else
            {
                txtClave.UseSystemPasswordChar = true;
            }
        }

        // Métodos puente para evitar errores de eventos duplicados del diseñador (_1)
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            btnIngresar_Click(sender, e);
        }

        private void btnRegistrarse_Click_1(object sender, EventArgs e)
        {
            btnRegistrarse_Click(sender, e);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            btnSalir_Click(sender, e);
        }

        private void btnVerClave_Click_1(object sender, EventArgs e)
        {
            btnVerClave_Click(sender, e);
        }
    }
}