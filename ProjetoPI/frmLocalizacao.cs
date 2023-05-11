using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoPI
{
    public partial class frmLocalizacao : Form
    {
        public frmLocalizacao()
        {
            InitializeComponent();
            desabilitaCampos();
            carregarCombBox();
            ativarUpdate();
        }
        public frmLocalizacao(string valor)
        {
            InitializeComponent();
            desabilitaCampos();
            carregarCombBox();
            ativarUpdate();
            pesquisarCampo(valor);
        }

        public void pesquisarCampo(string cargo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = $"select * from tblocalizacao where endereco like '%{cargo}%';";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtEndereco.Text = DR.GetString(0);
            txtNum.Text = DR.GetString(1);
            mskCEP.Text = DR.GetString(2);
            txtComplemento.Text = DR.GetString(3);
            txtBairro.Text = DR.GetString(4);
            txtCidade.Text = DR.GetString(5);
            cbbEstado.Text = DR.GetString(6);

            Conexao.fecharConexao();
        }


        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            frmMenuPrincipal voltar = new frmMenuPrincipal();
            voltar.Show();
            this.Hide();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = true;
            btnVoltar.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            excluirUsuario(Convert.ToInt32(mskCEP.Text));
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisaLoc abrir = new frmPesquisaLoc();
            abrir.Show();
            this.Hide();
        }




        public void habilitarCampos()
        {
            txtEndereco.Enabled = true;
            mskCEP.Enabled = true;
            cbbEstado.Enabled = true;
            txtCidade.Enabled = true;
            txtBairro.Enabled = true;
            txtNum.Enabled = true;
            txtComplemento.Enabled = true;
            btnNovo.Enabled = true;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = true;
            btnVoltar.Enabled = true;
        }
        public void desabilitaCampos()
        {
            mskCEP.Enabled = false;
            cbbEstado.Enabled = false;
            txtCidade.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtNum.Enabled = false;
            txtComplemento.Enabled = false;
            btnNovo.Enabled = true;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = false;
            btnVoltar.Enabled = true;
        }
        public void carregarCombBox()
        {
            cbbEstado.Items.Add("");
            cbbEstado.Items.Add("SP");
            cbbEstado.Items.Add("RJ");
            cbbEstado.Items.Add("BH");
            cbbEstado.Items.Add("BA");
            cbbEstado.Items.Add("RN");
        }
        public void ativarUpdate()
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = false;
            btnCadastrar.Enabled = false;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        private void frmLocalizacao_Load(object sender, EventArgs e)
        {

        }
        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscaCEP(mskCEP.Text);
                txtNum.Focus();
            }
        }
        public void buscaCEP(string numCEP)
        {
            WSCorreios.AtendeClienteClient ws = new WSCorreios.AtendeClienteClient();

            try
            {
                WSCorreios.enderecoERP end = ws.consultaCEP(numCEP);

                txtEndereco.Text = end.end;
                txtBairro.Text = end.bairro;
                txtCidade.Text = end.cidade;
                cbbEstado.Text = end.uf;
            }
            catch (Exception)
            {
                MessageBox.Show("Insira CEP válido!!!",
                    "Mensagem do Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                mskCEP.Clear();
                mskCEP.Focus();

            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alterarLocalizacao(Convert.ToInt32(mskCEP.Text));
        }
        public void alterarLocalizacao(int codCep)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbLocalizacao set endereco = @endereco , numero = @numero, cep = @cep, complemento = @complemento, bairro = @bairro, cidade = @cidade, siglaEst = @siglaEst where codFunc = " + codCep + ";";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();


            comm.Parameters.Add("@siglaEst", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 10).Value = mskCEP.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 14).Value = txtNum.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 50).Value = txtComplemento.Text;


            int res = comm.ExecuteNonQuery();
            MessageBox.Show("Registro alterado com sucesso." + res);
            Conexao.fecharConexao();
        }
        public void excluirUsuario(int codCep)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tblocalizacao where cep = " + codCep + ";";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();
            comm.Parameters.Clear();
            comm.Parameters.Add("@codProd", MySqlDbType.Int32).Value = mskCEP.Text;

            DialogResult vresp = MessageBox.Show("Deseja Realizar a Exclusão?", "Mensagem do Sistema", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (vresp == DialogResult.Yes)
            {
                int res = comm.ExecuteNonQuery();
                MessageBox.Show("Registro excluído com sucesso." + res);
            }
            else
            {
                MessageBox.Show("Não foi excluido.");
            }
            Conexao.fecharConexao();
        }
        public void limparCampos()
        {
            mskCEP.Text = "";
            cbbEstado.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtNum.Clear();
            txtComplemento.Clear();
        }
    }
}
