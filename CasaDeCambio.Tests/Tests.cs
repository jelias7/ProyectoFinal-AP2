using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CasaDeCambio.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod()]
        public void Guardar()
        {
            Usuarios user = new Usuarios();
            user.UsuarioId = 1;
            user.Username = "admin";
            user.Password = "123";
            user.Tipo_Usuario = "Administrador";
            user.Fecha = DateTime.Now;

            RepositorioBase<Usuarios> r = new RepositorioBase<Usuarios>();
            bool paso = false;
            paso = r.Guardar(user);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void Modificar()
        {
            RepositorioBase<Usuarios> repositoriobase = new RepositorioBase<Usuarios>();
            bool paso = false;
            Usuarios user = repositoriobase.Buscar(1);
            user.Password = "admin";
            paso = repositoriobase.Modificar(user);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void Eliminar()
        {
            RepositorioBase<Usuarios> repositoriobase = new RepositorioBase<Usuarios>();
            bool paso = false;
            paso = repositoriobase.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}
