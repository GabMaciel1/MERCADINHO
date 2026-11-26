namespace MERCADINHO
{
    partial class Form1
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelCarrinho = new System.Windows.Forms.Label();
            this.textUnd = new System.Windows.Forms.TextBox();
            this.labelQtd = new System.Windows.Forms.Label();
            this.textCod = new System.Windows.Forms.TextBox();
            this.labelCod = new System.Windows.Forms.Label();
            this.buttonEntrar = new System.Windows.Forms.Button();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textCliente = new System.Windows.Forms.TextBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.labelPreco = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxCarrinho = new System.Windows.Forms.ListBox();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            this.modeSwitch = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.labelCarrinho);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(274, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 59);
            this.panel2.TabIndex = 33;
            // 
            // labelCarrinho
            // 
            this.labelCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCarrinho.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCarrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCarrinho.Location = new System.Drawing.Point(0, 0);
            this.labelCarrinho.Name = "labelCarrinho";
            this.labelCarrinho.Size = new System.Drawing.Size(485, 57);
            this.labelCarrinho.TabIndex = 0;
            this.labelCarrinho.Text = "Carrinho";
            this.labelCarrinho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textUnd
            // 
            this.textUnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUnd.Enabled = false;
            this.textUnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUnd.Location = new System.Drawing.Point(274, 49);
            this.textUnd.Name = "textUnd";
            this.textUnd.Size = new System.Drawing.Size(486, 26);
            this.textUnd.TabIndex = 32;
            // 
            // labelQtd
            // 
            this.labelQtd.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQtd.Location = new System.Drawing.Point(7, 49);
            this.labelQtd.Name = "labelQtd";
            this.labelQtd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelQtd.Size = new System.Drawing.Size(262, 30);
            this.labelQtd.TabIndex = 31;
            this.labelQtd.Text = "QUANTIDADE DE UNIDADES";
            this.labelQtd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textCod
            // 
            this.textCod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCod.Enabled = false;
            this.textCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCod.Location = new System.Drawing.Point(274, 13);
            this.textCod.MaxLength = 13;
            this.textCod.Name = "textCod";
            this.textCod.Size = new System.Drawing.Size(486, 26);
            this.textCod.TabIndex = 30;
            this.textCod.TextChanged += new System.EventHandler(this.textCod_TextChanged);
            // 
            // labelCod
            // 
            this.labelCod.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCod.Location = new System.Drawing.Point(7, 13);
            this.labelCod.Name = "labelCod";
            this.labelCod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelCod.Size = new System.Drawing.Size(262, 30);
            this.labelCod.TabIndex = 29;
            this.labelCod.Text = "CÓDIGO DO PRODUTO";
            this.labelCod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEntrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonEntrar.FlatAppearance.BorderSize = 10;
            this.buttonEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEntrar.Location = new System.Drawing.Point(7, 150);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(262, 38);
            this.buttonEntrar.TabIndex = 28;
            this.buttonEntrar.Text = "ENTRAR";
            this.buttonEntrar.UseVisualStyleBackColor = true;
            this.buttonEntrar.Click += new System.EventHandler(this.Button3_Click);
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFinalizar.Enabled = false;
            this.buttonFinalizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonFinalizar.FlatAppearance.BorderSize = 10;
            this.buttonFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonFinalizar.Location = new System.Drawing.Point(7, 490);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonFinalizar.Size = new System.Drawing.Size(262, 41);
            this.buttonFinalizar.TabIndex = 27;
            this.buttonFinalizar.Text = "FINALIZAR COMPRA";
            this.buttonFinalizar.UseVisualStyleBackColor = true;
            this.buttonFinalizar.Click += new System.EventHandler(this.Button2_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.Enabled = false;
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonAdd.FlatAppearance.BorderSize = 10;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(7, 194);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(262, 38);
            this.buttonAdd.TabIndex = 26;
            this.buttonAdd.Text = "ADICIONAR ITEM";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textCliente
            // 
            this.textCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCliente.Location = new System.Drawing.Point(7, 122);
            this.textCliente.Name = "textCliente";
            this.textCliente.Size = new System.Drawing.Size(263, 24);
            this.textCliente.TabIndex = 25;
            // 
            // labelCliente
            // 
            this.labelCliente.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.Location = new System.Drawing.Point(7, 86);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelCliente.Size = new System.Drawing.Size(262, 30);
            this.labelCliente.TabIndex = 24;
            this.labelCliente.Text = "Cliente";
            this.labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPreco
            // 
            this.labelPreco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPreco.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelPreco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPreco.Font = new System.Drawing.Font("Cascadia Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreco.Location = new System.Drawing.Point(377, 490);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(383, 41);
            this.labelPreco.TabIndex = 23;
            this.labelPreco.Text = "R$   0,00";
            this.labelPreco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(274, 490);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(97, 41);
            this.labelTotal.TabIndex = 22;
            this.labelTotal.Text = "Total ";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.listBoxCarrinho);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(274, 150);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(487, 334);
            this.panel1.TabIndex = 21;
            // 
            // listBoxCarrinho
            // 
            this.listBoxCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCarrinho.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listBoxCarrinho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxCarrinho.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCarrinho.FormattingEnabled = true;
            this.listBoxCarrinho.ItemHeight = 21;
            this.listBoxCarrinho.Location = new System.Drawing.Point(0, 0);
            this.listBoxCarrinho.Name = "listBoxCarrinho";
            this.listBoxCarrinho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxCarrinho.Size = new System.Drawing.Size(486, 315);
            this.listBoxCarrinho.TabIndex = 0;
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.buttonReiniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReiniciar.Enabled = false;
            this.buttonReiniciar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonReiniciar.FlatAppearance.BorderSize = 10;
            this.buttonReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReiniciar.Location = new System.Drawing.Point(7, 238);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(262, 38);
            this.buttonReiniciar.TabIndex = 34;
            this.buttonReiniciar.Text = "REINICAR CAIXA";
            this.buttonReiniciar.UseVisualStyleBackColor = true;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // modeSwitch
            // 
            this.modeSwitch.AutoSize = true;
            this.modeSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeSwitch.Location = new System.Drawing.Point(75, 282);
            this.modeSwitch.Name = "modeSwitch";
            this.modeSwitch.Size = new System.Drawing.Size(129, 24);
            this.modeSwitch.TabIndex = 35;
            this.modeSwitch.Text = "Modo scanner";
            this.modeSwitch.UseVisualStyleBackColor = true;
            this.modeSwitch.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 542);
            this.Controls.Add(this.modeSwitch);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textUnd);
            this.Controls.Add(this.labelQtd);
            this.Controls.Add(this.textCod);
            this.Controls.Add(this.labelCod);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textCliente);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Mercadinho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCarrinho;
        private System.Windows.Forms.TextBox textUnd;
        private System.Windows.Forms.Label labelQtd;
        private System.Windows.Forms.TextBox textCod;
        private System.Windows.Forms.Label labelCod;
        private System.Windows.Forms.Button buttonEntrar;
        private System.Windows.Forms.Button buttonFinalizar;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textCliente;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxCarrinho;
        private System.Windows.Forms.Button buttonReiniciar;
        private System.Windows.Forms.CheckBox modeSwitch;
    }
}

