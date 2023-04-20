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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
            desabilitaCampos();
        }
        //contrutor
        public frmUsuario(string valor)
        {
            InitializeComponent();
            desabilitaCampos();
            txtNome.Text = valor;
            habilitarCampos();
            pesquisarCampo(valor);
            ativarUpdate();
        }
        public void habilitarCampos()
        {
            txtCodigo.Enabled = true;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            mskTelefone.Enabled = true;
            btnNovo.Enabled = true;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = true;
            btnVoltar.Enabled = true;
            txtNome.Focus();
        }
        public void desabilitaCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtSenha.Enabled = false;
            mskTelefone.Enabled = false;
            btnNovo.Enabled = true;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = false;
            btnVoltar.Enabled = true;
        }
        public void limparCampos()
        {
            txtCodigo.Text = "";
            txtEmail.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";
            mskTelefone.Text = "";
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
            comm.CommandText = "select * from tbUsuario where nome = '" + nome + "';";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCodigo.Text = Convert.ToString(DR.GetInt32(0));
            txtNome.Text = DR.GetString(1);
            txtEmail.Text = DR.GetString(2);
            mskTelefone.Text = DR.GetString(4);
            Conexao.fecharConexao();
        }
        //public void excluirUsuario(int codUsu)
        //{
        //    MySqlCommand comm = new MySqlCommand();
        //    comm.CommandText = "delete from tbUsuario where codUsu = " + codUsu + ";";
        //    comm.CommandType = CommandType.Text;
        //    comm.Connection = Conexao.obterConexao();
        //    comm.Parameters.Clear();
        //    comm.Parameters.Add("@codProd", MySqlDbType.Int32).Value = txtCodigo.Text;

        //    DialogResult vresp = MessageBox.Show("Deseja Realizar a Exclusão?", "Mensagem do Sistema", MessageBoxButtons.YesNo,
        //       MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

        //    if (vresp == DialogResult.Yes)
        //    {
        //        int res = comm.ExecuteNonQuery();
        //        MessageBox.Show("Registro excluído com sucesso." + res);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Não foi excluido.");
        //    }
        //    Conexao.fecharConexao();
        //}
        //public void alterarUsuario(int codUsu)
        //{
        //    MySqlCommand comm = new MySqlCommand();
        //    comm.CommandText = "update tbUsuario set nome = @nome, email = @email, telefone = @telefone where codUsu = " + codUsu + ";";
        //    comm.CommandType = CommandType.Text;
        //    comm.Connection = Conexao.obterConexao();

        //    comm.Parameters.Clear();

        //    comm.Parameters.Add("@cargo", MySqlDbType.VarChar, 100).Value = txtNome.Text;
        //    comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
        //    comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            


        //    int res = comm.ExecuteNonQuery();
        //    MessageBox.Show("Registro alterado com sucesso." + res);
        //    Conexao.fecharConexao();
        //}

    //CRUD
    private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = true;
            btnVoltar.Enabled = true;
        }

    private void btnCadastrar_Click(object sender, EventArgs e)
        {
            desabilitaCampos();
        }

    private void btnAlterar_Click(object sender, EventArgs e)
        {
            desabilitaCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            desabilitaCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisaUsu abrir = new frmPesquisaUsu();
            abrir.Show();
            this.Hide();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }
    }
}