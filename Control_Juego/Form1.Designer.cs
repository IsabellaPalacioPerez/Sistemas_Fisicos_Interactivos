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
            this.hsb_Fuerza = new System.Windows.Forms.HScrollBar();
            this.txt_valorFuerza = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hsb_Fuerza
            // 
            this.hsb_Fuerza.Location = new System.Drawing.Point(48, 43);
            this.hsb_Fuerza.Maximum = 1000;
            this.hsb_Fuerza.Name = "hsb_Fuerza";
            this.hsb_Fuerza.Size = new System.Drawing.Size(437, 38);
            this.hsb_Fuerza.TabIndex = 0;
            this.hsb_Fuerza.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsb_fuerza_Scroll);
            // 
            // txt_valorFuerza
            // 
            this.txt_valorFuerza.Location = new System.Drawing.Point(517, 43);
            this.txt_valorFuerza.Name = "txt_valorFuerza";
            this.txt_valorFuerza.Size = new System.Drawing.Size(100, 22);
            this.txt_valorFuerza.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_valorFuerza);
            this.Controls.Add(this.hsb_Fuerza);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hsb_Fuerza;
        private System.Windows.Forms.TextBox txt_valorFuerza;
    }
}

