using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public int Id { get; set; }       
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Departamento { get; set; }
        public string Piso { get; set; }
        public int CodPostal { get; set; }
        public string  Ciudad { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            // Mostrar dirección en formato legible
            string depto = string.IsNullOrEmpty(Departamento) ? "" : $" Depto. {Departamento}";
            string piso = string.IsNullOrEmpty(Piso) ? "" : $" Piso {Piso}";
            string cp = CodPostal > 0 ? $", C.P.: {CodPostal}" : "";
            string ciudad = string.IsNullOrEmpty(Ciudad) ? "" : $", {Ciudad}";

            return $"{Calle} {Altura}{depto}{piso}{cp}{ciudad}";
        }
    }
}
