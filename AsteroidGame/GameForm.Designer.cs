
namespace AsteroidGame
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.btnPause = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblRecName = new System.Windows.Forms.Label();
            this.lblRecValue = new System.Windows.Forms.Label();
            this.lblEnergyName = new System.Windows.Forms.Label();
            this.lblEnergyValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPause.Location = new System.Drawing.Point(701, 522);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(71, 27);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnContinue.Location = new System.Drawing.Point(598, 522);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(71, 27);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "Играть";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblRecName
            // 
            this.lblRecName.AutoSize = true;
            this.lblRecName.BackColor = System.Drawing.Color.Transparent;
            this.lblRecName.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblRecName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblRecName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecName.Location = new System.Drawing.Point(12, 533);
            this.lblRecName.Name = "lblRecName";
            this.lblRecName.Size = new System.Drawing.Size(168, 19);
            this.lblRecName.TabIndex = 7;
            this.lblRecName.Text = "Сбито астероидов:";
            // 
            // lblRecValue
            // 
            this.lblRecValue.AutoSize = true;
            this.lblRecValue.BackColor = System.Drawing.Color.Transparent;
            this.lblRecValue.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblRecValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblRecValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecValue.Location = new System.Drawing.Point(186, 533);
            this.lblRecValue.Name = "lblRecValue";
            this.lblRecValue.Size = new System.Drawing.Size(19, 19);
            this.lblRecValue.TabIndex = 8;
            this.lblRecValue.Text = "0";
            // 
            // lblEnergyName
            // 
            this.lblEnergyName.AutoSize = true;
            this.lblEnergyName.BackColor = System.Drawing.Color.Transparent;
            this.lblEnergyName.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblEnergyName.ForeColor = System.Drawing.Color.Lime;
            this.lblEnergyName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEnergyName.Location = new System.Drawing.Point(225, 533);
            this.lblEnergyName.Name = "lblEnergyName";
            this.lblEnergyName.Size = new System.Drawing.Size(268, 19);
            this.lblEnergyName.TabIndex = 9;
            this.lblEnergyName.Text = "Запас прочности корабля (%):";
            // 
            // lblEnergyValue
            // 
            this.lblEnergyValue.AutoSize = true;
            this.lblEnergyValue.BackColor = System.Drawing.Color.Transparent;
            this.lblEnergyValue.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblEnergyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblEnergyValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEnergyValue.Location = new System.Drawing.Point(499, 533);
            this.lblEnergyValue.Name = "lblEnergyValue";
            this.lblEnergyValue.Size = new System.Drawing.Size(39, 19);
            this.lblEnergyValue.TabIndex = 10;
            this.lblEnergyValue.Text = "100";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblEnergyValue);
            this.Controls.Add(this.lblEnergyName);
            this.Controls.Add(this.lblRecValue);
            this.Controls.Add(this.lblRecName);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnPause);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Игра \"Астероид\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblRecName;
        private System.Windows.Forms.Label lblRecValue;
        private System.Windows.Forms.Label lblEnergyName;
        private System.Windows.Forms.Label lblEnergyValue;
    }
}