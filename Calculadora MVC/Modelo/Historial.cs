﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_MVC.Modelo
{
    public class Historial
    {
        public Historial()
        {
        }
        public void AgregarOperaciones(Operaciones operacion)
        {
            string opera = operacion.ToString();
            using (StreamWriter escribir = new StreamWriter(@"C:\Users\sofia\source\repos\Calculadora MVC\Calculadora MVC\Modelo\Bitacora.txt", append: true))
            {
                if (operacion.Operacion == "Primo" || operacion.Operacion == "Binario")
                {
                    opera = $"{operacion.Num1}  {operacion.Operacion}  {operacion.Resultado}";
                }

                escribir.WriteLine(opera);
            }
        }
        public IEnumerable<Operaciones> ObtenerHistorial()
        {
            var operaciones = new List<Operaciones>();
            foreach (var linea in File.ReadAllLines(@"C:\Users\sofia\source\repos\Calculadora MVC\Calculadora MVC\Modelo\Bitacora.txt"))
            {
                var partes = linea.Split(' ');
                operaciones.Add(new Operaciones
                {
                    Num1 = double.Parse(partes[0]),
                    Operacion = partes[1],
                    Num2 = double.Parse(partes[2]),
                    Resultado = partes[4]
                });
            }
            return operaciones;
        }
        public string LeerHistorialComoTexto()
        {
            return File.Exists(@"C:\Users\sofia\source\repos\Calculadora Patron Capas\Calculadora Patron Capas\Bitacora.txt") ? File.ReadAllText(@"C:\Users\sofia\source\repos\Calculadora Patron Capas\Calculadora Patron Capas\Bitacora.txt") : "El historial está vacío.";
        }
    }
}
