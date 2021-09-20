using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        public string operador = "";

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lstOperaciones.Items.Clear();
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
            if (txtNumero2.Visible == false || cmbOperador.Visible == false)
            {
                txtNumero2.Visible = true;
                cmbOperador.Visible = true;
            }



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
           if( MessageBox.Show("Esta seguro que desea salir de la calculadora?","Salir?",MessageBoxButtons.OKCancel)== DialogResult.Cancel)
            {       
               e.Cancel = true;
            }
          
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
          
          Operando n1 = new Operando(this.txtNumero1.Text);
          Operando n2 = new Operando(this.txtNumero2.Text);
          string operador = cmbOperador.Text;

            
          double resultado = 0;
         
          resultado = Calculadora.Operar(n1, n2, operador);
         // this.lblResultado.Text = resultado.ToString();

          string cadenaOperacion = this.txtNumero1.Text + cmbOperador.Text + this.txtNumero2.Text + "=" + resultado;

          this.lstOperaciones.Items.Add(cadenaOperacion.ToString());

        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = cmbOperador.SelectedItem.ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.cmbOperador.Visible = false;
            txtNumero2.Visible = false;

            string numeroStr = "";

            numeroStr = txtNumero1.Text;
            Operando convertir = new Operando(numeroStr);
            lblResultado.Text = convertir.DecimalBinario(numeroStr);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.cmbOperador.Visible = false;
            txtNumero2.Visible = false;

            string numeroStr = "";

            numeroStr = txtNumero1.Text;
            Operando convertir = new Operando(numeroStr);
            lblResultado.Text = convertir.BinarioDecimal(numeroStr);
        }
    }
}
