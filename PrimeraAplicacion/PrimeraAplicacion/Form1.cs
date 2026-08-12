namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaludo_Click(object sender, EventArgs e)
        {
            double num1, num2, resultado;
            num1 = double.Parse(txtNum1.Text);
            num2 = double.Parse(txtNum2.Text);

            resultado = num1 + num2;

            lblRespuesta.Text = "Respuesta: " + resultado.ToString();
        }
    }
}
