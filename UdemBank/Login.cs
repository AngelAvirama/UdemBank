using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class Login
    {
        public static Usuario ObtenerListaUsuarios()
        {
            var usuarios = UsuarioBD.ObtenerUsuarios();
            var ListaUsuarios = usuarios.Select(x => x.nombre).ToArray();
            var opcion = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Selecciona un usuario")
                .AddChoices(ListaUsuarios));

            var id = usuarios.Single(x => x.nombre == opcion).id;
            var usuario = UsuarioBD.ObtenerUsuarioPorId(id);
            return usuario;
        }
    }
}
