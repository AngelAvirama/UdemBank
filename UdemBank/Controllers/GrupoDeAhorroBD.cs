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
        public static void CrearGrupoDeAhorro(Usuario usuario)
        {
            bool MaximoGruposDeAhorro = Restricciones.TieneMaximoGruposAhorro(usuario.id);
            if (MaximoGruposDeAhorro == true)
            {
                Console.WriteLine("Ya no puedes crear más grupos de ahorro");
            }
            else
            {
                var nombreGrupo = AnsiConsole.Ask<string>("Ingresa un nombre para el grupo de ahorro: ");

                using var db = new Contexto(); //Conexión a la BD --> contexto
                var grupoAhorro = new GrupoDeAhorro { id_CreadorGrupo = usuario.id, SaldoGrupo = 0, NombreGrupo = nombreGrupo };

                db.GruposDeAhorros.Add(grupoAhorro);
                db.SaveChanges();

                UsuarioXGrupoAhorroBD.UnirseAGrupoDeAhorro(usuario.id, grupoAhorro.id);
            }
            
            MenuManager.GestionarMenuMisGruposDeAhorro(usuario);
        }

        public static List<GrupoDeAhorro> ObtenerGruposAhorro(List<int> listId)
        {
            using var db = new Contexto();
            List<GrupoDeAhorro> Grupos = new List<GrupoDeAhorro>();
            foreach (int id in listId) {
                
                GrupoDeAhorro grupo = db.GruposDeAhorros.Single(g => g.id == id);
                Grupos.Add(grupo);
            }
            return Grupos;
        }

        public static GrupoDeAhorro ObtenerGrupoAhorroId(int id)
        {
            using var db = new Contexto();
            var grupo = db.GruposDeAhorros.SingleOrDefault(u => u.id == id);
            return grupo;
        }

        public static void IncrementarSaldo(int id,double saldo)
        {
            using var db = new Contexto();
            var grupo = db.GruposDeAhorros.SingleOrDefault(u => u.id == id);
            //var grupo = ObtenerGrupoAhorroId(id);
            grupo.SaldoGrupo += saldo;
            db.SaveChanges();
            


        }

        public static void IngresarUsuarioAGrupoDeAhorro(Usuario usuario, GrupoDeAhorro grupoDeAhorro)
        {
            using var db = new Contexto();

            // Verifica si el usuario ya pertenece al grupo de ahorro
            var Pertenece = db.UsuariosXGruposAhorros.SingleOrDefault(ug => ug.id_ParticipanteGrupo == usuario.id && ug.id_GrupoAhorro == grupoDeAhorro.id);

            if (Pertenece != null)
            {
                Console.WriteLine($"{usuario.nombre} ya es miembro del grupo de ahorro {grupoDeAhorro.NombreGrupo}.");
            }
            else
            {
                bool MaximoGruposDeAhorro = Restricciones.TieneMaximoGruposAhorro(usuario.id);
                if (MaximoGruposDeAhorro == true)
                {
                    Console.WriteLine($"El usuario {usuario.nombre} ya no puede estar en más grupos de ahorro");
                }
                else
                {
                    UsuarioXGrupoAhorroBD.UnirseAGrupoDeAhorro(usuario.id, grupoDeAhorro.id);
                    Console.WriteLine($"{usuario.nombre} ha sido agregado al grupo de ahorro {grupoDeAhorro.NombreGrupo}");
                }
            }
            MenuManager.GestionarMenuGrupoDeAhorro(usuario, grupoDeAhorro);
        }

    }



}
