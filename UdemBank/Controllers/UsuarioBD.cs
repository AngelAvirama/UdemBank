using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class UsuarioBD
    {
        public static void CrearCuenta()
        {
            //Se supone que el Id lo crear el entity framework

            var nombre = AnsiConsole.Ask<string>("Ingresa tu nombre: ");
            var clave = AnsiConsole.Ask<string>("Ingresa una clave:");

            using var db = new Contexto(); //Conexión a la BD --> contexto
        }
    }
}
