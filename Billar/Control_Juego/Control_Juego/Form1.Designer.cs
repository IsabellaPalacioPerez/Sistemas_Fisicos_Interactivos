namespace Control_Juego
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
            this.hSB_fuerza = new System.Windows.Forms.HScrollBar();
            this.txt_valorfuerza = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hSB_fuerza
            // 
            this.hSB_fuerza.Location = new System.Drawing.Point(30, 26);
            this.hSB_fuerza.Margin = new System.Windows.Forms.Padding(1);
            this.hSB_fuerza.Maximum = 1000;
            this.hSB_fuerza.Name = "hSB_fuerza";
            this.hSB_fuerza.Size = new System.Drawing.Size(354, 43);
            this.hSB_fuerza.TabIndex = 0;
            this.hSB_fuerza.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hSB_fuerza_Scroll);
            // 
            // txt_valorfuerza
            // 
            this.txt_valorfuerza.Location = new System.Drawing.Point(388, 36);
            this.txt_valorfuerza.Name = "txt_valorfuerza";
            this.txt_valorfuerza.Size = new System.Drawing.Size(100, 20);
            this.txt_valorfuerza.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_valorfuerza);
            this.Controls.Add(this.hSB_fuerza);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hSB_fuerza;
        private System.Windows.Forms.TextBox txt_valorfuerza;
    }
}

