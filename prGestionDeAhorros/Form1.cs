namespace prGestionDeAhorros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desactivarControles();
        }
        private double monto;

        private void activarControles()
        {
            txtCliente.Enabled = false;
            txtMonto.Enabled = false;
             btnAbrir.Enabled = false;

            btnDeposito.Enabled = true;
            btnRetiro.Enabled = true;

                            
        }
        private void desactivarControles()
        {
            txtCliente.Enabled = true;
            txtMonto.Enabled = true;
            btnAbrir.Enabled = true;

            btnDeposito.Enabled = false;
            btnRetiro.Enabled = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string cliente;
            //leer datos
            cliente = txtCliente.Text;
            monto = Convert.ToDouble(txtMonto.Text);

            if(monto>0)
            {
                activarControles();
            }
            else
            {
                MessageBox.Show("El monto debe ser mayor o igual a cero", "Gestion de ahorros",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }
        private double leer (string mensaje)
        {
            double cantidad;
            cantidad = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Ingrese monto a " + mensaje, "Gestion de ahorros", "0", 100, 0));
            return cantidad;

        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            double deposito;
            deposito = leer("Depositar");
            monto = monto + deposito;
            lstDeposito.Items.Add(deposito);
            mostrar();

        }
        private void mostrar()
        {
            txtSaldo.Text = Convert.ToString(monto);
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            double retiro;
            retiro = leer("Retirar");

            //Evaluamos

            if(retiro <= monto)
            {
                monto = monto - retiro;
                lstRetiro.Items.Add(retiro);
                mostrar();
            }
            else
            {
                MessageBox.Show("La cantidad de retiro es mayor al monto disponible", "Gestion de ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtMonto.Clear();
            txtSaldo.Clear();
            lstDeposito.Items.Clear();
            lstRetiro.Items.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}