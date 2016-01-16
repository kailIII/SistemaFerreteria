using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferreteria.Controladores;
using Ferreteria.Modelo;

namespace Ferreteria.Vistas.Mantenedores
{
    public partial class Usuarios : Form
    {
        private ControladorUsuario controladorUsuario = new ControladorUsuario();
        private ControladorTipoUsuario controladorTipoUsuario = new ControladorTipoUsuario();

        public Usuarios()
        {
            InitializeComponent();
            cargarCboTipoUsuario();
            cargarGridUsuarios();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRutBusquda.Text.Trim()))
            {
                MessageBox.Show("El campo Rut no puede esatr vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                usuario encontrado = controladorUsuario.BuscarUsuario(txtRutBusquda.Text.Trim());
                if (encontrado != null)
                {//El usuario es encontrado por lo tanto se cargan sus datos a los campos correspondientes
                    txtCodUsuario.Text = encontrado.codigo_usuario;
                    txtRutUsuario.Text = encontrado.rut_usuario;
                    txtNombreUsuario.Text = encontrado.nombre;
                    txtApellidoUsuario.Text = encontrado.apellido;
                    txtEmailUsuario.Text = encontrado.email;
                    cboTipoUsuario.SelectedValue = encontrado.id_tipo_usuario;
                }
                else
                {
                    MessageBox.Show("El usuario no ah sido encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Cargar el control Dropdown con los tipos de usuarios disponibles
        private void cargarCboTipoUsuario()
        {
            cboTipoUsuario.DataSource = controladorTipoUsuario.ListarTiposDeUsuarios();
            cboTipoUsuario.ValueMember = "id_tipo_usuario";
            cboTipoUsuario.DisplayMember = "nombre";

        }

        //cargar la grilla con todos los registros de usuarios.
        private void cargarGridUsuarios()
        {
            gridUsuarios.DataSource = controladorUsuario.ListarUsuariosCompleto();
        }

        //Agrega un usuario nuevo a la base de datos
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRutUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Rut no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txtNombreUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txtApellidoUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Apellido no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txtEmailUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Email no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboTipoUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Debe selecionar un tipo de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (controladorUsuario.BuscarUsuario(txtRutUsuario.Text) != null)
                {//Si el usuario es encontrado, no se puede agregar porque ya existe
                    MessageBox.Show("El usuario que intenta agregar, ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToString(txtRutUsuario.Text[txtRutUsuario.Text.Length - 1]) == controladorUsuario.digitoVerificador(Convert.ToInt32(txtRutUsuario.Text.Substring(0, txtRutUsuario.Text.Length - 1))))
                    {//Si el digito verificador del rut ingresado es correcto se procede a agregar al nuevo usuario
                        string nombreTipoUsuario = controladorTipoUsuario.ObtenerNombreTipoUsuario(Convert.ToInt32(cboTipoUsuario.SelectedValue));
                        txtCodUsuario.Text = controladorUsuario.GenerarCodigo(nombreTipoUsuario);
                        usuario nuevo = new usuario()//se crea un usuario que se agregara a la DB
                        {
                            codigo_usuario = txtCodUsuario.Text,
                            rut_usuario = txtRutUsuario.Text,
                            nombre = txtNombreUsuario.Text,
                            apellido = txtApellidoUsuario.Text,
                            email = txtEmailUsuario.Text,
                            id_tipo_usuario = Convert.ToInt32(cboTipoUsuario.SelectedValue)
                        };
                        if (controladorUsuario.AgregarUsuario(nuevo))
                        {//Si no hay errores se agrega el nuevo usuario y se recarga la Grilla
                            MessageBox.Show("El usuario ah sido agregado.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarGridUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("El usuario que intenta agregar, ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Rut ingresado no es correcto, Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (controladorUsuario.EliminarUsuario(txtRutUsuario.Text.Trim()))
            {//Si el rut es correcto se elimina al usuario
                cargarGridUsuarios();
            }
            else
            {
                MessageBox.Show("El Rut ingresado no es correcto, Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRutUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Rut no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txtNombreUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txtApellidoUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Apellido no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txtEmailUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Email no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboTipoUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Debe selecionar un tipo de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nombreTipoUsuario = controladorTipoUsuario.ObtenerNombreTipoUsuario(Convert.ToInt32(cboTipoUsuario.SelectedValue));
                txtCodUsuario.Text = controladorUsuario.GenerarCodigo(nombreTipoUsuario);
                usuario aEditar = new usuario()//se crea un usuario que se agregara a la DB
                {
                    codigo_usuario = txtCodUsuario.Text,
                    rut_usuario = txtRutUsuario.Text,
                    nombre = txtNombreUsuario.Text,
                    apellido = txtApellidoUsuario.Text,
                    email = txtEmailUsuario.Text,
                    id_tipo_usuario = Convert.ToInt32(cboTipoUsuario.SelectedValue)
                };

                if (controladorUsuario.EditarUsuario(aEditar))
                {
                    MessageBox.Show("El usuario ah sido editado.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridUsuarios();
                }
                else
                {
                    MessageBox.Show("No se ah realizado ningún cambio.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
