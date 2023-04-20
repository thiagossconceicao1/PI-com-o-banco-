
namespace ProjetoPI
{
    partial class frmCarregaDataGridParceiro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dgvParceiros = new System.Windows.Forms.DataGridView();
            this.btnCarregaDados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParceiros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(643, 359);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 55);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dgvParceiros
            // 
            this.dgvParceiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParceiros.Location = new System.Drawing.Point(12, 24);
            this.dgvParceiros.Name = "dgvParceiros";
            this.dgvParceiros.Size = new System.Drawing.Size(773, 317);
            this.dgvParceiros.TabIndex = 9;
            // 
            // btnCarregaDados
            // 
            this.btnCarregaDados.Location = new System.Drawing.Point(287, 359);
            this.btnCarregaDados.Name = "btnCarregaDados";
            this.btnCarregaDados.Size = new System.Drawing.Size(210, 55);
            this.btnCarregaDados.TabIndex = 8;
            this.btnCarregaDados.Text = "Carrega Dados";
            this.btnCarregaDados.UseVisualStyleBackColor = true;
            this.btnCarregaDados.Click += new System.EventHandler(this.btnCarregaDados_Click);
            // 
            // frmCarregaDataGridParceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dgvParceiros);
            this.Controls.Add(this.btnCarregaDados);
            this.Name = "frmCarregaDataGridParceiro";
            this.Text = "frmCarregaDataGridParceiro";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParceiros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dgvParceiros;
        private System.Windows.Forms.Button btnCarregaDados;
    }
}