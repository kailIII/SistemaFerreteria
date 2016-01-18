using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.Vistas.Generar_Cod_Barras
{
    public partial class CodigoBarras : Form
    {
        public CodigoBarras()
        {
            InitializeComponent();
        }

        //Genera un nuevo codigo de barras que es devuelto a la vista padre
        private void btnGenerarCodBarra_Click(object sender, EventArgs e)
        {
            Vistas.Archivo.NuevoProducto aux = new Archivo.NuevoProducto("asasdasdsdsd");
            aux.Show();
            this.Close();
        }
    }
}
