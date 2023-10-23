using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;


namespace UdemBank
{
    public class CuentaDeAhorroBD
    {
        public static void CrearCuentaDeAhorro(int id)
        {
            var Saldo = AnsiConsole.Ask<double>("Ingresa tu saldo inicial: ");

            using var db = new Contexto(); //Conexión a la BD --> contexto
            db.CuentasDeAhorros.Add(new CuentaDeAhorro { id_propietario = id, saldo  = Saldo });
            db.SaveChanges();
        }
    }
}
