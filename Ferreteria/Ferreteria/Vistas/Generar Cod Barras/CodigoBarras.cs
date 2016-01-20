using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using Ferreteria.Controladores;

namespace Ferreteria.Vistas.Generar_Cod_Barras
{
    public partial class CodigoBarras : Form
    {
        private ControladorProducto controladorProducto = new ControladorProducto();

        public CodigoBarras()
        {
            InitializeComponent();
        }

        //Genera un nuevo codigo de barras que es devuelto a la vista padre
        private void btnGenerarCodBarra_Click(object sender, EventArgs e)
        {
            Bitmap btmCodBarra = controladorProducto.GenerarCodBarras(txtCodBarraNuevo.Text);
            imgCodBarra.Image = btmCodBarra;
            Vistas.Archivo.NuevoProducto aux = new Archivo.NuevoProducto(txtCodBarraNuevo.Text, btmCodBarra);
            aux.Show();
            this.Close();
        }

        

        //ciando el texto cambia se renderiza o previsualiza el codigo de barras
        private void txtCodBarraNuevo_TextChanged(object sender, EventArgs e)
        {
            imgCodBarra.Image = controladorProducto.GenerarCodBarras(txtCodBarraNuevo.Text);
        }
    }
}
