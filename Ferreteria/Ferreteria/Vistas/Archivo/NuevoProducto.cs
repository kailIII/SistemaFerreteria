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
using iTextSharp;
using iTextSharp.text.pdf;



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
            cargarGridProductos();
        }

        public NuevoProducto(string cod, Bitmap codigo_barras_completo)
        {
            InitializeComponent();
            cargarCboMarcas();
            cargarCboCategorias();
            lbCodBarraProducto.Text = cod;
            txtCodBarraProductoLeido.Text = cod;
            pictureBox1.Image = codigo_barras_completo;
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
                MessageBox.Show("1.- Debe generar un nuevo Código de Barras para el producto.\nPor favor haga click en el botón, Generar código de Barras.\n2.- Si el producto posee un código, use la pistola lectora para ingresar este dato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                producto nuevo = new producto() {
                    nombre = txtNombreProducto.Text.Trim(),
                    cod_producto = controladorProducto.GenerarNuevoCodigoProducto(),
                    id_marca = Convert.ToInt32(cboMarcaProducto.SelectedValue),
                    id_categoria = Convert.ToInt32(cboCategoriaProducto.SelectedValue),
                    precio = Convert.ToInt32(txtPrecioProducto.Text.Trim()),
                    descripcion = txtDescripcionProducto.Text.Trim(),
                    stock = Convert.ToInt32(txtStockProducto.Text.Trim()),
                    cod_barra = txtCodBarraProductoLeido.Text.Trim(),
                    fecha_ingreso = DateTime.Now
                };
                if (controladorProducto.AgregarProducto(nuevo))
                {
                    MessageBox.Show("El nuevo producto ah sido agregado.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridProductos();
                }
                else
                {
                    MessageBox.Show("El nuevo producto NO ah sido agregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //cargar Grilla con todos los productos de la DB
        private void cargarGridProductos() {
            gridProductos.DataSource = controladorProducto.ListarProductos();
        }

        //Al hacer click en el boton, se abre el formulario responsable de generar el codigo de barras
        private void btnGenerarCodBarra_Click(object sender, EventArgs e)
        {
            Vistas.Generar_Cod_Barras.CodigoBarras generarCodBarra = new Generar_Cod_Barras.CodigoBarras();
            this.Close();
            generarCodBarra.Show();
        }
        
        //Al cambiar el texto del campo se representa en forma de imagen que represente al codigo de barras
        private void txtCodBarraProductoLeido_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCodBarraProductoLeido.Text))
            {//si el campo de codigo de barra esta vacio entonces mostrar error
                MessageBox.Show("1.- Debe generar un nuevo Código de Barras para el producto.\nPor favor haga click en el botón, Generar código de Barras.\n2.- Si el producto posee un código, use la pistola lectora para ingresar este dato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lbCodBarraProducto.Text = "XXXXXXX";
            }
            else
            {//si no esta vacio el campo, se carga la previsualizacion del codigo de barras
                lbCodBarraProducto.Text = txtCodBarraProductoLeido.Text;
                
                pictureBox1.Image = controladorProducto.GenerarCodBarras(lbCodBarraProducto.Text);
            }
        }

        //Al cambiar el texto del campo se representa en forma de imagen que represente al codigo de barras
        private void lbCodBarraProducto_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lbCodBarraProducto.Text))
            {
                lbCodBarraProducto.Text = "XXXXXXX";
            }
            else
            {
                txtCodBarraProductoLeido.Text = lbCodBarraProducto.Text;

                pictureBox1.Image = controladorProducto.GenerarCodBarras(txtCodBarraProductoLeido.Text.Trim());
            }
        }
        
        //eliminar u producto mediante su id y su codigo de barras 
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCodBarraProductoBusqueda.Text.Trim()) || txtIdProducto.Text == "")
            {
                MessageBox.Show("Para poder Eliminar un Producto primero debe buscarlo.\n\n1.- Ingrese El Codigo de Barras del producto.\n2.- Haga click en el botón Buscar.\n3.- Luego haga click en el botón Eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int idProducto = Convert.ToInt32(txtIdProducto.Text.Trim());
                if (controladorProducto.EliminarProdcuto(idProducto))
                {
                    MessageBox.Show("El producto ah sido eliminado.", "Mensaje de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGridProductos();
                    //programar funcion para limpiar campos.
                }
                else
                {
                    MessageBox.Show("El producto no ah sido eliminado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Edita un producto mediante el codigo de barras
        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCodBarraProductoBusqueda.Text.Trim()))
            {//si el campo de codigo de barra esta vacio no se puede editar porque primero se debe buscar un productoa a editar
                MessageBox.Show("El campo Cod. De Barra no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (controladorProducto.BuscarProducto(txtCodBarraProductoBusqueda.Text.Trim()) == null)
            {//si no se encuentra el producto se envia el mensaje de advertencia
                MessageBox.Show("Para poder Editar un Producto primero debe buscarlo.\n\n1.- Ingrese El Codigo de Barras del producto.\n2.- Haga click en el botón Buscar.\n3.- Luego haga click en el botón Editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (String.IsNullOrEmpty(txtNombreProducto.Text.Trim()) || String.IsNullOrEmpty(txtCodBarraProductoLeido.Text.Trim()) || String.IsNullOrEmpty(txtPrecioProducto.Text.Trim()) || String.IsNullOrEmpty(txtStockProducto.Text.Trim()) || String.IsNullOrEmpty(txtDescripcionProducto.Text.Trim()))
                {//si lso campos estan vacios se debe informar
                    MessageBox.Show("Para poder Editar un Producto primero debe buscarlo.\n\n1.- Ingrese El Codigo de Barras del producto.\n2.- Haga click en el botón Buscar.\n3.- Luego haga click en el botón Editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    producto aEditar = new producto()//se crea un usuario que se agregara a la DB
                    {
                        id_producto = Convert.ToInt32(txtIdProducto.Text.Trim()),
                        nombre = txtNombreProducto.Text.Trim(),
                        cod_barra = txtCodBarraProductoLeido.Text.Trim(),
                        descripcion = txtDescripcionProducto.Text.Trim(),
                        id_categoria = (int)cboCategoriaProducto.SelectedValue,
                        id_marca = (int)cboMarcaProducto.SelectedValue,
                        precio = Convert.ToInt32(txtPrecioProducto.Text.Trim()),
                        stock = Convert.ToInt32(txtStockProducto.Text.Trim()),
                        cod_producto = txtCodigoProducto.Text.Trim()
                    };

                    if (controladorProducto.EditarProdutco(aEditar))
                    {
                        MessageBox.Show("El producto ah sido editado.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGridProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se ah realizado ningún cambio en los datos.", "Mensaje de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

       
    }
}
