using Spectre.Console;
using UdemBank.Controllers;

namespace UdemBank
{
    class Program
    {
        static void Main(string[] args)
        {
            int CantidadBancos = udemBankBD.ContarBancos();
            if (CantidadBancos < 1)
            {
                udemBankBD.CrearBanco();
            }
            MenuManager.MainMenuManagement();
        }
    }
}