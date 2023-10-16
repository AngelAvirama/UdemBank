using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class TransaccionesGrupoAhorro
    {
        public int id { get; set; }
        public int idUsuarioXGrupo { get; set; }
        public double CantidadTransaccion { get; set; }
        public DateOnly fecha { get; set; }
        public string TipoTransaccion { get; set; }
    }
}
