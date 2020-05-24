using System;

namespace Frontend
{
    public class Frontend
    {
        protected Frontend()
        {

        }

        public static void Main()
        {
            ProyectoTDD.ProyectoTDD _proyectoTdd = new ProyectoTDD.ProyectoTDD();
            Console.WriteLine("Calculadora por Consola");
            Console.WriteLine("Digite el PRIMER numero:");
            Console.WriteLine("Digite el SEGUNDO numero:");
            double resultado = _proyectoTdd.ingresoValores(12, 12, "sumar");
            Console.WriteLine(resultado.ToString());
            
        }
    }

    
}