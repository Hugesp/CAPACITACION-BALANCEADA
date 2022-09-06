using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POO
{
    //Una clase abstracta implementa código y siempre necesita un método abstracto para funcionar
    public abstract class Archivo
    {
        public Archivo(string nombre, string ubicacion)
        {
            Nombre = nombre;
            Ubicacion = ubicacion;
        }

        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public string NombreCompleto()
        {
            return Path.Combine(Ubicacion,Nombre);
        }

        public bool Existe()
        {
            return File.Exists(NombreCompleto());
        }

        public void Eliminar()
        {
            if (!Existe())
            {
                throw new ArgumentException("El archivo que deseas eliminar no existe.");
            }

            try
            {
                File.Delete(NombreCompleto());
            }catch(IOException ex)
            {
                throw new IOException("Error al eliminar archivo" + ex.Message);
            }

        }
        //El método abstracto solo se declara, quien se encarga de implementarlo son las clases derivadas
        public abstract void Crear();

    }
}
