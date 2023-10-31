using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;


namespace UdemBank
{
    public class Comision
    {
        public static void ObtenerComisionDeGrupoDisuelto(GrupoDeAhorro grupoDeAhorro)
        {
            double comision = grupoDeAhorro.SaldoGrupo * 0.05;
            Console.WriteLine($"El banco ha obtenido {comision} de comisión");
        }
    }
}