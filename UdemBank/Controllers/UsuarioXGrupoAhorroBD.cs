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

        public static int CrearRelacionPrestamo(int idUsuario, int idGrupo)
        {
            using var db = new Contexto();

            //Esto es para que no se cree el registro de nuevo en la tabla usuarioXgrupoAhorro en caso de que ya exista
            List<UsuarioXGrupoAhorro> listUsuarioxGrupo = db.UsuariosXGruposAhorros.Where(x => x.id_ParticipanteGrupo == idUsuario && x.id_GrupoAhorro == idGrupo && x.PerteneceAlGrupo == false).ToList();

            if (listUsuarioxGrupo.Count == 0)
            {
                UsuarioXGrupoAhorro newUsuarioXGrupo = new UsuarioXGrupoAhorro { id_ParticipanteGrupo = idUsuario, id_GrupoAhorro = idGrupo, PerteneceAlGrupo = false };
                db.UsuariosXGruposAhorros.Add(newUsuarioXGrupo);
                db.SaveChanges();
                return newUsuarioXGrupo.id;
            }
            else
            {
                return ObtenerUsuarioXGrupoId(idUsuario, idGrupo);
            }
        }
        //Esta obtiene los registros de las relaciones UsuarioXGrupoAhorros, no los grupos como tal

        public static List<UsuarioXGrupoAhorro> ObtenerListaMisGrupos(int idUsuario)
        {
            using var db = new Contexto();

            List<UsuarioXGrupoAhorro> misGrupos = db.UsuariosXGruposAhorros.Where(x => x.id_ParticipanteGrupo == idUsuario && x.PerteneceAlGrupo == true).ToList();
            return misGrupos;
        }


        public static int ObtenerUsuarioXGrupoId(int idUsuario, int idGrupo)
        {
            using var db = new Contexto();
            int idUsuarioXGrupo = db.UsuariosXGruposAhorros.Where(x => x.id_ParticipanteGrupo == idUsuario && x.id_GrupoAhorro == idGrupo).Select(x => x.id).FirstOrDefault();
            return idUsuarioXGrupo;
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
                GrupoDeAhorroBD.IncrementarSaldo(grupoDeAhorro.id, saldoIngresado);
                cuentaDeAhorro.saldo -= saldoIngresado;

                db.SaveChanges();

                int idUsuarioGrupo = ObtenerUsuarioXGrupoId(usuario.id, grupoDeAhorro.id);
                TransaccionesGrupoAhorroBD.RegistrarTransaccionGrupo(idUsuarioGrupo, saldoIngresado, "Transaccion Grupo de Ahorro");

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

            Comision.ObtenerComisionDeGrupoDisuelto(grupoDeAhorro);
            Console.WriteLine("El grupo se ha eliminado exitosamente");
            MenuManager.GestionarMenuMisGruposDeAhorro(usuario);
        }

        public static List<int> ObtenerUsuariosGrupo(int idGrupo, int idParticipante) //Excepto el que quiere prestar
        {
            using var db = new Contexto();

            var usuariosxGruposAhorros = db.UsuariosXGruposAhorros.Where(x => x.id_ParticipanteGrupo != idParticipante && x.id_GrupoAhorro == idGrupo && x.PerteneceAlGrupo==true).ToList();
            var idUsuarios = usuariosxGruposAhorros.Select(x => x.id_ParticipanteGrupo).ToList();
            return idUsuarios; 
        }

        public static List<TransaccionesGrupoAhorro> ObtenerHistorialGrupoDeAhorro(int idUsuario)
        {
            using var db = new Contexto();

            var relacionesUsuarioGrupo = db.UsuariosXGruposAhorros
                .Where(ug => ug.id_ParticipanteGrupo == idUsuario && ug.PerteneceAlGrupo)
                .ToList();

            var transaccionesGrupo = new List<TransaccionesGrupoAhorro>();

            foreach (var relacion in relacionesUsuarioGrupo)
            {
                var transaccion = db.TransaccionesGruposAhorros
                    .Where(t => t.idUsuarioXGrupo == relacion.id)
                    .ToList();
                transaccionesGrupo.AddRange(transaccion);
            }
            return transaccionesGrupo;
        }
    }
}