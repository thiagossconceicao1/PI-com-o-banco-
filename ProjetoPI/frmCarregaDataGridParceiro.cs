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
    public partial class frmCarregaDataGridParceiro : Form
    {
        public frmCarregaDataGridParceiro()
        {
            InitializeComponent();
        }

        private void btnCarregaDados_Click(object sender, EventArgs e)
        {
            dgvParceiros.DataSource = null;

            MySqlDataAdapter da = new MySqlDataAdapter("select codPar as 'Código', nome as 'Nome', email as 'E-mail', telefone as 'Telefone', cnpj as 'CNPJ', endereco as 'Endereço', numero as 'Numero', cep as 'CEP', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade',siglaEst as 'Estado' from tbParceiro;", Conexao.obterConexao());

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvParceiros.DataSource = dt;

            Conexao.fecharConexao();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            fFrmPesquisaParceiro abrir = new fFrmPesquisaParceiro();
            abrir.Show();
            this.Hide();
        }
    }
}
