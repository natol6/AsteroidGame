
namespace AsteroidGame
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblGameName = new System.Windows.Forms.Label();
            this.btnGame = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.textBoxNik = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblNik = new System.Windows.Forms.Label();
            this.lbldeveloper = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNik2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGameName
            // 
            resources.ApplyResources(this.lblGameName, "lblGameName");
            this.lblGameName.BackColor = System.Drawing.Color.Transparent;
            this.lblGameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblGameName.Name = "lblGameName";
            // 
            // btnGame
            // 
            this.btnGame.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnGame, "btnGame");
            this.btnGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGame.Name = "btnGame";
            this.btnGame.UseVisualStyleBackColor = false;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnRecords
            // 
            this.btnRecords.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnRecords, "btnRecords");
            this.btnRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.UseVisualStyleBackColor = false;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textBoxNik
            // 
            this.textBoxNik.BackColor = System.Drawing.Color.LightSlateGray;
            resources.ApplyResources(this.textBoxNik, "textBoxNik");
            this.textBoxNik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textBoxNik.Name = "textBoxNik";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.SlateGray;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblNik
            // 
            resources.ApplyResources(this.lblNik, "lblNik");
            this.lblNik.BackColor = System.Drawing.Color.Transparent;
            this.lblNik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblNik.Name = "lblNik";
            // 
            // lbldeveloper
            // 
            resources.ApplyResources(this.lbldeveloper, "lbldeveloper");
            this.lbldeveloper.BackColor = System.Drawing.Color.Transparent;
            this.lbldeveloper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbldeveloper.Name = "lbldeveloper";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Name = "label1";
            // 
            // lblNik2
            // 
            resources.ApplyResources(this.lblNik2, "lblNik2");
            this.lblNik2.BackColor = System.Drawing.Color.Transparent;
            this.lblNik2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblNik2.Name = "lblNik2";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNik2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbldeveloper);
            this.Controls.Add(this.lblNik);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBoxNik);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRecords);
            this.Controls.Add(this.btnGame);
            this.Controls.Add(this.lblGameName);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox textBoxNik;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblNik;
        private System.Windows.Forms.Label lbldeveloper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNik2;
    }
}