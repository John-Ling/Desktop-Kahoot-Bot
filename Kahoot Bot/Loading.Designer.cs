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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.botsJoinedList = new System.Windows.Forms.ListView();
            this.botName = new System.Windows.Forms.ColumnHeader();
            this.joinStatus = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(5, 369);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(527, 22);
            this.loadingBar.TabIndex = 0;
            // 
            // indicatorLbl
            // 
            this.indicatorLbl.AutoSize = true;
            this.indicatorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.indicatorLbl.Location = new System.Drawing.Point(12, 312);
            this.indicatorLbl.Name = "indicatorLbl";
            this.indicatorLbl.Size = new System.Drawing.Size(0, 24);
            this.indicatorLbl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(5, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loading...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(591, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lobby";
            // 
            // botsJoinedList
            // 
            this.botsJoinedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.botName,
            this.joinStatus});
            this.botsJoinedList.HideSelection = false;
            this.botsJoinedList.Location = new System.Drawing.Point(538, 52);
            this.botsJoinedList.Name = "botsJoinedList";
            this.botsJoinedList.Size = new System.Drawing.Size(158, 365);
            this.botsJoinedList.TabIndex = 4;
            this.botsJoinedList.UseCompatibleStateImageBehavior = false;
            this.botsJoinedList.View = System.Windows.Forms.View.Details;
            // 
            // botName
            // 
            this.botName.Text = "  Bot Name";
            this.botName.Width = 78;
            // 
            // joinStatus
            // 
            this.joinStatus.Text = " Status";
            this.joinStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.joinStatus.Width = 77;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 422);
            this.Controls.Add(this.botsJoinedList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView botsJoinedList;
        private System.Windows.Forms.ColumnHeader botName;
        private System.Windows.Forms.ColumnHeader joinStatus;
    }
}