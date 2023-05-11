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
    public partial class fFrmPesquisaParceiro : Form
    {
        public fFrmPesquisaParceiro()
        {
            InitializeComponent();
            txtDescricao.Enabled = false;
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;
        }

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbCodigo.Checked)
            {
                ltbItensPesquisados2.Items.Clear();
                //ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaCodigo(txtDescricao.Text);

            }
            else if (rdbNome.Checked)
            {
                //ltbItensPesquisados.Items.Clear();
                //ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaNome(txtDescricao.Text);
            }
        }





        //


        public bool acessaBancoCod(string codPar)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbParceiro where codPar = '" + codPar + "';";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            bool resposta = DR.HasRows;

            Conexao.fecharConexao();

            return resposta;
        }


        public bool acessaBanco(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbParceiro where nome like '%" + nome + "%';";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            bool resposta = DR.HasRows;

            Conexao.fecharConexao();

            return resposta;
        }

        public void pesquisaNome(string nome)
        {
            bool validaNome = acessaBanco(nome);
            if (validaNome)
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbParceiro where nome like '%" + nome + "%';";
                comm.CommandType = CommandType.Text;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;

                DR = comm.ExecuteReader();

                ltbItensPesquisados2.Items.Clear();

                while (DR.Read())
                {
                    ltbItensPesquisados2.Items.Add(DR.GetString(1));
                }
            }
            else
            {
                acessaBanco(txtDescricao.Text);
                MessageBox.Show("O usuario não existe no Banco!!!",
                    "Aviso do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            Conexao.fecharConexao();
        }

        public void pesquisaCodigo(string codigo)
        {
            bool validaCodigo = acessaBancoCod(codigo);
            if (validaCodigo)
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbParceiro where codPar like '%" + codigo + "%';";
                comm.CommandType = CommandType.Text;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;

                DR = comm.ExecuteReader();

                ltbItensPesquisados2.Items.Clear();

                while (DR.Read())
                {
                    ltbItensPesquisados2.Items.Add(DR.GetString(1));
                }
            }
            else
            {
                acessaBanco(txtDescricao.Text);
                MessageBox.Show("O codigo não existe no Banco!!!",
                    "Aviso do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

            Conexao.fecharConexao();


        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDescricao.Enabled = false;
            rdbNome.Checked = false;
            rdbCodigo.Checked = false;
            txtDescricao.Clear();
            ltbItensPesquisados2.Items.Clear();
        }

        private void ltbItensPesquisados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = ltbItensPesquisados2.SelectedItem.ToString();
            //MessageBox.Show("Resultado: " + valor);
            frmParceiros abrir = new frmParceiros(valor);
            abrir.Show();
            this.Hide();
        }

        private void btnPesquisaParceiro_Click(object sender, EventArgs e)
        {
            frmCarregaDataGridParceiro abrir = new frmCarregaDataGridParceiro();
            abrir.Show();
            this.Hide();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmParceiros abrir = new frmParceiros();
            abrir.Show();
            this.Hide();
        }
    }
}
