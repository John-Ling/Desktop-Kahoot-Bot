namespace Kahoot_Bot
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.indicatorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(12, 402);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(776, 23);
            this.loadingBar.TabIndex = 0;
            // 
            // indicatorLbl
            // 
            this.indicatorLbl.AutoSize = true;
            this.indicatorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indicatorLbl.Location = new System.Drawing.Point(12, 346);
            this.indicatorLbl.Name = "indicatorLbl";
            this.indicatorLbl.Size = new System.Drawing.Size(0, 29);
            this.indicatorLbl.TabIndex = 1;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.indicatorLbl);
            this.Controls.Add(this.loadingBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.Label indicatorLbl;
    }
}