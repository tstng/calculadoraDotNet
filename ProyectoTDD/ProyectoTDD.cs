using System;

namespace ProyectoTDD
{
    public class ProyectoTDD
    {
        public double ingresoValores(double numero1, double numero2, string operador){

            double resultado = 0;
            
            switch (operador)
            {
                case "sumar":
                    resultado = numero1 + numero2;
                    break;

                case "restar":
                    resultado = numero1 - numero2;
                    break;

                case "multiplicar":
                    resultado = numero1 * numero2;
                    break;

                case "dividir":
                    if (numero2 == 0) {
                        Console.WriteLine("No se puede dividir por CERO!");
                    }else
                    {
                        resultado = numero1 / numero2;    
                    }
                    break;

                default:
                    Console.WriteLine("NO ES UN OPERADOR VÁLIDO");
                    break;
            }

            double redondeo = Math.Round(resultado,2); //Redondear cifras decimales a 2
            return redondeo;
        }

        public bool esNumerico(string stringNumero){
            double numero;
            return double.TryParse(stringNumero, out numero);
        }

        public double noTieneCovertura(double numero1, double numero2)
        {
            return numero1 + numero2;
        }
    }
}