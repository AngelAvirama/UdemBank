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

        public static Usuario Acceder()
        {

            String claveIngresada;
            Usuario usuario;
            do
            {
                usuario = ObtenerListaUsuarios();
                
                claveIngresada = AnsiConsole.Ask<string>("Ingresa tu clave: ");

                if (claveIngresada == usuario.clave)
                {
                    Console.WriteLine("Accediendo al sistema...");
                }
                else
                {
                    Console.WriteLine("Grave... Clave incorrecta.");
                }
            } while (claveIngresada != usuario.clave);

            return usuario;
            
        }

        public static GrupoDeAhorro SeleccionarMiGrupoAhorro(int idUsuario)
        {

            var misUsuarioXGrupoAhorros = UsuarioXGrupoAhorroBD.ObtenerListaMisGrupos(idUsuario);
            if (misUsuarioXGrupoAhorros.Count != 0)
            {
                var listaMisUsuarioXGrupoAhorros = misUsuarioXGrupoAhorros.Select(x => x.id_GrupoAhorro).ToList();

                var gruposAhorro = GrupoDeAhorroBD.ObtenerGruposAhorro(listaMisUsuarioXGrupoAhorros);

                var nombresGrupoAhorro = gruposAhorro.Select(x => x.NombreGrupo).ToList();


                var opcion = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Selecciona un grupo de ahorro: ")
                    .AddChoices(nombresGrupoAhorro));


                var idGrupo = gruposAhorro.Single(x => x.NombreGrupo == opcion).id;
                return GrupoDeAhorroBD.ObtenerGrupoAhorroId(idGrupo);
            }
            else
            {
                return null;
            }
        }
    }
}
