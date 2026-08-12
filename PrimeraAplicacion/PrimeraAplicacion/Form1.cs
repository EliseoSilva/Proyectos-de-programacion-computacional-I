namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double num1 = 0, num2 = 0, resultado = 0, indexOpcion = 0;
            num1 = double.Parse(txtNum1.Text);
            num2 = double.Parse(txtNum2.Text);

            indexOpcion = cboOpciones.SelectedIndex;
            switch (indexOpcion)
            {
                case 0:
                    resultado = num1 + num2;
                    break;
                case 1:
                    resultado = num1 - num2;
                    break;
                case 2:
                    resultado = num1 * num2;
                    break;
                case 3:
                    resultado = num1 / num2;
                    break;
                case 4:
                    resultado = Math.Pow(num1, num2);
                    break;
                case 5:
                    resultado = Math.Pow(num1, 1 / num2);
                    break;
                case 6:
                    resultado = 1;
                    for (int i = 1; i <= num1; i++)
                    {
                        resultado = resultado * i;
                    }
                    break;
            }
            /*if (rdbSuma.Checked)
            {
                resultado = num1 + num2;

            }
            if (rdbResta.Checked)
            {
                resultado = num1 - num2;
            }

            if (rdbMultiplicacion.Checked)
            {
                resultado = num1 * num2;
            }

            if (rdbDivision.Checked)
                resultado = num1 / num2;

            if (rdbExponente.Checked)
            {
                resultado = Math.Pow(num1, num2);
            }

            if (rdbRaiz.Checked)
            {
                resultado = Math.Pow(num1, 1 / num2);
            }

            if (rdbFactorial.Checked)
            {
                resultado = 1;
                for (int i = 0; i <= num1; i++)
                {
                    resultado = resultado * i;
                }
            }
            */
            lblRespuesta.Text = "Respuesta:" + Math.Round(resultado, 4).ToString();
        }
    }
}
