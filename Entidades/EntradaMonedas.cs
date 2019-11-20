using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntradaMonedas
    {
        [Key]
        public int EntradaId { get; set; }
        public int DivisaId { get; set; }
        public decimal Existencia { get; set; }
        public DateTime Fecha { get; set; }
        public EntradaMonedas()
        {
            EntradaId = 0;
            DivisaId = 0;
            Existencia = 0;
            Fecha = DateTime.Now;
        }
    }
}
