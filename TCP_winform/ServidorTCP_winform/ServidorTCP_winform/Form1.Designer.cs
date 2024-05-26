namespace ServidorTCP_winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_saludo = new System.Windows.Forms.Button();
            this.tmr_loop = new System.Windows.Forms.Timer(this.components);
            this.txt_recibido = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_saludo
            // 
            this.btn_saludo.Location = new System.Drawing.Point(119, 41);
            this.btn_saludo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_saludo.Name = "btn_saludo";
            this.btn_saludo.Size = new System.Drawing.Size(224, 31);
            this.btn_saludo.TabIndex = 0;
            this.btn_saludo.Text = "Presioname!!!";
            this.btn_saludo.UseVisualStyleBackColor = true;
            this.btn_saludo.Click += new System.EventHandler(this.arrancar_servidor);
            this.btn_saludo.MouseEnter += new System.EventHandler(this.Entromouseaboton);
            this.btn_saludo.MouseLeave += new System.EventHandler(this.Saliomouseboton);
            // 
            // tmr_loop
            // 
            this.tmr_loop.Interval = 50;
            this.tmr_loop.Tick += new System.EventHandler(this.update);
            // 
            // txt_recibido
            // 
            this.txt_recibido.Location = new System.Drawing.Point(27, 80);
            this.txt_recibido.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_recibido.Multiline = true;
            this.txt_recibido.Name = "txt_recibido";
            this.txt_recibido.Size = new System.Drawing.Size(379, 388);
            this.txt_recibido.TabIndex = 1;
            this.txt_recibido.TextChanged += new System.EventHandler(this.txt_recibido_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(477, 539);
            this.Controls.Add(this.txt_recibido);
            this.Controls.Add(this.btn_saludo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "VEntana principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.final);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_saludo;
        private System.Windows.Forms.Timer tmr_loop;
        private TextBox txt_recibido;
    }
}