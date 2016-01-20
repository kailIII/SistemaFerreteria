using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferreteria.Modelo;
using iTextSharp.text.pdf;
using System.Drawing;

namespace Ferreteria.Controladores
{
    public class ControladorProducto
    {
        private FerreteriaEntities contex = new FerreteriaEntities();

        #region CRUD Para la entidad producto
        //*******************************************************************
        //Agregar un nuevo producto
        public bool AgregarProducto(producto nuevo) {
            try
            {
                producto aux = contex.producto.Find(nuevo.id_producto);
                if (aux != null)
                {//si se encuentra un producto existente se devuelve un error
                    return false;
                }
                else
                {//si no existe se comprueba que no exista un producto con el mismo cod. de barra
                    if (BuscarProducto(nuevo.cod_barra) != null)
                    {//si existe un producto con un codigo de barra igual a otro se devuelve falso
                        return false;
                    }
                    else
                    {
                        contex.producto.Add(nuevo);
                        return contex.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        //****************************************************************
        //Buscar producto por su codigo de barras
        public producto BuscarProducto(string codigo_barras) {
            try
            {//se busca un producto por su codigo de barras
                producto aux = contex.producto.Where(x => x.cod_barra == codigo_barras).First();
                if (aux != null)
                {//si se encuentra el producto se devuelve este objeto
                    return aux;
                }
                else
                {//si no se encuentra se devuelve null
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //**********************************************************************************
        //Generar un nuevo codigo de barras
        public Bitmap GenerarCodBarras(string codParaGenerar)
        {
            Barcode128 codigo_barras = new Barcode128();
            codigo_barras.CodeType = Barcode128.CODE128;
            codigo_barras.Code = codParaGenerar;
            codigo_barras.AltText = codParaGenerar;
            codigo_barras.TextAlignment = Barcode128.SHIFT;
            Bitmap codigo_barras_completo = new Bitmap(codigo_barras.CreateDrawingImage(Color.Black, Color.White));
            return codigo_barras_completo;
        }

        //*************************************************************************
        //Generar un nuevo codigo de producto
        public string GenerarNuevoCodigoProducto() {
            StringBuilder codigo = new StringBuilder();
            if (contex.producto.Count() == 0)
            {//si no hay productos en la base de datos se genera el primer codigo para el producto
                return codigo.Append("P01").ToString();
            }
            else
            {//si ya existen productos, se debe tomar el ultimo producto y con este generar un codigo nuevo
                codigo.Clear();//se limpia la cadena para crear una nueva
                producto aux = contex.producto.ToList<producto>()[contex.producto.Count() - 1];
                string codigo_antiguo = aux.cod_producto;
                int digito_del_codigo = Convert.ToInt32(codigo_antiguo.Substring(2,1));
                digito_del_codigo++;
                codigo.Append(codigo_antiguo.Substring(0,2));
                codigo.Append(Convert.ToString(digito_del_codigo));
                return codigo.ToString();
            }
        }

        //*************************************************************************
        //Obtener una lista con los productos de la db
        public List<producto> ListarProductos() {
            try
            {
                return contex.producto.ToList<producto>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //*************************************************************************
        //Eliminar nu producto de la DB
        public bool EliminarProdcuto(int id_producto) {
            try
            {
                producto aux = contex.producto.Find(id_producto);
                if (aux != null)
                {
                    contex.producto.Remove(aux);
                    return contex.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //*************************************************************************
        //Editar un producto de la DB
        public bool EditarProdutco(producto aEditar) {
            try
            {
                producto aux = BuscarProducto(aEditar.cod_barra);
                if (aux != null)
                {//el producto existe y puede ser editado
                    aux.nombre = aEditar.nombre;
                    aux.cod_barra = aEditar.cod_barra;
                    aux.id_marca = aEditar.id_marca;
                    aux.id_categoria = aEditar.id_categoria;
                    aux.descripcion = aEditar.descripcion;
                    aux.stock = aEditar.stock;
                    aux.precio = aEditar.precio;

                    return contex.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion Metodos principales para la entidad producto

    }
}
