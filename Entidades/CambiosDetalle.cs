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
        public int DeDivisaId { get; set; }
        public int ADivisaId { get; set; }
        public decimal De { get; set; }
        public decimal A { get; set; }
        public DateTime Fecha { get; set; }
        public CambiosDetalle()
        {
            DetalleId = 0;
            DeDivisaId = 0;
            ADivisaId = 0;
            De = 0;
            A = 0;
            Fecha = DateTime.Now;
        }
        public CambiosDetalle(int deid, int aid, decimal de, decimal a, DateTime date)
        {
            DeDivisaId = deid;
            ADivisaId = aid;
            De = de;
            A = a;
            Fecha = date;
        }
    }
}
