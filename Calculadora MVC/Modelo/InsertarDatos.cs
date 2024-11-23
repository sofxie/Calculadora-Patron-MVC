using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora_MVC.Modelo;

namespace Calculadora_MVC
{
    public class InsertarDatos
    {
        public string _entradaactual;
        public InsertarDatos()
        {
            _entradaactual = string.Empty;
        }
        
        public string EntradaActual()
        {
            return _entradaactual;
        }
    }
}
