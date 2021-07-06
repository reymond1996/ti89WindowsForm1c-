using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ti89
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            Banco cn = new Banco();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
        }
        public void Limpar()
        {
            txtId.Text = String.Empty;
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente us = new Cliente(txtNome.Text,txtEmail.Text);
            us.Inserir();
            MessageBox.Show(us.mensagem,"Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
            txtId.Text = Convert.ToString(us.id);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cliente us = new Cliente();
            //teste verificação
            if (txtId.Text == string.Empty) 
            {
                MessageBox.Show("Informar o ID de busca", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Focus();
                return;
            }
            else
            {
                us.Consultar(Convert.ToInt32(txtId.Text));
            }
                //verificar o valor das variaveis achou
                if(us.achou == true)
            {
                txtNome.Text = us.Nome;
                txtEmail.Text = us.Email;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;

            }
                else
            {
                MessageBox.Show(us.mensagem, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                Limpar();
            }
        }
    }
}
