using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class PrestamoBD
    {
        public static void PrestamoGrupoParticipante(Usuario usuario, GrupoDeAhorro grupo)
        {
            //Conexión a la BD --> contexto
            (double SaldoPrestamo, int idUxG, int cantidadMeses)? tuplaDatos = PrestamoServicios.SolicitarCantidad(usuario, grupo); //Una tupla que me retorne el valor y el id usuarioxgrupo, cantidadMeses

            if (tuplaDatos != null)
            {
                //Todos estos calculos hay que meterlos en otra funcion 
                Console.WriteLine("Tupla datos no fue null");
                double saldoPrestar = tuplaDatos.Value.SaldoPrestamo;
                int idUsuarioGrupo = tuplaDatos.Value.idUxG;
                int meses = tuplaDatos.Value.cantidadMeses;
                Console.WriteLine($"Datos retornados por tupla:saldoprestar:{saldoPrestar}\nidUxG:{idUsuarioGrupo}\nmeses:{meses}");

                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);
                DateOnly fechaPago = DateOnly.FromDateTime(DateTime.Now).AddMonths(meses);

                double cantidadPagar = saldoPrestar + (saldoPrestar * 0.03);
                double cuota = cantidadPagar / meses;

                using var db = new Contexto(); 
                
                db.Prestamos.Add(new Prestamo {id_usuarioXGrupoDeAhorro = idUsuarioGrupo,
                                              cantidadPrestamo = saldoPrestar,
                                              deudaActual = cantidadPagar,
                                              cantidadCuota = cuota,
                                              cantidadAPagar=cantidadPagar,
                                              fechaPrestamo = fechaActual,
                                              fechaPlazo = fechaPago,
                                              interes = 0.03
                                              });
                db.SaveChanges();
                CuentaDeAhorroBD.IngresarCapital(usuario, saldoPrestar,true);
                GrupoDeAhorroBD.QuitarSaldo(grupo.id, saldoPrestar);

                Console.WriteLine("Prestamo Agregado");
                MenuManager.GestionarMenuUsuario(usuario);
            }
            else
            {
                Console.WriteLine("tupla datos fue null");
                return;
            }
        }

        public static void PrestamoOtrosGrupos(Usuario usuario, GrupoDeAhorro grupo)
        {
            (double SaldoPrestamo, int idUxG, int cantidadMeses)? tuplaDatos = PrestamoServicios.VerificarPrestamoOtrosGrupos(usuario, grupo); //Una tupla que me retorne el valor y el id usuarioxgrupo, cantidadMeses

            if(tuplaDatos != null)
            {
                //este codigo tambien hay que organizarlo porque esta repetido excepto por el 0.05

                //Todos estos calculos hay que meterlos en otra funcion 
                Console.WriteLine("Tupla datos no fue null");
                double saldoPrestar = tuplaDatos.Value.SaldoPrestamo;
                int idUsuarioGrupo = tuplaDatos.Value.idUxG;
                int meses = tuplaDatos.Value.cantidadMeses;
                Console.WriteLine($"Datos retornados por tupla:saldoprestar:{saldoPrestar}\nidUxG:{idUsuarioGrupo}\nmeses:{meses}");

                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);
                DateOnly fechaPago = DateOnly.FromDateTime(DateTime.Now).AddMonths(meses);

                double cantidadPagar = saldoPrestar + (saldoPrestar * 0.05);
                double cuota = cantidadPagar / meses;

                using var db = new Contexto();

                db.Prestamos.Add(new Prestamo
                {
                    id_usuarioXGrupoDeAhorro = idUsuarioGrupo,
                    cantidadPrestamo = saldoPrestar,
                    deudaActual = cantidadPagar,
                    cantidadCuota = cuota,
                    cantidadAPagar = cantidadPagar,
                    fechaPrestamo = fechaActual,
                    fechaPlazo = fechaPago,
                    interes = 0.05
                });
                db.SaveChanges();
                CuentaDeAhorroBD.IngresarCapital(usuario, saldoPrestar);
                GrupoDeAhorroBD.QuitarSaldo(grupo.id, saldoPrestar);

                Console.WriteLine("Prestamo Agregado");
                MenuManager.GestionarMenuUsuario(usuario);
            }
            else
            {
                Console.WriteLine("tupla datos para prestamos otrosgrupos fue null");
                return;
            }
        }
    }
}
