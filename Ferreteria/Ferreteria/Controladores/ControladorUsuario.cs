using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferreteria.Modelo;
using System.Security.Cryptography;

namespace Ferreteria.Controladores
{
    public class ControladorUsuario
    {
        private FerreteriaEntities contex = new FerreteriaEntities();//Referencia al objeto que manipula los datos de las entidades y a estas mismas-

        //Acceder al sistema con el rut del usuario y su clave
        public int Acceder(string rut, string clave)
        {
            if (contex.usuario.Count() > 0)
            {//La base de datos tiene registros
                try
                {
                    rut += digitoVerificador(Convert.ToInt32(rut));//Se calcula el digito verificador del rut del usuario
                    clave = getMD5(clave);//Se usa el cifrado MD5 para la clave
                    usuario aBuscar = contex.usuario.Where(x => x.rut_usuario == rut && x.clave == clave).Single();
                    if (aBuscar != null)
                    {//El usuario existe y se devuelve su tipo de usuario
                        return (int)aBuscar.id_tipo_usuario;
                    }
                }
                catch (Exception)
                {//La excepcion se lanza porque si los datos estan incorrectos, no se logra encontrar un registro por lo que el objeto es null
                    return 0;
                }
            }
            return 0;//Retornar 0 significa que es un error.
        }

        //Encriptar Clave y obtenerla en MD5
        public string getMD5(string texto)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(texto));
            byte[] resultado = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < resultado.Length; i++)
            {
                str.Append(resultado[i].ToString("x2"));
            }
            return str.ToString();
        }

        //Validar RUT - devuelve el digito verificador
        private string digitoVerificador(int rut)
        {
            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;
            string RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }

            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }
            return (RutDigito);
        }

        #region CRUD Usuario
        //Agregar un nuevo usuario a la Base de datos
        public bool AgregarUsuario(usuario nuevo)
        {
            try
            {
                usuario aux = contex.usuario.Find(nuevo.rut_usuario);
                if (aux != null)
                {
                    return false;//El usuario ya existe.
                }
                else
                {//Se agrega el nuevo usuario al contexto y se devuelve el cambio
                    contex.usuario.Add(nuevo);
                    return contex.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {//Si se genera un error se informa de este
                System.Windows.Forms.MessageBox.Show("Error"+e.Message);
                return false;
            }
        } 
        //********************************************************************************
        //Editar un usuario existente
        public bool EditarUsuario(usuario aEditar) {
            try
            {
                usuario aux = contex.usuario.Find(aEditar.rut_usuario);
                if (aux != null)
                {//El usuario existe por lo tanto se editan sus datos
                    aux.rut_usuario = aEditar.rut_usuario;
                    aux.nombre = aEditar.nombre;
                    aux.apellido = aEditar.apellido;
                    aux.email = aEditar.email;
                    aux.id_tipo_usuario = aEditar.id_tipo_usuario;
                    return contex.SaveChanges() > 0;
                }
                else
                {//El usuario no existe o no se ah encontrado
                    return false;
                }
            }
            catch (Exception e)
            {//Si se genera un error se informa de este
                System.Windows.Forms.MessageBox.Show("Error" + e.Message);
                return false;
            }
        }
        //********************************************************************************
        //Eliminar un usuario existente
        public bool EliminarUsuario(string rut_usuario) {
            try
            {
                usuario aux = contex.usuario.Find(rut_usuario);
                if (aux != null)
                {//El usuario existe y se puede eliminar
                    contex.usuario.Remove(aux);
                    return contex.SaveChanges() > 0;
                }
                else
                {//El usuario no existe o no se ah encontrado
                    return false;
                }
            }
            catch (Exception e)
            {//Si se genera un error se informa de este
                System.Windows.Forms.MessageBox.Show("Error" + e.Message);
                return false;
            }
        }
        //********************************************************************************
        //Buscar un usuario existente
        public usuario BuscarUsuario(string rut_usuario) {
            try
            {
                usuario aux = contex.usuario.Find(rut_usuario);
                if (aux != null)
                {//El usuario existe y se devuelve como un objeto
                    return aux;
                }
                else
                {//El usuario no existe o no se ah encontrado
                    return null;
                }
            }
            catch (Exception e)
            {//Si se genera un error se informa de este
                System.Windows.Forms.MessageBox.Show("Error" + e.Message);
                return null;
            }
        }
        //********************************************************************************
        //Obtener una lista con todos los usuarios
        public List<usuario> ListarUsuarios() {
            try
            {
                return contex.usuario.ToList<usuario>();
            }
            catch (Exception e)
            {//Si se genera un error se informa de este
                System.Windows.Forms.MessageBox.Show("Error" + e.Message);
                return null;
            }
        }
        #endregion Metodos principales CRUD de la entidad Usuario.
    }
}
