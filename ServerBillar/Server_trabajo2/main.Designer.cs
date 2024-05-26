
namespace Server_trabajo2
{
    partial class main
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
            this.put = new System.Windows.Forms.PictureBox();
            this.force = new System.Windows.Forms.TextBox();
            this.angle = new System.Windows.Forms.TextBox();
            this.cmd_shot = new System.Windows.Forms.Button();
            this.mover = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_restart = new System.Windows.Forms.Button();
            this.lbl_win = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cb_restart = new System.Windows.Forms.CheckBox();
            this.cb_shot = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.put)).BeginInit();
            this.SuspendLayout();
            // 
            // put
            // 
            this.put.BackColor = System.Drawing.Color.PaleGreen;
            this.put.Location = new System.Drawing.Point(14, 16);
            this.put.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.put.Name = "put";
            this.put.Size = new System.Drawing.Size(1143, 800);
            this.put.TabIndex = 0;
            this.put.TabStop = false;
            // 
            // force
            // 
            this.force.Location = new System.Drawing.Point(1266, 69);
            this.force.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.force.Name = "force";
            this.force.Size = new System.Drawing.Size(203, 27);
            this.force.TabIndex = 1;
            this.force.TextChanged += new System.EventHandler(this.force_TextChanged);
            // 
            // angle
            // 
            this.angle.Location = new System.Drawing.Point(1266, 199);
            this.angle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.angle.Name = "angle";
            this.angle.Size = new System.Drawing.Size(203, 27);
            this.angle.TabIndex = 2;
            // 
            // cmd_shot
            // 
            this.cmd_shot.Location = new System.Drawing.Point(1384, 237);
            this.cmd_shot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmd_shot.Name = "cmd_shot";
            this.cmd_shot.Size = new System.Drawing.Size(86, 31);
            this.cmd_shot.TabIndex = 3;
            this.cmd_shot.Text = "Shot";
            this.cmd_shot.UseVisualStyleBackColor = true;
            this.cmd_shot.Click += new System.EventHandler(this.shot);
            // 
            // mover
            // 
            this.mover.Interval = 10;
            this.mover.Tick += new System.EventHandler(this.moveball);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1266, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Force";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1266, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Angle";
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(1384, 343);
            this.btn_restart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(86, 31);
            this.btn_restart.TabIndex = 6;
            this.btn_restart.Text = "restart";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.cmd_restart);
            // 
            // lbl_win
            // 
            this.lbl_win.AutoSize = true;
            this.lbl_win.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_win.Location = new System.Drawing.Point(1266, 744);
            this.lbl_win.Name = "lbl_win";
            this.lbl_win.Size = new System.Drawing.Size(0, 67);
            this.lbl_win.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1266, 103);
            this.progressBar1.Maximum = 5000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(203, 29);
            this.progressBar1.TabIndex = 8;
            // 
            // cb_restart
            // 
            this.cb_restart.AutoSize = true;
            this.cb_restart.Location = new System.Drawing.Point(1228, 402);
            this.cb_restart.Name = "cb_restart";
            this.cb_restart.Size = new System.Drawing.Size(73, 24);
            this.cb_restart.TabIndex = 9;
            this.cb_restart.Text = "restart";
            this.cb_restart.UseVisualStyleBackColor = true;
            // 
            // cb_shot
            // 
            this.cb_shot.AutoSize = true;
            this.cb_shot.Location = new System.Drawing.Point(1226, 443);
            this.cb_shot.Name = "cb_shot";
            this.cb_shot.Size = new System.Drawing.Size(59, 24);
            this.cb_shot.TabIndex = 10;
            this.cb_shot.Text = "shot";
            this.cb_shot.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 837);
            this.Controls.Add(this.cb_shot);
            this.Controls.Add(this.cb_restart);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_win);
            this.Controls.Add(this.btn_restart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmd_shot);
            this.Controls.Add(this.angle);
            this.Controls.Add(this.force);
            this.Controls.Add(this.put);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "main";
            this.Text = "Golf";
            this.Load += new System.EventHandler(this.finish_load);
            ((System.ComponentModel.ISupportInitialize)(this.put)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox put;
        private System.Windows.Forms.TextBox force;
        private System.Windows.Forms.TextBox angle;
        private System.Windows.Forms.Button cmd_shot;
        private System.Windows.Forms.Timer mover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Label lbl_win;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox cb_restart;
        private System.Windows.Forms.CheckBox cb_shot;
    }
}

