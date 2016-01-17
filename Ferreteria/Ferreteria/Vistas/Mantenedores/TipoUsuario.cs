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
    public partial class TipoUsuario : Form
    {
        private ControladorTipoUsuario controladorTipoUsuario = new ControladorTipoUsuario();

        public TipoUsuario()
        {
            InitializeComponent();
            cargarGridTipoUsuarios();
            btnEliminarTipoUsuario.Visible = false;//No se deben eliminar datos de esta entidad  ya que posee una relacion con la entidad usuarios
        }

        //buscar un tipo de usuario por su nombre y cargar los datos a los correspondientes campos
        private void btnBuscarTipoUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreTipoUsuarioBusqueda.Text.Trim()))
            {//si el campo esta vacio se muestra un error   
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//se procede a buscar al usuario
                tipo_usuario aBuscar = controladorTipoUsuario.BuscarTipoUsuario(txtNombreTipoUsuarioBusqueda.Text.Trim());
                if (aBuscar != null)
                {//si el usuario es encontrado se procede a cargar los campos con los datos de este
                    txtIdTipoUsuario.Text = Convert.ToString(aBuscar.id_tipo_usuario);
                    txtNonbreTipoUsuario.Text = aBuscar.nombre;
                    txtDescripcionTipoUsuario.Text = aBuscar.descripcion;
                }
                else
                {//Si no se encuentra se muestra un mensaje de error
                    MessageBox.Show("El tipo de usuario buscado no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //cargar la grilla de lista de tipo de usuarios con datos
        private void cargarGridTipoUsuarios()
        {
            gridTipoUsuario.DataSource = controladorTipoUsuario.ListarTiposDeUsuarios();
        }

        //Editar el tipo de usuario buscado previamente con nuevos datos
        private void btnEditarTipoUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNonbreTipoUsuario.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtDescripcionTipoUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Descripción no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a editar el tipo de usuario
                tipo_usuario aEditar = new tipo_usuario()
                {
                    id_tipo_usuario = Convert.ToInt32(txtIdTipoUsuario.Text.Trim()),
                    nombre = txtNonbreTipoUsuario.Text.Trim(),
                    descripcion = txtDescripcionTipoUsuario.Text.Trim()
                };
                if (controladorTipoUsuario.EditarTipoUsuario(aEditar))
                {//si se cambiaron datos se procede a editar y hacer persistente el cambio en la DB
                    MessageBox.Show("El tipo de usuario ah sido modificado.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridTipoUsuarios();
                }
                else
                {
                    MessageBox.Show("No se ah realizado ningún cambio en los datos.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Eliminar un tipo de usuario en particular a traves de su id
        private void btnEliminarTipoUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreTipoUsuarioBusqueda.Text.Trim()))
            {
                MessageBox.Show("El campo Nombre del apartado 'Buscar Tipo Usuario' no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtNonbreTipoUsuario.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtDescripcionTipoUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Descripción no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a eliminar el tipo de usuario
                tipo_usuario aEliminar = controladorTipoUsuario.BuscarTipoUsuario(txtNombreTipoUsuarioBusqueda.Text.Trim());
                if (controladorTipoUsuario.EliminarTipoUsuario(aEliminar.id_tipo_usuario))
                {//si el usuario es eliminado entonces se actualiza la grilla con datos
                    MessageBox.Show("El tipo de usuario ah sido modificado.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridTipoUsuarios();
                }
                else
                {//si no es eliminado se muestra un mensaje de error
                    MessageBox.Show("El tipo de usuario no ah sido eliminado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Agregar un nuevo tipo de usuario a la DB
        private void btnAgregarTipoUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNonbreTipoUsuario.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtDescripcionTipoUsuario.Text.Trim()))
            {
                MessageBox.Show("El campo Descripción no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a editar el tipo de usuario
                tipo_usuario nuevo = new tipo_usuario() {
                    nombre = txtNonbreTipoUsuario.Text.Trim(),
                    descripcion = txtDescripcionTipoUsuario.Text.Trim()
                };
                if (controladorTipoUsuario.AgregarTipoUsuario(nuevo))
                {//Si se agrega a la DB el tipo de usuario nuevo entonces se carga la grilla con datos nuevos
                    MessageBox.Show("El nuevo tipo de usuario ah sido Agregado.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridTipoUsuarios();
                }
                else
                {//De lo contrario se muestra un mensaje de error
                    MessageBox.Show("El nuevo tipo de usuario no ah sido Agregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
