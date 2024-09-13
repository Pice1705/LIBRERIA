using Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Clases
{
    public class Libro : Ilibro
    {
        public string Name { get; set; }
        public string TipoLibro { get; set; }
        public double Price { get; set; }
        public int Cantidad { get; set; }
        public int BookCode { get; set; }

        public Libro(string nombre, string tipo, double precio, int cantidad, int codigo)
        {
            Name = nombre;
            TipoLibro = tipo;
            Price = precio;
            Cantidad = cantidad;
            BookCode = codigo;
        }

    }

}
