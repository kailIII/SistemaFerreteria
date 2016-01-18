using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferreteria.Modelo;

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

        //*************************************************************************
        //Obtener una lista con los productos de la db
        #endregion Metodos principales para la entidad producto

    }
}
