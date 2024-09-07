using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp1.models
{
    public class Tienda
    {
        public List<Producto> productos { get; set; }


        public Tienda()
        {
            this.productos = new List<Producto>();
        }

        public void Agregar(Producto p)
        {
            this.productos.Add(p);
            Console.WriteLine($"Se ha agregado el producto {p.nombre} a la tienda");
        }

        public void buscarProducto(string nombre)
        {
            string buscado = "";
            foreach (var p in productos)
            {
                if (p.nombre == nombre)
                {
                    buscado = nombre;
                }
            }
            // if (buscado == "")
            // {
            //      Console.WriteLine($"No se ha encontrado el producto {nombre} en la tienda");
            // }
            // else
            // {
            //     Console.WriteLine($"Se ha encontrado el producto {nombre} en la tienda");
            // }
            // Ahora lo realizamos con excepciones
            if (buscado == "")
            {
                throw new Exception($"No se ha encontrado el producto {nombre} en la tienda");
            }
            else
            {
                Console.WriteLine($"Se ha encontrado el producto {nombre} en la tienda");
            }


        }

        public void elminarProducto(string nombre)
        {
            foreach (var p in productos)
            {
                if (p.nombre == nombre)
                {
                    this.productos.Remove(p);
                    Console.WriteLine($"Se ha eliminado el producto {p.nombre} de la tienda");
                    return;
                }
            }

            throw new Exception($"No se ha encontrado el producto {nombre} en la tienda");
        }


    public void aplicar_descuento(string nombreProducto, float porcentaje)
    {
        var producto = productos.FirstOrDefault(p => p.nombre == nombreProducto);
        
        if (producto == null)
        {
            throw new Exception($"Producto {nombreProducto} no encontrado");
        }

        if (porcentaje < 0 || porcentaje > 100)
        {
            throw new ArgumentException("El porcentaje de descuento debe estar entre 0 y 100");
        }

        producto.precio -= producto.precio * (porcentaje / 100);
    }
    }
}