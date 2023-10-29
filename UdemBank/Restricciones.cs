using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class Restricciones
    {
        public static bool TieneMaximoGruposAhorro(int idUsuario)
        {
            using var db = new Contexto();

            int cantidadGruposAhorro = db.UsuariosXGruposAhorros
                .Where(x => x.id_ParticipanteGrupo == idUsuario && x.PerteneceAlGrupo)
                .Count();

            if (cantidadGruposAhorro >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
