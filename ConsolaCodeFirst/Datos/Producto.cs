using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Datos
{
   public class Producto
    {
        Modelo.Contexto contexto = new Modelo.Contexto();
        public void Agregar (Modelo.Producto producto)
        {
            contexto.Productos.Add(producto);
            contexto.SaveChanges();
        }

        public List<Modelo.Producto> Listar ()
        {
            var lista = from p in contexto.Productos
                        select p;
            return lista.ToList();
        }

        public List<Modelo.Producto> Listar(string letras)
        {
            var lista = from p in contexto.Productos
                        where p.Nombre.Contains(letras)
                        select p;
            return lista.ToList();
        }
        public Modelo.Producto ListarUno(int Codigo)
        {
            var produ = contexto.Productos.Find(Codigo);
            return produ;
        }
        public void Modificar (Modelo.Producto producto)
        {
            var produ = contexto.Productos.Find(producto.Codigo);
            produ.Codigo = producto.Codigo;
            produ.Nombre = producto.Nombre;
            produ.Precio = producto.Precio;
            contexto.SaveChanges();
        }

        public void Eliminar (int id)
        {
            var produ = contexto.Productos.Find(id);
            contexto.Productos.Remove(produ);
            contexto.SaveChanges();
        }
    }
}
