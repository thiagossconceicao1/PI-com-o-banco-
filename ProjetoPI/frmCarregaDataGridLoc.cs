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
    public partial class frmCarregaDataGridLoc : Form
    {
        public frmCarregaDataGridLoc()
        {
            InitializeComponent();
        }

        private void btnCarregaDados_Click(object sender, EventArgs e)
        {
            dgvFuncionarios.DataSource = null;

            MySqlDataAdapter da = new MySqlDataAdapter("select endereco as 'endereço', numero as 'Numero', cep as 'CEP', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade', siglaEst as 'Estado' from tbLocalizacao;", Conexao.obterConexao());

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvFuncionarios.DataSource = dt;

            Conexao.fecharConexao();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmPesquisaLoc abrir = new frmPesquisaLoc();
            abrir.Show();
            this.Hide();
        }
    }
}
