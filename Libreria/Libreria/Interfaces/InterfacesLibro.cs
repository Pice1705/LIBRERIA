using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Interfaces
{
    public interface Ilibro

    {
        string Name { get; set; }

        string TipoLibro { get; set; }

        double Price { get; set; }

        int Cantidad { get; set; }

        int BookCode { get; set; }
    }
}
