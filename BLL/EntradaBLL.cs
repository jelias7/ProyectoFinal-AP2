using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EntradaBLL
    {
        public static bool Guardar(EntradaMonedas i)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                RepositorioBase<Divisas> prod = new RepositorioBase<Divisas>();


                if (db.Entrada.Add(i) != null)
                {
                    var ex = prod.Buscar(i.DivisaId);
                    ex.Existencia = ex.Existencia + i.Existencia;
                    prod.Modificar(ex);

                    paso = db.SaveChanges() > 0;

                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(EntradaMonedas entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Divisas> prod = new RepositorioBase<Divisas>();
            RepositorioBase<EntradaMonedas> entr = new RepositorioBase<EntradaMonedas>();

            try
            {

                var anterior = entr.Buscar(entrada.EntradaId);
                var div = prod.Buscar(entrada.DivisaId);

                div.Existencia = div.Existencia + (entrada.Existencia - anterior.Existencia);
                prod.Modificar(div);


                db.Entry(entrada).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Divisas> prod = new RepositorioBase<Divisas>();
            RepositorioBase<EntradaMonedas> entr = new RepositorioBase<EntradaMonedas>();



            try
            {

                var entrada = entr.Buscar(id);
                var div = prod.Buscar(entrada.DivisaId);

                div.Existencia = div.Existencia - entrada.Existencia;
                prod.Modificar(div);

                db.Entry(entrada).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }


    }
}
