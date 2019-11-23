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
    public class CambiosBLL
    {
        public static bool Guardar(Cambios c)
        {
            bool paso = false;
            RepositorioBase<Divisas> prod = new RepositorioBase<Divisas>();
            Contexto db = new Contexto();
            try
            {
                if (db.Cambios.Add(c) != null)
                {
                    foreach (var item in c.Detalle)
                    {
                        var de = prod.Buscar(item.DeDivisaId);
                        var a = prod.Buscar(item.ADivisaId);
                        de.Existencia += item.De;
                        a.Existencia -= item.A;

                        prod.Modificar(a);
                        prod.Modificar(de);
                    }
                    paso = db.SaveChanges() > 0;
                }

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

            try
            {
                var c = db.Cambios.Find(id);
                foreach (var item in c.Detalle)
                {
                    var de = prod.Buscar(item.DeDivisaId);
                    var a = prod.Buscar(item.ADivisaId);
                    de.Existencia += item.De;
                    a.Existencia += item.A;
                    prod.Modificar(de);
                    prod.Modificar(a);
                }
                db.Entry(c).State = EntityState.Deleted;
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
        public static bool Modificar(Cambios c)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Cambios> vent = new RepositorioBase<Cambios>();
            RepositorioBase<Divisas> prod = new RepositorioBase<Divisas>();
            try
            {
                var cam = vent.Buscar(c.CambiosId);


                if (c != null)
                {
                    foreach (var item in cam.Detalle)
                    {
                        db.Divisas.Find(item.DeDivisaId).Existencia += item.De;
                        db.Divisas.Find(item.ADivisaId).Existencia += item.A;
                        if (!c.Detalle.ToList().Exists(v => v.DetalleId == item.DetalleId))
                        {
                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in c.Detalle)
                    {
                        db.Divisas.Find(item.DeDivisaId).Existencia -= item.De;
                        db.Divisas.Find(item.ADivisaId).Existencia -= item.A;
                        var estado = item.DetalleId > 0 ? EntityState.Modified : EntityState.Added;
                        db.Entry(item).State = estado;
                    }

                    db.Entry(c).State = EntityState.Modified;
                }

                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
