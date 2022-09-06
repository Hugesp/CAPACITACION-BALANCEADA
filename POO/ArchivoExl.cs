using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;

namespace POO
{
    public class ArchivoExl : Archivo
    {
        public ArchivoExl(string nombre, string ubicacion) : base(nombre, ubicacion)
        {
        }

        public override void Crear()
        {
            if(Existe())
            {
                throw new ArgumentException("El excel ya existe");
            }

            try
            {
                var libro = new XLWorkbook();
                libro.Worksheets.Add("Hoja1");
                libro.Worksheets.Add("Hoja2");
                libro.Worksheets.Add("Hoja3");

                libro.SaveAs(NombreCompleto());
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Error al crear el archivo {0}", Nombre), ex);
            }
        }
    }
}
