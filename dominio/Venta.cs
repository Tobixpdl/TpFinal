using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public int DNIComprador { get; set; }
        public int DNIVendedor { get; set; }
        public string Usuario { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public  string Estado { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }
    }
}
