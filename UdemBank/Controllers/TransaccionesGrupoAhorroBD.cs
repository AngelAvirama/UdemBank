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

      /*  public static void PrestamoGrupoParticipante(Usuario usuario,GrupoDeAhorro grupo)
        {
             //Conexión a la BD --> contexto
            (double SaldoPrestamo, int idUxG, int cantidadMeses)? tuplaDatos = PrestamoServicios.SolicitarCantidad(usuario,grupo); //Una tupla que me retorne el valor y el id usuarioxgrupo, cantidadMeses

            if (tuplaDatos != null)
            {
                Console.WriteLine("Tupla datos no fue null");
                double saldoPrestar = tuplaDatos.Value.SaldoPrestamo;
                int idUsuarioGrupo = tuplaDatos.Value.idUxG;
                int meses = tuplaDatos.Value.cantidadMeses;
                Console.WriteLine($"Datos retornados por tupla:saldoprestar:{saldoPrestar}\nidUxG:{idUsuarioGrupo}\nmeses:{meses}");

                DateOnly nuevaFecha = DateOnly.FromDateTime(DateTime.Now).AddMonths(meses);

                using var db = new Contexto();
                db.TransaccionesGruposAhorros.Add(new TransaccionesGrupoAhorro{ idUsuarioXGrupo = idUsuarioGrupo, CantidadTransaccion = saldoPrestar, fecha = nuevaFecha, TipoTransaccion = "Prestamo"});
                db.SaveChanges();
                CuentaDeAhorroBD.IngresarCapital(usuario,saldoPrestar);
                GrupoDeAhorroBD.QuitarSaldo(grupo.id,saldoPrestar);

                Console.WriteLine("Prestamo Agregado");



            }
            else
            {
                Console.WriteLine("tupla datos fue null");
                return;
            }
            
            



        }*/


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
