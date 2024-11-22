using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_MVC
{
    public class Controler
    {
        private readonly InsertarDatos _logica;
        private string _entradaactual = "";
        private double _num1;
        private string _operacion;
        private double _num2;
        private double _result;

        public Controler()
        {
            _logica = new InsertarDatos();
        }
        public void AgregarDigito(string digit)
        {
            string text = _logica.AgregarDigito(string digit);
            _entradaactual = text;
        }
        public string EntradaActual()
        {
            return _entradaactual;
        }
    }
}
