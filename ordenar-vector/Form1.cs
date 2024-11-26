using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordenar_vector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtVector.Multiline = true;
            txtVector.ReadOnly = true;
        }
        Random random = new Random();

        //variables para el tamano del texbox
        float factorAncho = 1.6f;
        float factorAlto = 1.2f;

        private async void txtNum_Click(object sender, EventArgs e)
        {
            txtVector.Clear();
            if (int.TryParse(txtNum.Text, out int number))
            {
                int[] vector = new int[number];

                //Define tamano celdas
                int altoCelda = 10;
                int anchoCelda = 30;

                //Modifica el tamano del texbox
                txtVector.Width = (int)((number * anchoCelda) * factorAncho);
                txtVector.Height = (int)((number * altoCelda) * factorAlto);

                for (int i = 0; i < number; i++)
                {
                    vector[i] = random.Next(50);
                }

                //Imprimir arrgelo original
                foreach(int i in vector)
                {
                    txtVector.AppendText( $"|  {i}  ");
                    await Task.Delay(500);
                }
                txtVector.Text += "|";
                await Task.Delay(2000);
                txtVector.Clear();

                //Imprimir arreglo ordenado
                var oredenada = vector.OrderBy(n => n).ToArray();

                foreach (var i in oredenada)
                {
                    txtVector.AppendText($"|  {i}  ");
                    await Task.Delay(500);
                }
                txtVector.Text += "|";
            }
            else if (txtNum.Text == "")
            { }
            else
            {
                MessageBox.Show("Ingresa un numero entero");
            }
        }

        public void txtNum_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblOrden_Click(object sender, EventArgs e)
        {

        }
    }
}
