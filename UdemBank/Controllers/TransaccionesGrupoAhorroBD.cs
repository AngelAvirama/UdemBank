using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class TransaccionesGrupoAhorroBD
    {
        public static double ObtenerAporteUsuario(int idUsuarioGrupo)
        {
            using var db = new Contexto();
            var transacciones = db.TransaccionesGruposAhorros
                                       .Where(t => t.idUsuarioXGrupo == idUsuarioGrupo && t.TipoTransaccion == "Transaccion").ToList();
            double sumaTransacciones = transacciones.Sum(t => t.CantidadTransaccion);
            Console.WriteLine($"Ha aportado: {sumaTransacciones}");
            return sumaTransacciones;
        }

        public static void RegistrarTransaccionGrupo(int idUsuarioGrupo, double cantidadTransaccion, string Tipo)
        {
            using var db = new Contexto();
            //Por ahora

            DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);
            db.TransaccionesGruposAhorros.Add(new TransaccionesGrupoAhorro { idUsuarioXGrupo = idUsuarioGrupo, CantidadTransaccion = cantidadTransaccion, fecha =fechaActual, TipoTransaccion = Tipo});
            db.SaveChanges();
        }
    }
}
