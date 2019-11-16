using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Divisas
    {
        [Key]
        public int DivisaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Tasa_Compra { get; set; }
        public decimal Tasa_Venta { get; set; }
        public DateTime Fecha { get; set; }
        public Divisas()
        {
            DivisaId = 0;
            Descripcion = string.Empty;
            Tasa_Compra = 0;
            Tasa_Venta = 0;
            Fecha = DateTime.Now;
        }
    }
}
