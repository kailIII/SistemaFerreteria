using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.Vistas
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }

        private void Administrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Acceso acceso = new Acceso();
            acceso.Show();

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vistas.Mantenedores.Usuarios usuarios = new Mantenedores.Usuarios();
            usuarios.MdiParent = this.MdiParent;
            usuarios.Show();
        }
    }
}
