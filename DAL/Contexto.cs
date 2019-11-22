using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Divisas> Divisas { get; set; }
        public DbSet<EntradaMonedas> Entrada { get; set; }
        public DbSet<Cambios> Cambios { get; set; }
        public Contexto() : base("ConStr") { }
    }
}
