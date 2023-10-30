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

        enum MenuMiCuenta
        {
            IngresarSaldoACuentaDeAhorro,
            Salir
        }

        enum MenuGestionarGruposDeAhorro
        {
            CrearGrupoDeAhorro,
            SeleccionarUnGrupoDeAhorro,
            Salir
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
                    GestionarMenuPrestamos(usuario);
                    break;
                case MenuUsuario.GestionarMisGruposDeAhorro:
                    GestionarMenuMisGruposDeAhorro(usuario);
                    break;
                case MenuUsuario.SalirDeCuenta:
                    MainMenuManagement();
                    break;
            }
        }

        public static void GestionarMenuMiCuenta(Usuario usuario)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuMiCuenta>()
                .Title("Qué quieres hacer?")
                .AddChoices(
                    MenuMiCuenta.IngresarSaldoACuentaDeAhorro,
                    MenuMiCuenta.Salir
                    ));

            switch (option)
            {
                case MenuMiCuenta.IngresarSaldoACuentaDeAhorro:
                    CuentaDeAhorroBD.IngresarCapital(usuario);
                    break;
                case MenuMiCuenta.Salir:
                    GestionarMenuUsuario(usuario);
                    break;
            }
        }

        public static void GestionarMenuMisGruposDeAhorro(Usuario usuario)
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
                    GrupoDeAhorroBD.CrearGrupoDeAhorro(usuario);
                    break;
                case MenuGestionarGruposDeAhorro.SeleccionarUnGrupoDeAhorro:
                    GrupoDeAhorro miGrupo = Login.SeleccionarMiGrupoAhorro(usuario.id);
                    if (miGrupo != null)
                    {
                        GestionarMenuGrupoDeAhorro(usuario, miGrupo);
                    }
                    else
                    {
                        Console.WriteLine($"{usuario.nombre} no tiene grupos de ahorro");
                        GestionarMenuMisGruposDeAhorro(usuario);
                    }
                    

                    break;
                case MenuGestionarGruposDeAhorro.Salir:
                    GestionarMenuUsuario(usuario);
                    break;
            }
        }
       
        public static void GestionarMenuGrupoDeAhorro(Usuario usuario, GrupoDeAhorro grupo)
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

            switch (option)
            {
                case MenuGrupoDeAhorro.InvitarUsuarioAGrupoDeAhorro:
                    Usuario usuarioInvitado = Login.ObtenerListaUsuarios(usuario.id);
                    GrupoDeAhorroBD.IngresarUsuarioAGrupoDeAhorro(usuario, usuarioInvitado, grupo);
                    break;
                case MenuGrupoDeAhorro.DisolverGrupoDeAhorro:
                    UsuarioXGrupoAhorroBD.DisolverGrupoDeAhorro(usuario, grupo);
                    break;
                case MenuGrupoDeAhorro.IngresarCapitalAGrupoDeAhorro:
                    UsuarioXGrupoAhorroBD.IngresarCapitalAGrupoDeAhorro(usuario, grupo);
                    break;
                case MenuGrupoDeAhorro.Salir:
                    GestionarMenuMisGruposDeAhorro(usuario);
                    break;
            }
        }

        public static void GestionarMenuPrestamos(Usuario usuario)
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuPrestamos>()
            .Title("Te encuentras en el menu de Prestamos, ¿A que grupo deseas prestar? ")
            .AddChoices(
                MenuPrestamos.MisGruposDeAhorro,
                MenuPrestamos.OtrosGrupos,
                MenuPrestamos.Salir));

            switch (option)
            {
                case MenuPrestamos.MisGruposDeAhorro:

                    //Aqui quedó repetido, hay que organizarlo
                    GrupoDeAhorro miGrupo = Login.SeleccionarMiGrupoAhorro(usuario.id);

                    if (miGrupo != null)
                    {
                        PrestamoBD.PrestamoGrupoParticipante(usuario, miGrupo);
                    }
                    else
                    {
                        Console.WriteLine($"{usuario.nombre} no tiene grupos de ahorro");
                        GestionarMenuUsuario(usuario);
                    }


                    break;
                case MenuPrestamos.OtrosGrupos:
                    
                    break;
                case MenuPrestamos.Salir:
                    GestionarMenuUsuario(usuario);
                    break;
            }
        }
    }
}
