using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Cambios
    {
        [Key]
        public int CambiosId { get; set; }
        public string Nombre_Persona { get; set; }
        public decimal Total_Cambiado { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<CambiosDetalle> Detalle { get; set; }
        public Cambios()
        {
            CambiosId = 0;
            Nombre_Persona = string.Empty;
            Total_Cambiado = 0;
            Fecha = DateTime.Now;
            UsuarioId = 0;
            Detalle = new List<CambiosDetalle>(); 
        }
    }
}
