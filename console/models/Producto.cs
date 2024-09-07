using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp1.models
{
    public class Producto
    {
        static int autoIncremental = 0;

        public int id { get; set; }
        public string nombre { get; set; }
        public virtual float precio { get; set; } // hago el precio virtual para poder utilizar los mocks
        public string categoria { get; set; }


        public Producto(string nombre, float precio, string categoria)
        {
            this.id = ++autoIncremental;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
        }

        public void actualizarPrecio(float nuevoPrecio)
        {
            if (nuevoPrecio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo");
            }

            this.precio = nuevoPrecio;
            Console.WriteLine($"El precio del producto {this.nombre} ha sido actualizado a {this.precio}");
        }

        
    }
}