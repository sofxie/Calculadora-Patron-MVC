using Calculadora_MVC.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_MVC.Modelo
{
    public class Operacion
    {
        Form2 form2;
        public string _entradaactual = "";
        string valores_bin = "";
        public double _num1;
        public string _operacion;
        public double _num2;
        public double _result;
        public bool IsBinary = false;
        private List<double> memoria = new List<double>();
        private const int MemoriaDisponible = 10;
        private double _memoryNum;
        private readonly Historial _historial;
        public Operacion()
        {
            form2 = new Form2();
            _historial = new Historial();
        }
        public void MostrarHistorial()
        {
            using (StreamReader lector = new StreamReader(@"C:\Users\sofia\source\repos\Calculadora MVC\Calculadora MVC\Modelo\Bitacora.txt"))
            {
                while (!lector.EndOfStream)
                {
                    form2.listBox1.Items.Add(lector.ReadLine());
                }
            }

            // Mostrar el formulario con el historial.
            form2.ShowDialog();
        }
        public string EntradaActual()
        {
            return _entradaactual;
        }
        public void Primo()
        {
            double num = Convert.ToDouble(_entradaactual);
            bool esPrimo = EsrPrimo(num);

            var op = new Operaciones
            {
                Num1 = num,
                Operacion = "Primo",
                Resultado = esPrimo.ToString()
            };

            _historial.AgregarOperaciones(op);
            _entradaactual = Convert.ToString(esPrimo);
        }
        private bool EsrPrimo(double num)
        {
            if (num < 2 || num % 1 != 0) return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        public void Memoria()
        {
            if (_entradaactual == "False" || _entradaactual == "True" || IsBinary)
            {
                _entradaactual = "Dato Inválido";
            }
            else
            {
                _memoryNum = Convert.ToDouble(_entradaactual);
                GuardarMemoria(_memoryNum);
                _entradaactual = "";
            }
        }
        public void GuardarMemoria(double Num)
        {
            if (memoria.Count >= MemoriaDisponible)
            {
                memoria.RemoveAt(0); // Eliminar el primer número (el más antiguo)
            }
            memoria.Add(Num);
            string memoriaTexto = string.Join(", ", memoria);

            var op = new Operaciones
            {
                Num1 = Num,
                Operacion = "M+",
                Resultado = memoriaTexto
            };
            _historial.AgregarOperaciones(op);
        }
        public void Avg()
        {
            if (memoria.Count == 0)
            {
                _entradaactual = "0";
            }
            double promedio = memoria.Average();
            string memoriaTexto = string.Join(", ", memoria);
            var op = new Operaciones
            {
                Num1 = promedio,
                Operacion = "Avg",
                Resultado = memoriaTexto
            };
            _historial.AgregarOperaciones(op);
            _entradaactual = Convert.ToString(promedio);
        }
        public void AgregarDigito(string digit)
        {
            if (digit == "." && _entradaactual.Contains("."))
            {
                return;
            }
            _entradaactual += digit;
        }
        public void Calcular(double num2)
        {
            double resultado;
            switch (_operacion)
            {
                case "+":
                    resultado = _num1 + num2;
                    break;
                case "-":
                    resultado = _num1 - num2;
                    break;
                case "X":
                    resultado = _num1 * num2;
                    break;
                case "*":
                    resultado = _num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        resultado = -1;
                    }
                    resultado = _num1 / num2;
                    break;
                case "÷":
                    if (num2 == 0)
                    {
                        resultado = -1;
                    }
                    resultado = _num1 / num2;
                    break;
                default:
                    throw new InvalidOperationException("Operación no soportada.");
            }
            _entradaactual = Convert.ToString(resultado);
        }
        public void Binario()
        {
            valores_bin = "";

            // Intentar convertir _entradaactual a double
            if (double.TryParse(_entradaactual, out double numero))
            {
                // Usar solo la parte entera del número
                int parteEntera = (int)Math.Floor(numero);

                if (parteEntera < 0)
                {
                    valores_bin = "No se puede convertir un número negativo a binario.";
                }
                else if (parteEntera == 0)
                {
                    valores_bin = "0";
                }
                else
                {
                    string binario = "";
                    for (int l = parteEntera; l != 0; l /= 2)
                    {
                        binario = (l % 2) + binario;
                    }
                    valores_bin = binario;
                }

                // Agregar la operación al historial
                var op = new Operaciones
                {
                    Num1 = numero,
                    Num2 = null,
                    Operacion = "Binario",
                    Resultado = valores_bin
                };
                _historial.AgregarOperaciones(op);

                // Actualizar _entradaactual con el resultado
                _entradaactual = valores_bin;
            }
            else
            {
                _entradaactual = "ERROR: Entrada no válida.";
            }
        }
        public void AgregarOperacion(string operacion, string entradaactual)
        {
            if (!string.IsNullOrEmpty(entradaactual))
            {
                _num1 = Convert.ToDouble(entradaactual);
                _operacion = operacion;
                _entradaactual = "";
            }
        }
        public void Clear()
        {
            IsBinary = false;
            _entradaactual = string.Empty;
            _num1 = 0;
            _operacion = null;
            _num2 = 0;

        }
    }
}
