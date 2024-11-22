using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_MVC
{
    public partial class Form1 : Form
    {
        private readonly Controler controlador;
        public Form1()
        {
            InitializeComponent();
            controlador = new Controler();
            // Boton de numero de 0-9
            button13.Click += BotonNumero_Click;
            button10.Click += BotonNumero_Click;
            button11.Click += BotonNumero_Click;
            button12.Click += BotonNumero_Click;
            button7.Click += BotonNumero_Click;
            button8.Click += BotonNumero_Click;
            button9.Click += BotonNumero_Click;
            button3.Click += BotonNumero_Click;
            button6.Click += BotonNumero_Click;
            button5.Click += BotonNumero_Click;

            button14.Click += BotonNumero_Click;

            // Boton de Operaciones
            buttonDividir.Click += BotonOperacion_Click;
            buttonMultiplicar.Click += BotonOperacion_Click;
            buttonRestar.Click += BotonOperacion_Click;
            buttonSumar.Click += BotonOperacion_Click;
        }
        private void BotonOperacion_Click(object sender, EventArgs e)
        {
            var boton = sender as Button;
            if (boton != null && textBox.Text != "ERROR" && textBox.Text != "True" && textBox.Text != "False")
            {
                controlador.AgregarOperacion(boton.Text);
                textBox.Text = controlador.EntradaActual();
            }
        }
        private void BotonNumero_Click(object sender, EventArgs e)
        {
            var boton = sender as Button;
            if (boton != null && textBox.Text != "ERROR" && textBox.Text != "True" && textBox.Text != "False")
            {
                // Delegar a la capa de aplicación
                controlador.AgregarDigito(boton.Text);
                textBox.Text = controlador.EntradaActual();
            }
        }

    }
}
