using System;
using System.Collections.Generic;
using tp1.models;
using Xunit;
using Moq;

public class TiendaTests
{
    // [Fact]
    // public void AgregarProducto_DeberiaAgregarProductoALaLista()
    // {
    //     // Arrange
    //     var tienda = new Tienda();
    //     var producto = new Producto("Laptop", 1000, "Electrónica");

    //     // Act
    //     tienda.Agregar(producto);

    //     // Assert
    //     Assert.Contains(producto, tienda.productos);
    // }

    // [Fact]
    // public void BuscarProducto_DeberiaEncontrarProductoExistente()
    // {
    //     // Arrange
    //     var tienda = new Tienda();
    //     var producto = new Producto("Laptop", 1000, "Electrónica");
    //     tienda.Agregar(producto);

    //     // Act
    //     tienda.buscarProducto("Laptop");

    //     // Assert
    //     Assert.Contains(producto, tienda.productos);
    // }

    // [Fact]
    // public void BuscarProducto_NoDeberiaEncontrarProductoInexistente()
    // {
    //     // Arrange
    //     var tienda = new Tienda();

    //     // Act
    //     var output = CaptureConsoleOutput(() => tienda.buscarProducto("Tablet"));

    //     // Assert
    //     Assert.Contains("No se ha encontrado el producto Tablet", output);
    // }

    // private string CaptureConsoleOutput(Action action)
    // {
    //     using (var sw = new System.IO.StringWriter())
    //     {
    //         Console.SetOut(sw);
    //         action.Invoke();
    //         return sw.ToString();
    //     }
    // }

    // [Fact]
    // public void EliminarProducto_DeberiaEliminarProductoExistente()
    // {
    //     // Arrange
    //     var tienda = new Tienda();
    //     var producto = new Producto("Laptop", 1000, "Electrónica");
    //     tienda.Agregar(producto);

    //     // Act
    //     tienda.elminarProducto("Laptop");

    //     // Assert
    //     Assert.DoesNotContain(producto, tienda.productos);
    // }

    // 2) Pruebas con Excepciones

     [Fact]
    public void BuscarProducto_DeberiaLanzarExcepcionSiNoExiste()
    {
        // Arrange
        var tienda = new Tienda();

        // Act & Assert
        Assert.Throws<Exception>(() => tienda.buscarProducto("ProductoInexistente"));
    }

    [Fact]
    public void EliminarProducto_DeberiaLanzarExcepcionSiNoExiste()
    {
        // Arrange
        var tienda = new Tienda();

        // Act & Assert
        Assert.Throws<Exception>(() => tienda.elminarProducto("ProductoInexistente"));
    }

    [Fact]
    public void ActualizarPrecio_DeberiaLanzarExcepcionSiElPrecioEsNegativo()
    {
        // Arrange
        var producto = new Producto("Laptop", 1000, "Electrónica");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => producto.actualizarPrecio(-50));
    }

    // Pruebas con Mocks
     [Fact]
    public void AplicarDescuento_DeberiaAplicarDescuentoAlProducto()
    {
        // Arrange
        var mockProducto = new Mock<Producto>("Laptop", 1000, "Electrónica");
        mockProducto.SetupProperty(p => p.precio, 1000); // Simulamos el precio inicial
        var tienda = new Tienda();
        tienda.productos.Add(mockProducto.Object); // Añadimos el producto simulado a la tienda

        // Act
        tienda.aplicar_descuento("Laptop", 10); // Aplicamos un 10% de descuento

        // Assert
        Assert.Equal(900, mockProducto.Object.precio); // Verificamos que el precio ha sido ajustado
    }
}

// Preguntas 1:
// - ¿Puedes identificar pruebas de unidad y de integración en la práctica que realizaste?
/* En las pruebas realizadas estariamos practicando pruebas de unidad,  ya que solo verifican el comportamiento individual de los métodos de la clase Tienda sin integrarse con otros sistemas o componentes más complejos.*/

// Preguntas 2:
/* Preguntas:
- Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?
¿Cómo sería el proceso de escribir primero los tests?
Si se podria haber escrito las pruebas primero, de hecho hay un enfoque que se llama TDD, por sus siglas en inglés: Test-Driven Development). TDD es una técnica de desarrollo de software en la que escribes las pruebas antes de escribir el código de la aplicación que hace que esas pruebas pasen.
Este enfoque nos brinda muchas ventajas, pero vuelve mas lento el desarrollo.*/


// Preguntas 3:
/* Preguntas:
- En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
- ¿Qué es un mock? ¿Hay otros nombres para los objetos/funciones simulados?
Controladores: Métodos como Agregar, buscarProducto, elminarProducto, y aplicar_descuento en la clase Tienda, que gestionan la lógica del negocio.
Resguardos: Validaciones como el lanzamiento de excepciones en los métodos buscarProducto, elminarProducto, y actualizar_precio, que evitan errores o estados inválidos.

Mock y Otros Nombres:
Mock: Un objeto simulado usado en pruebas para replicar el comportamiento de uno real sin depender de su implementación.
Otros Nombres:
Stub: Simula datos predefinidos.
Fake: Implementa lógica básica.
Spy: Registra interacciones.
Dummy: Argumento requerido pero no utilizado en la prueba.

*/


