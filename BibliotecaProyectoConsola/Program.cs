using BibliotecaProyectoConsola;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

//Lista de libros
ObservableCollection<Libro> libros = new ObservableCollection<Libro>
    {
        new Libro(1, "Harry Potter y la piedra filosofal", "1997", "J.K. Rowling", "Fantasia", "Un mundo donde la magia es real"),
        new Libro(2, "Harry Potter y la camara secreta", "1999", "J.K. Rowling", "Fantasia", "Harry se adentra a una camara secreta dentro de Howgarts"),
        new Libro(3, "Harry Potter y el prisionero de Azkaban", "1999", "J.K. Rowling", "Fantasia", "Un hechizero peligroso se escapa de la prision mas segura del mundo y asecha a los protagonistas"),
        new Libro(4, "Halo, La Caída de Reach", "2001", "Eric Nylund", "Ciencia ficcion", "Superados en número y armamento, los soldados parecen tener pocas posibilidades, pero Reach alberga un secreto celosamente guardado"),
        new Libro(5, "Assassin's Creed, Renaissance", "2009", "Oliver Bowden", "Fantasia", "Ezio se convierte en la fuerza que guía a sus aliados en pos de la libertad y la justicia"),
        new Libro(6, "Five Nights at Freddy's, Los Ojos de Plata", "2016", "Scott Cawthon", "Ciencia ficcion", "Charlie vuelve a Freddy Fazbear's Pizza diez años después de los terroríficos asesinatos"),
        new Libro(7, "El sutil arte de que te importe un carajo", "2016", "Mark Manson", "Filosofia", "Un enfoque disruptivo para vivir una buena vida"),
        new Libro(8, "Spider-Man/Black Cat, El mal que hacen los hombres", "2002", "Kevin Smith", "Fantasia", "Cuando todo parece un inocente reencuentro entre dos antiguos amantes que todavía saben pasarla bien como amigos cuando están juntos, la realidad te golpea y termina llevándote a caminos mucho más oscuros y tenebrosos."),
        new Libro(9, "Batman, La Broma Asesina", "1998", "Alan Moore", "Policial", "Un mal día. De acuerdo con la sonriente maquinaria de locura y destrucción conocida como Joker, es lo único a la cordura de un psicótico."),
        new Libro(10, "Mortal Kombat, Lazos de sangre", "2015", "Shwan Kittelsen", "Ciencia ficcion", "Durante años, una tenue paz ha existido entre los reinos; tiempo suficiente para que los viejos campeones caigan y una nueva generación se levante")
    };
