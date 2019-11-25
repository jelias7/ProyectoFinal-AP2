using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasaDeCambio.Tests
{
    [TestClass]
    public class EntradaTest
    {
        [TestMethod()]
        public void Guardar()
        {
            EntradaMonedas m = new EntradaMonedas();
            m.EntradaId = 1;
            m.DivisaId = 1;
            m.Existencia = 1000;
            m.Fecha = DateTime.Now;

            bool paso = false;
            paso = BLL.EntradaBLL.Guardar(m);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void Modificar()
        {
            bool paso = false;
            RepositorioBase<EntradaMonedas> repositoriobase = new RepositorioBase<EntradaMonedas>();
            EntradaMonedas m = repositoriobase.Buscar(1);
            m.Existencia = 500;
            paso = BLL.EntradaBLL.Modificar(m);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void Eliminar()
        {
            bool paso = false;
            paso = BLL.EntradaBLL.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}
