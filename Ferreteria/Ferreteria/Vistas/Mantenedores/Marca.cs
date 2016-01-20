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
    public partial class Marca : Form
    {
        private ControladorMarca controladorMarca = new ControladorMarca();

        public Marca()
        {
            InitializeComponent();
            cargarGridMarca();
        }

        //Cargar la grilla con los datos de marcas 
        private void cargarGridMarca()
        {
            gridMarcas.DataSource = controladorMarca.ListarMarcas();
        }

        //Busca una marca mediante su nombre y carga los datos en sus correspondientes campos
        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreMarcaBusqueda.Text.Trim()))
            {//si el campo esta vacio se muestra un error   
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//se procede a buscar la marca
                marca aBuscar = controladorMarca.BuscarMarca(txtNombreMarcaBusqueda.Text.Trim());
                if (aBuscar != null)
                {//si el usuario es encontrado se procede a cargar los campos con los datos de este
                    txtIdMarca.Text = Convert.ToString(aBuscar.id_marca);
                    txtNonbreMarca.Text = aBuscar.nombre;
                }
                else
                {//Si no se encuentra se muestra un mensaje de error
                    MessageBox.Show("La marca buscada no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Agrega una nueva marca a la DB
        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNonbreMarca.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a agrega la nueva marca
                marca nuevo = new marca()
                {
                    nombre = txtNonbreMarca.Text.Trim()
                };
                if (controladorMarca.AgregarMarca(nuevo))
                {//Si se agrega a la DB la marca nueva entonces se carga la grilla con datos nuevos
                    MessageBox.Show("La nueva marca ah sido Agregada.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridMarca();
                }
                else
                {//De lo contrario se muestra un mensaje de error
                    MessageBox.Show("La nueva marca no ah sido Agregada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Edita la marca en especifico y caga los datos en la grilla
        private void btnEditarMarca_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNonbreMarca.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a editar el tipo de usuario
                marca aEditar = new marca()
                {
                    id_marca = Convert.ToInt32(txtIdMarca.Text.Trim()),
                    nombre = txtNonbreMarca.Text.Trim()
                };
                if (controladorMarca.EditarMarca(aEditar))
                {//si se cambiaron datos se procede a editar y hacer persistente el cambio en la DB
                    MessageBox.Show("La marca ah sido modificado.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridMarca();
                }
                else
                {
                    MessageBox.Show("No se ah realizado ningún cambio en los datos.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Elimina una marca en especifico - EN LO POSIBLE NO USAR ESTE METODO
        //ya que podria alterar la entidad producto
        private void btnEliminarTipoUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreMarcaBusqueda.Text.Trim()))
            {
                MessageBox.Show("El campo Nombre del apartado 'Buscar Marca' no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtNonbreMarca.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a eliminar la marca
                marca aEliminar = controladorMarca.BuscarMarca(txtNonbreMarca.Text.Trim());
                if (controladorMarca.EliminarMarca(aEliminar.id_marca))
                {//si la marca es eliminado entonces se actualiza la grilla con datos
                    MessageBox.Show("La marca ah sido eliminada.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridMarca();
                }
                else
                {//si no es eliminado se muestra un mensaje de error
                    MessageBox.Show("La marca no ah sido eliminada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
