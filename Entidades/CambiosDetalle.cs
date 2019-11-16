using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class CambiosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int CajaId { get; set; }
        public string Divisa { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Cambio { get; set; }
        public DateTime Fecha { get; set; }
        public CambiosDetalle()
        {
            DetalleId = 0;
            CajaId = 0;
            Divisa = string.Empty;
            Cantidad = 0;
            Cambio = 0;
            Fecha = DateTime.Now;
        }
        public CambiosDetalle(string div, decimal can, decimal cam, DateTime date)
        {
            Divisa = div;
            Cantidad = can;
            Cambio = cam;
            Fecha = date;
        }
    }
}
