namespace Servidor
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
            this.txt_recibido = new System.Windows.Forms.TextBox();
            this.tmr_loop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BtnSaludo
            // 
            this.btn_conectar.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conectar.Location = new System.Drawing.Point(289, 65);
            this.btn_conectar.Name = "BtnSaludo";
            this.btn_conectar.Size = new System.Drawing.Size(211, 35);
            this.btn_conectar.TabIndex = 0;
            this.btn_conectar.Text = "Iniciar servidor";
            this.btn_conectar.UseVisualStyleBackColor = true;
            this.btn_conectar.Click += new System.EventHandler(this.ArrancarServidor);
            this.btn_conectar.MouseEnter += new System.EventHandler(this.EntroMouse);
            this.btn_conectar.MouseLeave += new System.EventHandler(this.SalioMouse);
            // 
            // txt_recibido
            // 
            this.txt_recibido.Location = new System.Drawing.Point(221, 140);
            this.txt_recibido.Multiline = true;
            this.txt_recibido.Name = "txt_recibido";
            this.txt_recibido.Size = new System.Drawing.Size(333, 198);
            this.txt_recibido.TabIndex = 1;
            this.txt_recibido.TextChanged += new System.EventHandler(this.txt_recibido_TextChanged);
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
        private System.Windows.Forms.TextBox txt_recibido;
        private System.Windows.Forms.Timer tmr_loop;
    }
}

