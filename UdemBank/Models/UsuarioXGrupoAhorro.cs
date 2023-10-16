using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class UsuarioXGrupoAhorro
    {
        public int id { get; set; }
        public int id_ParticipanteGrupo { get; set; }
        public int id_GrupoAhorro { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public bool PerteneceAlGrupo { get; set; }
    }
}
