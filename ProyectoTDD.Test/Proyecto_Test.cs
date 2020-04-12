using NUnit.Framework;
using System;
using System.IO;
using System.Text.RegularExpressions;

/*
    Requisitos:
        Backend
        - OK_Debe existir clase para la aplicación.
        - OK_Debe recibir solamente valores numericos
        - OK_Debe recibir 2 valores numericos y un string con el nombre del operador
        - OK_Debe Sumar 2 valores numericos y devolver su resultado
        - OK_Debe Restar 2 valores numericos y devolver su resultado
        - OK_Debe Multiplicar 2 valores numericos y devolver su resultado
        - OK_Debe Dividir 2 valores numericos y devolver su resultado
        - OK_Si el OPERADOR es distinto debe devolver mensaje "NO ES UN OPERADOR VÁLIDO"
        - OK_No debe dividir por CERO.
        - OK_Debe recibir y calcular números con 2 cifras decimales.
        Frontend
        - OK_Mensaje de Bienvenida
        - OK_Mensaje Solicitar primer
        - Control de alfanumerico primer y segundo número

*/

namespace ProyectoTDD.Test
{
    
    [TestFixture]
    public class Tests
    {
        private ProyectoTDD _ProyectoTDD;

        [SetUp]
        public void Setup()
        {
            _ProyectoTDD = new ProyectoTDD();
        }

        [TearDown]
        public void TearDown(){
            _ProyectoTDD = null;
        }

        [Test]
        public void esNumerico(){
            bool boolEsNumerico = false;
            boolEsNumerico = _ProyectoTDD.esNumerico("12");
            Assert.AreEqual(true, boolEsNumerico, "Debe ser numerico.");

            boolEsNumerico = _ProyectoTDD.esNumerico("abcde");
            Assert.AreEqual(false, boolEsNumerico, "Debe ser numerico.");
        }

        [Test]
        public void ReciboDosValores(){

            _ProyectoTDD.ingresoValores(1,2, "sumar");
        }

        [Test]
        public void DebeSumar(){
            double resultado = _ProyectoTDD.ingresoValores(1,2,"sumar");

            Assert.AreEqual(3,resultado,"Probando la Suma");
        }

        [Test]
        public void DebeRestar(){
            double resultado = _ProyectoTDD.ingresoValores(2,1,"restar");

            Assert.AreEqual(1,resultado,"Probando la Resta");
        }

        [Test]
        public void DebeMultiplicar(){
            double resultado = _ProyectoTDD.ingresoValores(2,1,"multiplicar");

            Assert.AreEqual(2,resultado,"Probando la Multiplicación");
        }

        [Test]
        public void DebeDividir(){
            double resultado = _ProyectoTDD.ingresoValores(4,2,"dividir");

            Assert.AreEqual(2,resultado,"Probando la División.");
        }

        [Test]
        public void DevolverMensajeSiOperadorEsDiferente(){
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                double calcular = _ProyectoTDD.ingresoValores(1,1,"OtroOperador");
                var resultado = sw.ToString().Trim();

                Assert.AreEqual("NO ES UN OPERADOR VÁLIDO",resultado, "Probando mensaje de operador no válido");
            }
        }

        [Test]
        public void DivisionPorCero(){
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                double calcular;
                calcular = _ProyectoTDD.ingresoValores(2,0,"dividir");
                var resultado = sw.ToString().Trim();

                Assert.AreEqual("No se puede dividir por CERO!",resultado, "Probando mensaje Division por CERO.");
            }
        }

        [Test]
        public void CalcularDecimales(){
            double resultado;
            resultado = _ProyectoTDD.ingresoValores(4.20,2.10,"sumar");

            Assert.AreEqual(6.30,resultado,"Probando Calculo con Decimales");

        }

        [Test]
        public void Frontend_MensajeBienvenida(){
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Frontend.Frontend.Main();

                var outConsola = sw.ToString().Trim();
                var splitLineas = Regex.Split(outConsola, "\r\n|\r|\n");

                Assert.AreEqual("Calculadora por Consola", splitLineas[0], "Probando mensaje de bienvenida");
            }
        }

        [Test]
        public void Frontend_ControlAlfaNumericos(){
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Frontend.Frontend.Main();

                var outConsola = sw.ToString().Trim();
                var splitLineas = Regex.Split(outConsola, "\r\n|\r|\n");

                Assert.AreEqual("Digite el PRIMER numero:", splitLineas[1], "Debe ingresar PRIMER número");
                Assert.AreEqual("Digite el SEGUNDO numero:", splitLineas[2], "Debe ingresar SEGUNDO número");
            }
        }        
    }
}