using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POO
{
    public class ArchivoTxt : Archivo
    {
        public ArchivoTxt(string nombre, string ubicacion) : base(nombre, ubicacion)
        {
        }


        public override void Crear()
        {
            if (Existe())
            {
                throw new ArgumentException("El archivo que deseas crear ya existe");
            }

            try
            {
                File.Create(NombreCompleto()).Dispose();
            }
            catch (IOException ex)
            {
                throw new IOException("Error al crear el archivo" + ex.Message);
            }
        }
    }
}
