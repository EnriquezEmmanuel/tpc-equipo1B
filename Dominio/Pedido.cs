using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        /*
        public int IdPediddo { get; set; }
        public DateTime Fecha{ get; set; }
        public Hoja Hoja{ get; set; }
        public Calidad Calidad{ get; set; }
        public int CopiaPorHoja { get; set; }
        public bool Margenes{ get; set; }
        public int Copias{ get; set; }
        public string Estado{ get; set; }
        */
        public int IdPedido { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public string Hoja { get; set; }
        //public decimal ValorHoja { get; set; }
        public string Color { get; set; }
        public string Calidad { get; set; }
        //public decimal ValorImpresion { get; set; }
        public int CopiaPorHoja { get; set; }
        public string Margenes { get; set; }
        public int Copias { get; set; }
        public string Estado { get; set; }
                
    }
}
