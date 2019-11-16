using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresas
    {
        [Key]
        public int EmpresaId { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int UsuarioId { get; set; }
        public Empresas()
        {
            EmpresaId = 0;
            UsuarioId = 0;
            Descripcion = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
        }
    }
}
