using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class HistorialMovimientos
    {
        public static void ObtenerHistorialMovimientos(Usuario usuario)
        {
            using var db = new Contexto();
            
            // Obtener transacciones personales
            var transaccionesPersonales = db.TransaccionesCuentaAhorros
                .Where(t => t.CuentaDeAhorro.id_propietario == usuario.id)
                .ToList();

            Console.WriteLine("Historial de Transacciones Personales:");
            foreach (var transaccion in transaccionesPersonales)
            {
                Console.WriteLine($"Fecha: {transaccion.fecha}, Tipo: {transaccion.TipoTransaccion}, Cantidad: {transaccion.CantidadTransaccion}");
            }

            // Obtener transacciones de grupos de ahorro
            var relacionesUsuarioGrupo = db.UsuariosXGruposAhorros
                .Where(ug => ug.id_ParticipanteGrupo == usuario.id && ug.PerteneceAlGrupo)
                .ToList();

            foreach (var relacion in relacionesUsuarioGrupo)
            {
                var transaccionesGrupo = db.TransaccionesGruposAhorros
                    .Where(t => t.idUsuarioXGrupo == relacion.id)
                    .ToList();

                if (transaccionesGrupo.Count > 0)
                {
                    Console.WriteLine($"Historial de Transacciones en el Grupo: {relacion.GrupoDeAhorro.NombreGrupo}");
                    foreach (var transaccion in transaccionesGrupo)
                    {
                        Console.WriteLine($"Fecha: {transaccion.fecha}, Tipo: {transaccion.TipoTransaccion}, Cantidad: {transaccion.CantidadTransaccion}");
                    }
                }
            }

            // Obtener préstamos
            var prestamos = db.Prestamos
                .Where(p => p.usuarioXGrupoDeAhorro.Usuario.id == usuario.id)
                .ToList();

            Console.WriteLine("Historial de Préstamos:");
            foreach (var prestamo in prestamos)
            {
                Console.WriteLine($"Fecha del Préstamo: {prestamo.fechaPrestamo}, Cantidad Prestada: {prestamo.cantidadPrestamo}, Deuda Actual: {prestamo.deudaActual}");
            }
        }

    }
}
