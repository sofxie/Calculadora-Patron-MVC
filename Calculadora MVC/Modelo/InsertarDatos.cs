using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_MVC
{
    public class InsertarDatos
    {
        private readonly Controler _controlador;
        private string _entradaactual = "";
        public InsertarDatos()
        {
            _controlador = new Controler();
        }
        public string AgregarDigito(string digit)
        {
            if (digit == "." && _entradaactual.Contains("."))
            {
                return None;
            }
            _entradaactual += digit;
            return _entradaactual;
        }
    }
}
