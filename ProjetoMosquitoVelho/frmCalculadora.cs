using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMosquitoVelho
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }
        //Criando método limpar campos
        public void limparCampos()
        {
            txtValor1.Clear();
            txtValor2.Clear();
            lblResultado2.Text = "";
            rdbSomar.Checked = false;
            rdbSubtrair.Checked = false;
            rdbMultiplicar.Checked = false;
            rdbDividir.Checked = false;
            txtValor1.Focus();


        }

        private void lblValor2_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)

        {
            double num1, num2, resp = 0;

            try
            {
                num1 = Convert.ToDouble(txtValor1.Text);
                num2 = Convert.ToDouble(txtValor2.Text);

                //Instanciar o objeto/classe
                Operacoes op = new Operacoes();

                if (rdbSomar.Checked)
                {
                    resp = op.somar(num1, num2);
                }
                if (rdbSubtrair.Checked)
                {
                    resp = op.subtrair(num1, num2);
                }
                if (rdbMultiplicar.Checked)
                {
                    resp = op.multiplicar(num1, num2);
                }
                if (rdbDividir.Checked)
                {
                    if (num2 == 0)
                    {
                        //Exemplo de configuração de janela de erro com 3 botões: yes , No e Cancel
                        //MessageBox.Show("Impossível divisão por zero!","SistemaABC",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Error,MessageBoxDefaultButton.Button3);
                        MessageBox.Show("Impossível divisão por zero!", "SistemaABC", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        //executar o método limparCampos()
                        limparCampos();
                    }
                    else
                    {
                        resp = op.dividir(num1, num2);
                    }



                    //Método tradicional básico de cídigo de somar
                    //resp = num1 + num2;
                    //lblResultado2.Text = resp.ToString();
                }
                lblResultado2.Text = resp.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Insira somente números");
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}