using System;
using System.Collections.Generic;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Uso de polimorfismo
            var lista = new List<Archivo>();

            lista.Add(new ArchivoExl("ar1.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos"));
            lista.Add(new ArchivoExl("ar2.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos"));
            lista.Add(new ArchivoExl("ar3.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos"));
            lista.Add(new ArchivoExl("ar4.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos"));
            lista.Add(new ArchivoTxt("ar1.txt", @"D:\Curso\CursosOscar\Practica\Archivos"));
            lista.Add(new ArchivoTxt("ar2.txt", @"D:\Curso\CursosOscar\Practica\Archivos"));
            lista.Add(new ArchivoTxt("ar3.txt", @"D:\Curso\CursosOscar\Practica\Archivos"));

            ProcesarArchivos(lista);

            //Sin polimorfismo
            //var listaTxt = new List<ArchivoTxt>();
            //var listaExl = new List<ArchivoExl>();

            //listaExl.Add(new ArchivoExl("ar1.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos"));
            //listaExl.Add(new ArchivoExl("ar2.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos"));
            //listaExl.Add(new ArchivoExl("ar3.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos"));

            //listaTxt.Add(new ArchivoTxt("ar1.txt", @"D:\Curso\CursosOscar\Practica\Archivos"));
            //listaTxt.Add(new ArchivoTxt("ar2.txt", @"D:\Curso\CursosOscar\Practica\Archivos"));
            //listaTxt.Add(new ArchivoTxt("ar3.txt", @"D:\Curso\CursosOscar\Practica\Archivos"));
            //listaTxt.Add(new ArchivoTxt("ar4.txt", @"D:\Curso\CursosOscar\Practica\Archivos"));

            //ProcesarArchivos(listaExl);
            //ProcesarArchivos(listaTxt);

            //var archi = new ArchivoExl("archi.xlsx", @"D:\Curso\CursosOscar\Practica\Archivos");
            //archi.Crear();

            //var architxt = new ArchivoTxt("archiv.txt", @"D:\Curso\CursosOscar\Practica\Archivos");
            //architxt.Crear();
            //Console.WriteLine(archi.NombreCompleto());

            Console.Read();
        }

        //Con Uso de polimorfismo
        static void ProcesarArchivos(List<Archivo> lista)
         { 
            foreach(var archivo in lista)
            {
                if(!archivo.Existe())
                {
                    archivo.Crear();
                }else
                {
                    archivo.Eliminar();
                    //archivo.Crear();
                }
            }
        }

        //Sin el uso de polimorfismo
        //static void ProcesarArchivos(List<ArchivoExl> lista)
        //{
        //    foreach (var archivo in lista)
        //    {
        //        if (!archivo.Existe())
        //        {
        //            archivo.Crear();
        //        }
        //    }
        //}
        //static void ProcesarArchivos(List<ArchivoTxt> lista)
        //{
        //    foreach (var archivo in lista)
        //    {
        //        if (!archivo.Existe())
        //        {
        //            archivo.Crear();
        //        }
        //    }
        //}

    }
}
