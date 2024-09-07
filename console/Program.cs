using tp1.models;



Tienda tienda = new Tienda();
int opcion;


do
{
    Console.WriteLine("\n--- Menú Tienda ---");
    Console.WriteLine("1. Agregar Producto");
    Console.WriteLine("2. Buscar Producto");
    Console.WriteLine("3. Eliminar Producto");
    Console.WriteLine("4. Mostrar todos los productos");
    Console.WriteLine("5. Salir");
    Console.Write("Selecciona una opción: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            AgregarProducto(tienda);
            break;
        case 2:
            BuscarProducto(tienda);
            break;
        case 3:
            EliminarProducto(tienda);
            break;
        case 4:
            MostrarProductos(tienda);
            break;
        case 5:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
} while (opcion != 5);


static void AgregarProducto(Tienda tienda)
{
    Console.Write("Nombre del producto: ");
    string nombre = Console.ReadLine();
    Console.Write("Precio del producto: ");
    float precio = float.Parse(Console.ReadLine());
    Console.Write("Categoría del producto: ");
    string categoria = Console.ReadLine();

    Producto nuevoProducto = new Producto(nombre, precio, categoria);
    tienda.Agregar(nuevoProducto);
}

static void BuscarProducto(Tienda tienda)
{
    Console.Write("Nombre del producto a buscar: ");
    string nombre = Console.ReadLine();
    tienda.buscarProducto(nombre);
}

static void EliminarProducto(Tienda tienda)
{
    Console.Write("Nombre del producto a eliminar: ");
    string nombre = Console.ReadLine();
    tienda.elminarProducto(nombre);
}

static void MostrarProductos(Tienda tienda)
{
    Console.WriteLine("\n--- Lista de productos en la tienda ---");
    foreach (var producto in tienda.productos)
    {
        Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio}, Categoría: {producto.categoria}");
    }
}
