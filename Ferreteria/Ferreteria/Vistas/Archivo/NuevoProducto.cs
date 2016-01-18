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

namespace Ferreteria.Vistas.Archivo
{
    public partial class NuevoProducto : Form
    {
        private ControladorProducto controladorProducto = new ControladorProducto();
        private ControladorMarca controladorMarca = new ControladorMarca();
        private ControladorCategoria controladorCategoria = new ControladorCategoria();

        public NuevoProducto()
        {
            InitializeComponent();
            cargarCboMarcas();
            cargarCboCategorias();
        }

        public NuevoProducto(string cod)
        {
            InitializeComponent();
            cargarCboMarcas();
            cargarCboCategorias();
            lbCodBarraProducto.Text = cod;
        }

        //carga el combobox con las categorias en la db
        private void cargarCboCategorias()
        {
            cboCategoriaProducto.DataSource = controladorCategoria.ListarCategorias();
            cboCategoriaProducto.DisplayMember = "nombre";
            cboCategoriaProducto.ValueMember = "id_categoria";
        }

        //carga el combobox con las marcas en la db
        private void cargarCboMarcas()
        {
            cboMarcaProducto.DataSource = controladorMarca.ListarMarcas();
            cboMarcaProducto.DisplayMember = "nombre";
            cboMarcaProducto.ValueMember = "id_marca";
        }

        //busca un producto en especifico y carga los datos de este en sus respectivos campos
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCodBarraProductoBusqueda.Text.Trim()))
            {//Si los campos estan vacios se muestra el error
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//se procede a buscar el producto
                producto aBuscar = controladorProducto.BuscarProducto(txtCodBarraProductoBusqueda.Text.Trim());
                if (aBuscar != null)
                {//si el producto es encontrado se cargan sus datos en sus campos
                    txtCodigoProducto.Text = aBuscar.cod_producto;
                    txtNombreProducto.Text = aBuscar.nombre;
                    lbCodBarraProducto.Text = aBuscar.cod_barra;
                    cboMarcaProducto.SelectedItem = aBuscar.id_marca;
                    cboCategoriaProducto.SelectedItem = aBuscar.id_categoria;
                    txtStockProducto.Text = Convert.ToString(aBuscar.stock);
                    txtDescripcionProducto.Text = aBuscar.descripcion;
                    txtPrecioProducto.Text = Convert.ToString(aBuscar.precio);
                    txtIdProducto.Text = Convert.ToString(aBuscar.id_producto);
                }
                else
                {
                    MessageBox.Show("El producto buscado no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Agrega un nuevo producto a la DB
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {//si alguno de los campos esta vacio se lanza un mensaje de advertencia
            if (String.IsNullOrEmpty(txtNombreProducto.Text.Trim()))
            {
                MessageBox.Show("El campo Nombre no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cboMarcaProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cboCategoriaProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lbCodBarraProducto.Text == "XXXXXXX")
            {
                MessageBox.Show("Debe generar un nuevo Código de Barras para el producto\nPor favor haga click en el botón, Generar código de Barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtStockProducto.Text.Trim()))
            {
                MessageBox.Show("El campo Stock no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtDescripcionProducto.Text.Trim()))
            {
                MessageBox.Show("El campo Descripción no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else if (String.IsNullOrEmpty(txtPrecioProducto.Text.Trim()))
            {
                MessageBox.Show("El campo Precio no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//si ninguno de los campos esta vacio, se crea un nuevo producto
                MessageBox.Show(lbCodBarraProducto.Text);
            }
        }

        private void btnGenerarCodBarra_Click(object sender, EventArgs e)
        {
            Vistas.Generar_Cod_Barras.CodigoBarras generarCodBarra = new Generar_Cod_Barras.CodigoBarras();
            this.Close();
            generarCodBarra.Show();
        }

       
    }
}
