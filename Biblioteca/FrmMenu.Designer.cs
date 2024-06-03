namespace Biblioteca
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadastrarLivro = new System.Windows.Forms.Button();
            this.btnCadUsuario = new System.Windows.Forms.Button();
            this.btnReservarLivro = new System.Windows.Forms.Button();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadastrarLivro
            // 
            this.btnCadastrarLivro.Location = new System.Drawing.Point(88, 54);
            this.btnCadastrarLivro.Name = "btnCadastrarLivro";
            this.btnCadastrarLivro.Size = new System.Drawing.Size(220, 126);
            this.btnCadastrarLivro.TabIndex = 0;
            this.btnCadastrarLivro.Text = "Cadastrar Livro";
            this.btnCadastrarLivro.UseVisualStyleBackColor = true;
            // 
            // btnCadUsuario
            // 
            this.btnCadUsuario.Location = new System.Drawing.Point(455, 54);
            this.btnCadUsuario.Name = "btnCadUsuario";
            this.btnCadUsuario.Size = new System.Drawing.Size(220, 126);
            this.btnCadUsuario.TabIndex = 1;
            this.btnCadUsuario.Text = "Cadastrar Usuário";
            this.btnCadUsuario.UseVisualStyleBackColor = true;
            // 
            // btnReservarLivro
            // 
            this.btnReservarLivro.Location = new System.Drawing.Point(88, 256);
            this.btnReservarLivro.Name = "btnReservarLivro";
            this.btnReservarLivro.Size = new System.Drawing.Size(220, 126);
            this.btnReservarLivro.TabIndex = 2;
            this.btnReservarLivro.Text = "Reservar Livro";
            this.btnReservarLivro.UseVisualStyleBackColor = true;
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Location = new System.Drawing.Point(455, 256);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(220, 126);
            this.btnCancelarReserva.TabIndex = 3;
            this.btnCancelarReserva.Text = "Cancelar Reserva";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.btnReservarLivro);
            this.Controls.Add(this.btnCadUsuario);
            this.Controls.Add(this.btnCadastrarLivro);
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrarLivro;
        private System.Windows.Forms.Button btnCadUsuario;
        private System.Windows.Forms.Button btnReservarLivro;
        private System.Windows.Forms.Button btnCancelarReserva;
    }
}

