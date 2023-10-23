using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class GrupoDeAhorroBD
    {
        public static void CrearGrupoDeAhorro(int id)
        {
            //var Saldo = AnsiConsole.Ask<double>("Ingresa tu saldo inicial: ");

            using var db = new Contexto(); //Conexión a la BD --> contexto
            db.GruposDeAhorros.Add(new GrupoDeAhorro { id_CreadorGrupo = id, SaldoGrupo = id });
            db.SaveChanges();
        }
    }
}
