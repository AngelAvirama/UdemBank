﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace UdemBank
{
    public class MenuManager
    {
        enum MainMenuOptions
        {
            IniciarSesion,
            Registrarse,
            Salir
        }

        enum MenuRegistrarse
        {
            CrearCuenta,
            Salir
        }

        enum MenuIniciarSesion
        {
            //Lista de usuarios
            Salir
        }
        enum MenuUsuario
        {
            MiCuenta,
            GestionarMisGruposDeAhorro, 
            Prestamos,
            SalirDeCuenta
        }

        enum MenuMiCuenta
        {
            PagarDeudas,
            HistorialMovimientos,
            Salir
        }

        enum MenuGestionarGruposDeAhorro
        {
            CrearGrupoDeAhorro,
            SeleccionarUnGrupoDeAhorro,
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
                    GestionarMenuIniciarSesion();
                    break;
                case MainMenuOptions.Registrarse:
                    GestionarMenuRegistrarse();
                    break;
                case MainMenuOptions.Salir:
                    Salir();
                    break;
            }
        }

        public static void GestionarMenuIniciarSesion()
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuIniciarSesion>()
            .Title("Selecciona tu usuario")
            .AddChoices(
                //Help
                MenuIniciarSesion.Salir));

            switch (option)
            {
                case MenuIniciarSesion.Salir:
                    SalirMenuInicial();
                    break;
            }
        }

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
                    CrearCuenta();
                    break;
                case MenuRegistrarse.Salir:
                    SalirMenuInicial();
                    break;
            }
        }

        public static void CrearCuenta()
        {
            //Phol como hago esto
        }
        public static void Salir()
        {
            Console.WriteLine("¡Gracias por usar UdemBank");
        }

        public static void SalirMenuInicial()
        {
            MainMenuManagement();
        }

        public static void GestionarMenuUsuario()
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuUsuario>()
                .Title("Qué quieres hacer?")
                .AddChoices(
                    MenuUsuario.MiCuenta,
                    MenuUsuario.GestionarMisGruposDeAhorro,
                    MenuUsuario.Prestamos,
                    MenuUsuario.SalirDeCuenta
                    ));
        }

        public static void GestionarMenuMiCuenta()
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuMiCuenta>()
                .Title("Qué quieres hacer?")
                .AddChoices(
                    MenuMiCuenta.PagarDeudas,
                    MenuMiCuenta.HistorialMovimientos,
                    MenuMiCuenta.Salir
                    ));
        }

        public static void GestionarMenuGestionarMisGruposDeAhorro()
        {
              var option = AnsiConsole.Prompt(  
                new SelectionPrompt<MenuGestionarGruposDeAhorro>()
                .Title("Qué quieres hacer?")
                .AddChoices(
                    MenuGestionarGruposDeAhorro.CrearGrupoDeAhorro,
                    MenuGestionarGruposDeAhorro.SeleccionarUnGrupoDeAhorro,
                    MenuGestionarGruposDeAhorro.InvitarUsuarioAGrupoDeAhorro,
                    MenuGestionarGruposDeAhorro.DisolverGrupoDeAhorro,
                    MenuGestionarGruposDeAhorro.IngresarCapitalAGrupoDeAhorro,
                    MenuGestionarGruposDeAhorro.Salir
                    ));
        }

        public static void GestionarMenuPrestamos()
        {

        }

        public static void SalirCuenta()
        {

        }
    }
}