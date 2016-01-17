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
    public partial class Categoria : Form
    {
        private ControladorCategoria controladorCategoria = new ControladorCategoria();
        
        public Categoria()
        {
            InitializeComponent();
            cargarGridCategorias();
        }

        //carga los datos de las categorias existentes en la db en la grilla
        private void cargarGridCategorias()
        {
            gridCategoria.DataSource = controladorCategoria.ListarCategorias();
        }

        //Buscar una categoria por su nombre y carga los datos en sus respectivos campos
        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreCategoriaBusqueda.Text.Trim()))
            {//si el campo esta vacio se muestra un error   
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//se procede a buscar la categoria
                categoria aBuscar = controladorCategoria.BuscarCategoria(txtNombreCategoriaBusqueda.Text.Trim());
                if (aBuscar != null)
                {//si la categoria es encontrado se procede a cargar los campos con los datos de este
                    txtIdCategoria.Text = Convert.ToString(aBuscar.id_categoria);
                    txtNonbreCategoria.Text = aBuscar.nombre;
                }
                else
                {//Si no se encuentra se muestra un mensaje de error
                    MessageBox.Show("La categoría buscada no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //agrega una nueva categoria a la DB y carga los datos a la grilla
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNonbreCategoria.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a agrega la nueva marca
                categoria nuevo = new categoria()
                {
                    nombre = txtNonbreCategoria.Text.Trim()
                };
                if (controladorCategoria.AgregarCategoria(nuevo))
                {//Si se agrega a la DB la marca nueva entonces se carga la grilla con datos nuevos
                    MessageBox.Show("La nueva categoria ah sido Agregada.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridCategorias();
                }
                else
                {//De lo contrario se muestra un mensaje de error
                    MessageBox.Show("La nueva categoria no ah sido Agregada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //editar una categoria y carga los datos modificados en la grilla
        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNonbreCategoria.Text.Trim()))
            {//si alguno de los campos de datos esta vacio se muestra un error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si no hay campos vacios se procede a editar la categoria
                categoria aEditar = new categoria()
                {
                    id_categoria = Convert.ToInt32(txtIdCategoria.Text.Trim()),
                    nombre = txtNonbreCategoria.Text.Trim()
                };
                if (controladorCategoria.EditarCategoria(aEditar))
                {//si se cambiaron datos se procede a editar y hacer persistente el cambio en la DB
                    MessageBox.Show("La categoría ah sido modificado.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridCategorias();
                }
                else
                {
                    MessageBox.Show("No se ah realizado ningún cambio en los datos.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
