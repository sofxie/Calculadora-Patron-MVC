using Calculadora_MVC.Modelo;
using Calculadora_MVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_MVC
{
    public class Controler
    {
        private readonly Operacion _calcula;
        private readonly Historial _historial;
        public string _entradaactual = "";
        public double _num1;
        public string _operacion;
        public double? _num2;
        public string _result;
        public bool IsBinary = false;
        public Controler()
        {
            _calcula = new Operacion();
        }
        public void MostrarHistorial()
        {
            _calcula.MostrarHistorial();
        }
        public void GuardarMemoria()
        {
            _calcula.Memoria();
        }
        public void Avg()
        {
            _calcula.Avg();
        }
        public void Primo()
        {
            _calcula.Primo();
        }
        public void Binario()
        {
            _calcula.Binario();
        }
        public void Calcular()
        {
            double num = Convert.ToDouble(_calcula._entradaactual);
            _calcula.Calcular(num);
        }
        public void AgregarOperacion(string operacion)
        {
            _num1 = Convert.ToDouble(_calcula._entradaactual);
            _operacion = operacion;
            _calcula.AgregarOperacion(operacion, _calcula._entradaactual);
        }
        public void AgregarDigito(string digit)
        {
            _calcula.AgregarDigito(digit);
        }
        public void Clear()
        {
            _calcula.Clear();
        }
        public void AgregarOperaciones(Operaciones operacion)
        {
            _historial.AgregarOperaciones(operacion);
        }
        public string EntradaActual()
        {
            return _calcula.EntradaActual();
        }
    }
}