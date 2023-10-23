using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class MenuManager
    {
        //Gravee
        enum MainMenuOptions
        {
            IniciarSesion,
            Registrarse,
            Salir
        }
        //viendo cambios

        enum MenuRegistrarse
        {
            CrearCuenta,
            Salir
        }

        
        enum MenuUsuario
        {
            MiCuenta,
            Pagar,
            HistorialMovimientos,
            Prestamos,
            GestionarMisGruposDeAhorro, 
            SalirDeCuenta
        }

        enum MenuGestionarGruposDeAhorro
        {
            CrearGrupoDeAhorro,
            SeleccionarUnGrupoDeAhorro,
            Salir
        }

        enum MenuSeleccionarGrupoDeAhorro
        {
            //Lista de grupos de ahorro
        }

        enum MenuGrupoDeAhorro
        {
            InvitarUsuarioAGrupoDeAhorro,
            DisolverGrupoDeAhorro,
            IngresarCapitalAGrupoDeAhorro,
            Salir
        }

        enum MenuPrestamos
        {
            MisGruposDeAhorro,
            OtrosGrupos,
            Salir
        }

        enum MenuMisGruposDeAhorro
        {
            //Lista de sus grupos de ahorro
        }

        enum MenuOtrosGrupos
        {
            //Lista de otros grupos de ahorro
        }

        public static void MainMenuManagement()
        {
            //Menú principal
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                .Title("Bienvenido a UdemBank \nQué quieres hacer?")
                .AddChoices(
                    MainMenuOptions.IniciarSesion,
                    MainMenuOptions.Registrarse,
                    MainMenuOptions.Salir
                    ));

            switch (option)
            {
                case MainMenuOptions.IniciarSesion:
                    Usuario usuario = Login.Acceder();
                    GestionarMenuUsuario(usuario);
                    break;
                case MainMenuOptions.Registrarse:
                    GestionarMenuRegistrarse();
                    break;
                case MainMenuOptions.Salir:

                    Console.WriteLine("¡Gracias por usar UdemBank!");
                    break;
            }
        }

        /*public static void GestionarMenuIniciarSesion()
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuIniciarSesion>()
            .Title("Selecciona tu usuario")
            .AddChoices(
                Login.ObtenerListaUsuarios(),
                MenuIniciarSesion.Salir));

            switch (option)
            {
                case MenuIniciarSesion.Salir:
                    SalirMenuInicial();
                    break;
            }
        }*/

        public static void GestionarMenuRegistrarse()
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuRegistrarse>()
            .Title("Que quieres hacer?: ")
            .AddChoices(
                MenuRegistrarse.CrearCuenta,
                MenuRegistrarse.Salir));

            switch (option)
            {
                case MenuRegistrarse.CrearCuenta:
                    UsuarioBD.CrearCuenta();
                    
                    break;
                case MenuRegistrarse.Salir:
                    MainMenuManagement();
                    break;
            }
        }



        

        public static void GestionarMenuUsuario(Usuario usuario)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuUsuario>()
                .Title("Qué quieres hacer?")
                .AddChoices(
                    MenuUsuario.MiCuenta,
                    MenuUsuario.Pagar,
                    MenuUsuario.HistorialMovimientos,
                    MenuUsuario.Prestamos,
                    MenuUsuario.GestionarMisGruposDeAhorro,
                    MenuUsuario.SalirDeCuenta
                    ));
            switch (option)
            {
                case MenuUsuario.MiCuenta:
                    UsuarioBD.MostrarInformacionCuenta(usuario);
                    break;
                case MenuUsuario.Pagar:
                    break;
                case MenuUsuario.HistorialMovimientos:
                    break;
                case MenuUsuario.Prestamos:
                    break;
                case MenuUsuario.GestionarMisGruposDeAhorro:
                    GestionarMenuGestionarMisGruposDeAhorro(usuario);
                    break;
                case MenuUsuario.SalirDeCuenta:
                    MainMenuManagement();
                    break;
            }
        }

       

        public static void GestionarMenuGestionarMisGruposDeAhorro(Usuario usuario)
        {
              var option = AnsiConsole.Prompt(  
                new SelectionPrompt<MenuGestionarGruposDeAhorro>()
                .Title("Qué quieres hacer?")
                .AddChoices(
                    MenuGestionarGruposDeAhorro.CrearGrupoDeAhorro,
                    MenuGestionarGruposDeAhorro.SeleccionarUnGrupoDeAhorro,
                    MenuGestionarGruposDeAhorro.Salir
                    ));
            switch (option)
            {
                case MenuGestionarGruposDeAhorro.CrearGrupoDeAhorro:
                    GrupoDeAhorroBD.CrearGrupoDeAhorro(usuario.id);
                    break;
                case MenuGestionarGruposDeAhorro.SeleccionarUnGrupoDeAhorro:
                    break;
                case MenuGestionarGruposDeAhorro.Salir:
                    GestionarMenuUsuario(usuario);
                    break;
            }
        }

        public static void GestionarMenuSeleccionarGrupoDeAhorro()
        {
            //Pol como hago esto
        }

        public static void GestionarMenuGrupoDeAhorro(Usuario usuario)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuGrupoDeAhorro>()
                .Title("Qué quieres hacer?")
                .AddChoices(
                    MenuGrupoDeAhorro.InvitarUsuarioAGrupoDeAhorro,
                    MenuGrupoDeAhorro.DisolverGrupoDeAhorro,
                    MenuGrupoDeAhorro.IngresarCapitalAGrupoDeAhorro,
                    MenuGrupoDeAhorro.Salir
                    ));
        }

        public static void GestionarMenuPrestamos()
        {

        }
    }
}
