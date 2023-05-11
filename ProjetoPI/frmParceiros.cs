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
    public partial class frmParceiros : Form
    {
        public frmParceiros()
        {
            InitializeComponent();
            desabilitaCampos();
            carregarCombBox();
        }
        public frmParceiros(string valor)
        {
            InitializeComponent();
            desabilitaCampos();
            carregarCombBox();
            txtNome.Text = valor;
            habilitarCampos();
            pesquisarCampo(valor);
            ativarUpdate();
        }
        public void desabilitaCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            mskTelefone.Enabled = false;
            mskCNPJ.Enabled = false;
            mskCEP.Enabled = false;
            cbbEstado.Enabled = false;
            txtCidade.Enabled = false;
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
        public void limparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            mskTelefone.Text = "";
            mskCNPJ.Text = "";
            mskCEP.Text = "";
            cbbEstado.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtNum.Clear();
            txtComplemento.Clear();
        }
        public void excluirdoBanco()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            mskTelefone.Enabled = false;
            mskCNPJ.Enabled = false;
            mskCEP.Enabled = false;
            cbbEstado.Enabled = false;
            txtCidade.Enabled = false;
            txtBairro.Enabled = false;
            txtNum.Enabled = false;
            txtComplemento.Enabled = false;
        }
        public void ativarUpdate()
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnCadastrar.Enabled = false;
            btnNovo.Enabled = false;
            btnLimpar.Enabled = false;
        }
        public void pesquisarCampo(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbParceiro where nome = '" + nome + "';";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCodigo.Text = Convert.ToString(DR.GetInt32(0));
            txtNome.Text = DR.GetString(1);
            txtEmail.Text = DR.GetString(2);
            txtEndereco.Text = DR.GetString(3);
            mskTelefone.Text = DR.GetString(4);
            mskCNPJ.Text = DR.GetString(5);
            mskCEP.Text = DR.GetString(6);
            cbbEstado.Text = DR.GetString(7);
            txtCidade.Text = DR.GetString(8);
            txtBairro.Text = DR.GetString(9);
            txtNum.Text = DR.GetString(10);
            txtComplemento.Text = DR.GetString(11);

            Conexao.fecharConexao();
        }
        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            mskTelefone.Enabled = true;
            mskCNPJ.Enabled = true;
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
            txtNome.Focus();
        }
        public void verificarCampo()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Favor inserir valores");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Favor inserir valores");
            }

            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")
              || txtEndereco.Text.Equals("") || mskTelefone.Text.Equals("(  )      -")
                || mskCNPJ.Text.Equals("   .   .   -") || mskCEP.Text.Equals("     -")
                || txtCidade.Text.Equals("") || txtBairro.Text.Equals("") ||
                txtNum.Text.Equals("") || cbbEstado.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores!!!",
                    "Mensagem do Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                txtNome.Focus();
            }

        }
        public void cadastrarParceiro()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbParceiro(nome, email, telefone, cnpj, cep, siglaEst, endereco, cidade, bairro, numero, complemento )" +
    "values(@nome, @email, @telefone, @cnpj, @cep, @siglaEst, @endereco, @cidade, @bairro, @numero, @complemento); ";

            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@telefone", MySqlDbType.VarChar, 20).Value = mskTelefone.Text;
            comm.Parameters.Add("@cnpj", MySqlDbType.VarChar, 14).Value = mskCNPJ.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 10).Value = mskCEP.Text;
            comm.Parameters.Add("@siglaEst", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 14).Value = txtNum.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 50).Value = txtComplemento.Text;
            
            
            
            

            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            int i = comm.ExecuteNonQuery();

            MessageBox.Show("Parceiro cadastrado com sucesso!!!" + i);
            limparCampos();
            desabilitaCampos();

            Conexao.fecharConexao();
        }
        public void alterarParceiro(int codPar)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbParceiro set nome = @nome, email = @email, telefone = @telefone,endereco = @endereco, cnpj = @cnpj, siglaEst = @siglaEst, cep = @cep, cidade = @cidade, bairro = @bairro, numero = @numero, complemento = @complemento where codPar = " + codPar + ";";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@telefone", MySqlDbType.VarChar, 20).Value = mskTelefone.Text;
            comm.Parameters.Add("@cnpj", MySqlDbType.VarChar, 14).Value = mskCNPJ.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 10).Value = mskCEP.Text;
            comm.Parameters.Add("@siglaEst", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 14).Value = txtNum.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 50).Value = txtComplemento.Text;


            int res = comm.ExecuteNonQuery();
            MessageBox.Show("Registro alterado com sucesso." + res);
            Conexao.fecharConexao();
        }
        public void excluirParceiro(int codPar)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbParceiro where codPar = " + codPar + ";";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();
            comm.Parameters.Clear();
            comm.Parameters.Add("@codProd", MySqlDbType.Int32).Value = txtCodigo.Text;

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

        //CRUD
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = true;
            btnVoltar.Enabled = true;
        }
        //Arrumar o pesquisar funcionario.
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            fFrmPesquisaParceiro abrir = new fFrmPesquisaParceiro();
            abrir.Show();
            this.Hide();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            verificarCampo();
            cadastrarParceiro();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            excluirParceiro(Convert.ToInt32(txtCodigo.Text));
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alterarParceiro(Convert.ToInt32(txtCodigo.Text));
        }

        //CEP
        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscaCEP(mskCEP.Text);
                txtNum.Focus();
            }
        }

        private void frmParceiros_Load(object sender, EventArgs e)
        {

        }


        //Validador de CPF adicionar



    }
}

