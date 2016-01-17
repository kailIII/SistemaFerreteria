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

        private void tiposDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vistas.Mantenedores.TipoUsuario tipoUsuario = new Mantenedores.TipoUsuario();
            tipoUsuario.MdiParent = this.MdiParent;
            tipoUsuario.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vistas.Mantenedores.Marca marca = new Mantenedores.Marca();
            marca.MdiParent = this.MdiParent;
            marca.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vistas.Mantenedores.Categoria categoria = new Mantenedores.Categoria();
            categoria.MdiParent = this.MdiParent;
            categoria.Show();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
