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
    public partial class frmPesquisaLoc : Form
    {
        public frmPesquisaLoc()
        {
            InitializeComponent();
        }

        //CRUD
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmParceiros abrir = new frmParceiros();
            abrir.Show();
            this.Hide();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDescricao.Enabled = false;
            rdbNome.Checked = false;
            rdbCodigo.Checked = false;
            txtDescricao.Clear();
            ltbItensPesquisados.Items.Clear();
        }
        private void btnPesquisaFunc_Click(object sender, EventArgs e)
        {
            frmCarregaDataGridLoc abrir = new frmCarregaDataGridLoc();
            abrir.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            if (rdbCodigo.Checked)
            {
                ltbItensPesquisados.Items.Clear();
                //ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaCEPLoc(txtDescricao.Text);

            }
            else if (rdbNome.Checked)
            {
                //ltbItensPesquisados.Items.Clear();
                //ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaNome(txtDescricao.Text);
            }
        }

        public void pesquisaCEPLoc(string codigocep)
        {
            bool validaNome = acessaBancoCod(codigocep);
            if (validaNome)
            {


                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tblocalizacao where cep like '%" + codigocep + "%'; ";;

                comm.CommandType = CommandType.Text;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;

                DR = comm.ExecuteReader();

                ltbItensPesquisados.Items.Clear();
                Console.WriteLine(DR.HasRows);
                while (DR.Read())
                {

                    ltbItensPesquisados.Items.Add(DR.GetString(0));
                }
            }

            else
            {
                acessaBancoCod(txtDescricao.Text);
                MessageBox.Show($"O endereço não existe no Banco!!!\n{codigocep}",
                    "Aviso do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            Conexao.fecharConexao();

        }

        public bool acessaBancoCod(string codLoc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tblocalizacao where cep = '" + codLoc + "';";
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
                comm.CommandText = "select * from tblocalizacao where endereco like '%" + nome + "%';";
                comm.CommandType = CommandType.Text;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;

                DR = comm.ExecuteReader();

                ltbItensPesquisados.Items.Clear();

                while (DR.Read())
                {
                    ltbItensPesquisados.Items.Add(DR.GetString(0));
                }
            }
            else
            {
                acessaBanco(txtDescricao.Text);
                MessageBox.Show("O endereço não existe no Banco!!!",
                    "Aviso do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            Conexao.fecharConexao();
        }
        public bool acessaBanco(string nomeLoc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tblocalizacao where endereco like '%" + nomeLoc + "%';";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            bool resposta = DR.HasRows;

            Conexao.fecharConexao();

            return resposta;
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }
        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }

        private void ltbItensPesquisados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = ltbItensPesquisados.SelectedItem.ToString();
            //MessageBox.Show("Resultado: " + valor);
            frmLocalizacao abrir = new frmLocalizacao(valor);
            abrir.Show();
            this.Hide();
        }
    }
}
