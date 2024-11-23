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
            this.KeyPreview = true;
            this.KeyPress += Form1_KeyPress;
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
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool Binario = controlador.Isbinary();
            if (textBox.Text != "ERROR" && textBox.Text != "True" && textBox.Text != "False" && !Binario)
            {
                if (char.IsDigit(e.KeyChar) || ".".Contains(e.KeyChar))
                {
                    controlador.AgregarDigito(e.KeyChar.ToString());
                }
                else if ("+-*/".Contains(e.KeyChar))
                {
                    controlador.AgregarOperacion(e.KeyChar.ToString());
                }
                else if ("=".Contains(e.KeyChar))
                {
                    controlador.Calcular();
                }
                else if ("c".Contains(e.KeyChar) || "C".Contains(e.KeyChar))
                {
                    controlador.Clear();
                }
                textBox.Text = controlador.EntradaActual();
                e.Handled = true;
            }
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
            bool Binario = controlador.Isbinary();
            var boton = sender as Button;
            if (boton != null && textBox.Text != "ERROR" && textBox.Text != "True" && textBox.Text != "False" && Binario != true)
            {
                // Delegar a la capa de aplicación
                controlador.AgregarDigito(boton.Text);
                textBox.Text = controlador.EntradaActual();
            }
        }
        private void buttonIgual_Click(object sender, EventArgs e)
        {
            controlador.Calcular();
            textBox.Text = controlador.EntradaActual();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            controlador.Primo();
            textBox.Text = controlador.EntradaActual();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlador.Binario();
            textBox.Text = controlador.EntradaActual();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            controlador.Clear();
            textBox.Text = controlador.EntradaActual();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            controlador.GuardarMemoria();
            textBox.Text = controlador.EntradaActual();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlador.MostrarHistorial();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            controlador.Avg();
            textBox.Text = controlador.EntradaActual();
        }
    }
}
