using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tipo_Usuario { get; set; }
        public int EmpresaId { get; set; }
        public DateTime Fecha { get; set; }
        public Usuarios()
        {
            UsuarioId = 0;
            EmpresaId = 0;
            Username = string.Empty;
            Password = string.Empty;
            Tipo_Usuario = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
