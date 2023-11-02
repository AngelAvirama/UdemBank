using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank.Controllers
{
    public class udemBankBD
    {
        public static void CrearBanco ()
        {
            using var db = new Contexto(); //Conexión a la BD --> contexto

            db.udemBanks.Add(new udemBank { comision = 0 });
            db.SaveChanges();
        }
    }
}