//Lista a filtrar
List<Libro> ListaFiltrada = new List<Libro>();
int Filtro = 0;
//mando a llamar la main
Main();
void Main()
{
    Console.WriteLine("1.Buscar \n2.Categorias \n3.Ano \n4.Autor \n5.Ver Detalles"); //Elije un metodo de busca
    Console.WriteLine();

    foreach (var Libro in libros) //Muestra todos los libros disponibles
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }
    Console.WriteLine();

    Filtro = Convert.ToInt32(Console.ReadLine()); //Elije uno de los metodos de busca

    if (Filtro == 1)
    {
        Console.Clear();
        Buscar();
    }
    if (Filtro == 2)
    {
        Console.Clear();
        Categorias();
    }
    if (Filtro == 3)
    {
        Console.Clear();
        Ano();
    }
    if (Filtro == 4)
    {
        Console.Clear();
        Autor();
    }
    if (Filtro == 5)
    {
        Detalles();
    }
}
void Buscar() //Busca en la coleccion y lo guarda en la lista filtrada
{
    string busqueda = "";
    Console.WriteLine("Inserte el nombre del libro:");
    busqueda = Console.ReadLine();
    
    if(busqueda=="")
    {
        Console.WriteLine();
        Console.WriteLine("Ingrese un nombre o inicial para empezar la busqueda\n");
        Buscar();
    }
    else
    {
        ListaFiltrada.Clear();
        ListaFiltrada = libros.Where(x => x.Nombre.Contains(busqueda)).ToList();

        Console.WriteLine();
        foreach (var Libro in ListaFiltrada)
        {
            Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
        }
        Detalles();
    }
}
void Detalles() //con el id muestra los datos de un libro
{
    string eleccion = "";
    Console.WriteLine("");
    Console.WriteLine("Escriba el (Id) para ver los detalles del libro o (Cancelar) para volver a al inicio");
    eleccion = Console.ReadLine();
    Console.WriteLine();
    if (eleccion == "Cancelar")
    {
        Console.Clear();
        Main();
    }
    else
    {
        Console.Clear();
        foreach (var Libro in libros)
        {
            if (Libro.Id == Convert.ToInt32(eleccion))
            {
                Console.WriteLine($"{Libro.Nombre}-{Libro.AñoPublicacion}-{Libro.Autor}\n{Libro.Genero}-{Libro.Descripcion}");
            }
        }
        Console.WriteLine("Para regresar al inicio de enter");
        string salir = Console.ReadLine();
        if (salir != null)
        {
            Console.Clear();
            Main();
        }
    }
}
void Categorias()//Filtrar por categoorias
{
    int eleccion;
    Console.WriteLine("Seleccione una de las categorias disponibles:\n1-Fantasia\n2-Ciencia ficcion\n3-Policial\n4-Filosofia");
    Console.WriteLine();
    eleccion = Convert.ToInt32(Console.ReadLine());
    ListaFiltrada.Clear();
    Console.Clear();

    if (eleccion==1)
    {
        ListaFiltrada = libros.Where(x => x.Genero.Contains("Fantasia")).ToList();

        foreach (var Libro in ListaFiltrada)
        {
            Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
        }
        Detalles();
    }
    if (eleccion == 2)
    {
        ListaFiltrada = libros.Where(x => x.Genero.Contains("Ciencia ficcion")).ToList();

        foreach (var Libro in ListaFiltrada)
        {
            Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
        }
        Detalles();
    }
    if (eleccion == 3)
    {
        ListaFiltrada = libros.Where(x => x.Genero.Contains("Policia")).ToList();

        foreach (var Libro in ListaFiltrada)
        {
            Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
        }
        Detalles();
    }
    if (eleccion == 4)
    {
        ListaFiltrada = libros.Where(x => x.Genero.Contains("Filosofia")).ToList();

        foreach (var Libro in ListaFiltrada)
        {
            Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
        }
        Detalles();
    }
}
void Ano()//Filtrar por años
{
    Console.WriteLine("Lista Filtrada por anos");
    Console.WriteLine();
    Console.WriteLine("Para salir escriba (Salir)");
    Console.WriteLine();
    Console.WriteLine("-----1997-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("1997")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }

    Console.WriteLine();
    Console.WriteLine("-----1998-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("1998")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }

    Console.WriteLine();
    Console.WriteLine("-----1999-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("1999")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }

    Console.WriteLine();
    Console.WriteLine("-----2001-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("2001")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }

    Console.WriteLine();
    Console.WriteLine("-----2002-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("2002")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }

    Console.WriteLine();
    Console.WriteLine("-----2009-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("2009")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }

    Console.WriteLine();
    Console.WriteLine("-----2015-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("2015")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }

    Console.WriteLine();
    Console.WriteLine("-----2016-----");
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.AñoPublicacion.Contains("2016")).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }
    Console.WriteLine();
    Detalles();
}
void Autor()
{
    Console.WriteLine("Elija uno de los autores escribeindo su nombre");
    Console.WriteLine();
    var autoresUnicos = libros.Select(x => x.Autor).Distinct().ToList();
    foreach (var x in autoresUnicos)
    {
        Console.WriteLine($"{x}");
    }
    Console.WriteLine();
    string nombre = Console.ReadLine();
    Console.Clear();
    ListaFiltrada.Clear();
    ListaFiltrada = libros.Where(x => x.Autor.Contains(nombre)).ToList();

    foreach (var Libro in ListaFiltrada)
    {
        Console.WriteLine($"{Libro.Id}-{Libro.Nombre}");
    }
    Console.WriteLine();
    Detalles();
}//filtrar por autores