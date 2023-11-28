using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Models;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase(Idioma.Castellano, "<h1>Lista vacía de formas!</h1>")]
        [TestCase(Idioma.Ingles, "<h1>Empty list of shapes!</h1>")]
        [TestCase(Idioma.Italiano, "<h1>Elenco vuoto di forme!</h1>")]
        public void TestResumenListaVacia(int idioma, string esperado)
        {
            Assert.AreEqual(esperado, FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), idioma));
        }

        [TestCase(Idioma.Castellano, "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25")]
        [TestCase(Idioma.Ingles, "<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>1 shapes Perimeter 20 Area 25")]
        [TestCase(Idioma.Italiano, "<h1>Rapporto delle forme</h1>1 Quadrato | Settore 25 | Perimetro 20 <br/>TOTAL:<br/>1 forme Perimetro 20 Area 25")]
        public void TestResumenListaConUnCuadrado(int idiomas, string esperado)
        {
            var cuadrados = new List<IFormaGeometrica> {new Cuadrado(5)};
            var resumen = FormaGeometrica.Imprimir(cuadrados, idiomas);
            Assert.AreEqual(esperado, resumen);
        }

        [TestCase(Idioma.Castellano, "<h1>Reporte de Formas</h1>3 Cuadrados | Area 35 | Perimetro 36 <br/>TOTAL:<br/>3 formas Perimetro 36 Area 35")]
        [TestCase(Idioma.Ingles, "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35")]
        [TestCase(Idioma.Italiano, "<h1>Rapporto delle forme</h1>3 Quadratos | Settore 35 | Perimetro 36 <br/>TOTAL:<br/>3 forme Perimetro 36 Area 35")]
        public void TestResumenListaConMasCuadrados(int idiomas, string esperado)
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, idiomas);
            Assert.AreEqual(esperado, resumen);
        }

        [TestCase(Idioma.Ingles, "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65")]
        [TestCase(Idioma.Castellano, "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,60 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65")]
        public void TestResumenListaConMasTipos(int idioma, string expectedResult)
        {
            var formas = GetTestData();
            var resumen = FormaGeometrica.Imprimir(formas, idioma);
            Assert.AreEqual(expectedResult, resumen);
        }

        [TestCase(Idioma.Castellano, "<h1>Reporte de Formas</h1>1 Rectangulo | Area 20 | Perimetro 18 <br/>TOTAL:<br/>1 formas Perimetro 18 Area 20")]
        [TestCase(Idioma.Ingles, "<h1>Shapes report</h1>1 Rectangle | Area 20 | Perimeter 18 <br/>TOTAL:<br/>1 shapes Perimeter 18 Area 20")]
        [TestCase(Idioma.Italiano, "<h1>Rapporto delle forme</h1>1 Rettangolo | Settore 20 | Perimetro 18 <br/>TOTAL:<br/>1 forme Perimetro 18 Area 20")]
        public void TestResumenListaConUnRectangulo(int idiomas, string esperado)
        {
            var rectangulos = new List<IFormaGeometrica> {new Rectangulo(5, 4)};
            var resumen = FormaGeometrica.Imprimir(rectangulos, idiomas);
            Assert.AreEqual(esperado, resumen);
        }

        [TestCase(Idioma.Castellano, "<h1>Reporte de Formas</h1>1 Trapecio | Area 13,50 | Perimetro 22 <br/>TOTAL:<br/>1 formas Perimetro 22 Area 13,50")]
        [TestCase(Idioma.Ingles, "<h1>Shapes report</h1>1 Trapeze | Area 13.5 | Perimeter 22 <br/>TOTAL:<br/>1 shapes Perimeter 22 Area 13.5")]
        [TestCase(Idioma.Italiano, "<h1>Rapporto delle forme</h1>1 Trapezio | Settore 13,50 | Perimetro 22 <br/>TOTAL:<br/>1 forme Perimetro 22 Area 13,50")]
        public void TestResumenListaConUnTrapecio(int idiomas, string esperado)
        {
            var trapecios = new List<IFormaGeometrica> {new Trapecio(5, 4, 3, 6, 7)};
            var resumen = FormaGeometrica.Imprimir(trapecios, idiomas);
            Assert.AreEqual(esperado, resumen);
        }

        #region Private Methods
        private List<IFormaGeometrica> GetTestData()
        {
            return new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };
        }
        #endregion
    }
}
