namespace Cliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_conectar = new System.Windows.Forms.Button();
            this.txt_enviar = new System.Windows.Forms.TextBox();
            this.btn_enviar = new System.Windows.Forms.Button();
            this.txt_recibido = new System.Windows.Forms.TextBox();
            this.tmr_loop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_conectar
            // 
            this.btn_conectar.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conectar.Location = new System.Drawing.Point(453, 89);
            this.btn_conectar.Name = "btn_conectar";
            this.btn_conectar.Size = new System.Drawing.Size(268, 55);
            this.btn_conectar.TabIndex = 0;
            this.btn_conectar.Text = "Conectar al servidor";
            this.btn_conectar.UseVisualStyleBackColor = true;
            this.btn_conectar.Click += new System.EventHandler(this.btn_conectar_Click);
            // 
            // txt_enviar
            // 
            this.txt_enviar.Location = new System.Drawing.Point(433, 208);
            this.txt_enviar.Name = "txt_enviar";
            this.txt_enviar.Size = new System.Drawing.Size(211, 22);
            this.txt_enviar.TabIndex = 1;
            // 
            // btn_enviar
            // 
            this.btn_enviar.Font = new System.Drawing.Font("Lucida Sans Unicode", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enviar.Location = new System.Drawing.Point(670, 206);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(81, 24);
            this.btn_enviar.TabIndex = 2;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseVisualStyleBackColor = true;
            this.btn_enviar.Click += new System.EventHandler(this.btn_enviar_click);
            // 
            // txt_recibido
            // 
            this.txt_recibido.Location = new System.Drawing.Point(25, 12);
            this.txt_recibido.Multiline = true;
            this.txt_recibido.Name = "txt_recibido";
            this.txt_recibido.Size = new System.Drawing.Size(288, 426);
            this.txt_recibido.TabIndex = 3;
            // 
            // tmr_loop
            // 
            this.tmr_loop.Interval = 50;
            this.tmr_loop.Tick += new System.EventHandler(this.update);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_recibido);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.txt_enviar);
            this.Controls.Add(this.btn_conectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Final);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_conectar;
        private System.Windows.Forms.TextBox txt_enviar;
        private System.Windows.Forms.Button btn_enviar;
        private System.Windows.Forms.TextBox txt_recibido;
        private System.Windows.Forms.Timer tmr_loop;
    }
}

