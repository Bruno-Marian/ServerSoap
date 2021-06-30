using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ClassSoap;

namespace RequestSoap
{
    public partial class Form_principal : Form
    {
        public Form_principal()
        {
            InitializeComponent();
        }

        public bool ValidadeForm 
        {
            get
            {
                if (!double.TryParse(txtVlCarta.Text, out double vlCarta))
                {
                    MessageBox.Show("O valor da carta está errado!", "formulário inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!int.TryParse(txtMeses.Text, out int meses))
                {
                    MessageBox.Show("O valor de meses está errado!", "formulário inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!double.TryParse(txtTaxa.Text, out double Taxa))
                {
                    MessageBox.Show("A Taxa está errada!", "formulário inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true; 
            } 
        }
        private async void btCalcular_Click(object sender, EventArgs e)
        {
            if (!ValidadeForm)
                return;

            double vlCarta = double.Parse(txtVlCarta.Text);
            double taxa = double.Parse(txtTaxa.Text);
            int meses = int.Parse(txtMeses.Text);

            var result = await SoapService.CalculaTaxa(vlCarta, taxa, meses);
            txtResultado.Text = result;
        }
    }
}
