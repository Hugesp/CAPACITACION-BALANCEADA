using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Clientes
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Rfc { get; set; }
    }
}
