using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class Prestamo
    {
        public int id { get; set; }
        public int id_usuarioXGrupoDeAhorro { get; set; }
        public double CantidadPrestamo { get; set; }
        public DateOnly fecha { get; set; }
        public string PlazoPago { get; set; }
    }
}
