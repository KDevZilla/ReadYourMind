namespace ReadYourMind
{
    partial class FormAbout
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
            this.btnClose = new System.Windows.Forms.Button();
            this.linkLabelOtherGames = new System.Windows.Forms.LinkLabel();
            this.linkLabelGithub = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(339, 159);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 41);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linkLabelOtherGames
            // 
            this.linkLabelOtherGames.AutoSize = true;
            this.linkLabelOtherGames.Location = new System.Drawing.Point(38, 70);
            this.linkLabelOtherGames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelOtherGames.Name = "linkLabelOtherGames";
            this.linkLabelOtherGames.Size = new System.Drawing.Size(190, 21);
            this.linkLabelOtherGames.TabIndex = 8;
            this.linkLabelOtherGames.TabStop = true;
            this.linkLabelOtherGames.Text = "https://kdevzilla.github.io/";
            // 
            // linkLabelGithub
            // 
            this.linkLabelGithub.AutoSize = true;
            this.linkLabelGithub.Location = new System.Drawing.Point(38, 30);
            this.linkLabelGithub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelGithub.Name = "linkLabelGithub";
            this.linkLabelGithub.Size = new System.Drawing.Size(309, 21);
            this.linkLabelGithub.TabIndex = 7;
            this.linkLabelGithub.TabStop = true;
            this.linkLabelGithub.Text = "https://github.com/kdevzilla/readyourmind";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 208);
            this.Controls.Add(this.linkLabelOtherGames);
            this.Controls.Add(this.linkLabelGithub);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.Text = "About";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel linkLabelOtherGames;
        private System.Windows.Forms.LinkLabel linkLabelGithub;
    }
}