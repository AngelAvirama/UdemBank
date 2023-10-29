using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class UsuarioXGrupoAhorroBD
    {
        public static void UnirseAGrupoDeAhorro(int idUsuario, int idGrupo)
        {
            using var db = new Contexto(); //Conexión a la BD --> contexto

            db.UsuariosXGruposAhorros.Add(new UsuarioXGrupoAhorro { id_ParticipanteGrupo = idUsuario, id_GrupoAhorro = idGrupo, PerteneceAlGrupo = true });
            db.SaveChanges();
        }

        //Esta obtiene los registros de las relaciones UsuarioXGrupoAhorros, no los grupos como tal
        public static List<UsuarioXGrupoAhorro> ObtenerListaMisGrupos(int idUsuario)
        {
            using var db = new Contexto();

            List<UsuarioXGrupoAhorro> misGrupos = db.UsuariosXGruposAhorros.Where(x => x.id_ParticipanteGrupo == idUsuario && x.PerteneceAlGrupo == true).ToList();


            return misGrupos;
        }

        public static void IngresarCapitalAGrupoDeAhorro(Usuario usuario, GrupoDeAhorro grupoDeAhorro)
        {
            using var db = new Contexto();

            var cuentaDeAhorro = db.CuentasDeAhorros.SingleOrDefault(x => x.id_propietario == usuario.id);
            Console.WriteLine($"El saldo del grupo de ahorro es: {grupoDeAhorro.SaldoGrupo}");
            Console.WriteLine();
            double saldoIngresado = AnsiConsole.Ask<double>("Ingresa la cantidad de saldo que deseas ingresar al grupo: ");

            if (cuentaDeAhorro.saldo >= saldoIngresado)
            {
                //grupoDeAhorro.SaldoGrupo += saldoIngresado;
                GrupoDeAhorroBD.IncrementarSaldo(grupoDeAhorro.id, saldoIngresado);

                cuentaDeAhorro.saldo -= saldoIngresado;
                db.SaveChanges();
                Console.WriteLine("Saldo ingresado exitosamente");
                MenuManager.GestionarMenuGrupoDeAhorro(usuario, grupoDeAhorro);
            }
        }

        public static void DisolverGrupoDeAhorro(Usuario usuario, GrupoDeAhorro grupoDeAhorro)
        {
            using var db = new Contexto();

            var relacionesUsuarioXGrupo = db.UsuariosXGruposAhorros
                .Where(ug => ug.id_GrupoAhorro == grupoDeAhorro.id)
                .ToList();

            db.UsuariosXGruposAhorros.RemoveRange(relacionesUsuarioXGrupo);
            db.GruposDeAhorros.Remove(grupoDeAhorro);

            db.SaveChanges();

            Console.WriteLine("El grupo se ha eliminado exitosamente");
            MenuManager.GestionarMenuMisGruposDeAhorro(usuario);
        }

    }
}
