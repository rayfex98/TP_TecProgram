using NUnit.Framework;
using Entidades;
using bll_modulo;

namespace PruebasUnitarias
{
    public class TestCategoria
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CatInsert()
        {
            Categoria unCat = new Categoria();
            NCategoria Cat = new NCategoria();
            unCat.Nombre = "Snaks";
            Assert.AreEqual(Cat.Nuevo(unCat), true);
            Assert.Pass();
        }
        public void CatDelete()
        {
            Categoria unCat = new Categoria();
            NCategoria Cat = new NCategoria();
            unCat.Nombre = '';

            Cat.Editar(unCat);

            Assert.Pass();
        }
    }
}