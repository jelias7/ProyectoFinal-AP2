using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasaDeCambio.Tests
{
    [TestClass]
    public class CambiosTest
    {
        [TestMethod()]
        public void Guardar()
        {
            Cambios m = new Cambios();
            m.CambiosId = 1;
            m.Nombre_Persona = "Juan";
            m.Total_Cambiado = 100;
            m.Fecha = DateTime.Now;

            bool paso = false;
            paso = BLL.CambiosBLL.Guardar(m);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void Modificar()
        {
            bool paso = false;
            RepositorioBase<Cambios> repositoriobase = new RepositorioBase<Cambios>();
            Cambios m = repositoriobase.Buscar(1);
            m.Total_Cambiado = 500;
            paso = BLL.CambiosBLL.Modificar(m);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void Eliminar()
        {
            bool paso = false;
            paso = BLL.CambiosBLL.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}
