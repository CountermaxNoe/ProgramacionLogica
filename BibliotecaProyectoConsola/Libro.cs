using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProyectoConsola
{
    public class Libro
    {
        public int Id {  get; set; }
        public string Nombre { get; set; } 
        public string AñoPublicacion { get; set; }
        public string Autor { get; set; } 
        public string Genero { get; set; } 
        public string Descripcion { get; set; }

        public Libro(int id, string nombre, string añoPublicacion, string autor, string genero, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            AñoPublicacion = añoPublicacion;
            Autor = autor;
            Genero = genero;
            Descripcion = descripcion;
        }
    }
}
