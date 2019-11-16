using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajaRegistradora
    {
        [Key]
        public int CajaId { get; set; }
        public decimal ExistenciaPeso { get; set; }
        public decimal ExistenciaDolar { get; set; }
        public decimal ExistenciaEuro { get; set; }
        public decimal ExistenciaLibraEsterlina { get; set; }
        public DateTime Fecha { get; set; }
        public CajaRegistradora()
        {
            CajaId = 0;
            ExistenciaPeso = 0;
            ExistenciaDolar = 0;
            ExistenciaEuro = 0;
            ExistenciaLibraEsterlina = 0;
            Fecha = DateTime.Now;
        }
    }
}
