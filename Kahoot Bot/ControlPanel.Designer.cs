namespace Kahoot_Bot
{
    partial class ControlPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.logoFull = new System.Windows.Forms.PictureBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.indicatorLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.leaderboard = new System.Windows.Forms.ListView();
            this.botPlacement = new System.Windows.Forms.ColumnHeader();
            this.botName = new System.Windows.Forms.ColumnHeader();
            this.botScore = new System.Windows.Forms.ColumnHeader();
            this.botEditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoFull)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-5, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(706, 459);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logoFull);
            this.tabPage1.Controls.Add(this.questionLabel);
            this.tabPage1.Controls.Add(this.indicatorLabel);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.leaderboard);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // logoFull
            // 
            this.logoFull.Location = new System.Drawing.Point(22, 27);
            this.logoFull.Name = "logoFull";
            this.logoFull.Size = new System.Drawing.Size(320, 104);
            this.logoFull.TabIndex = 44;
            this.logoFull.TabStop = false;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.questionLabel.Location = new System.Drawing.Point(130, 384);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(64, 17);
            this.questionLabel.TabIndex = 43;
            this.questionLabel.Text = "Loading...";
            // 
            // indicatorLabel
            // 
            this.indicatorLabel.AutoSize = true;
            this.indicatorLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.indicatorLabel.Location = new System.Drawing.Point(4, 384);
            this.indicatorLabel.Name = "indicatorLabel";
            this.indicatorLabel.Size = new System.Drawing.Size(118, 17);
            this.indicatorLabel.TabIndex = 40;
            this.indicatorLabel.Text = "Loading question...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 404);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(686, 22);
            this.progressBar.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 15);
            this.label11.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(519, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Leaderboard";
            // 
            // leaderboard
            // 
            this.leaderboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leaderboard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.botPlacement,
            this.botName,
            this.botScore});
            this.leaderboard.HideSelection = false;
            this.leaderboard.Location = new System.Drawing.Point(410, 27);
            this.leaderboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leaderboard.Name = "leaderboard";
            this.leaderboard.Size = new System.Drawing.Size(282, 374);
            this.leaderboard.TabIndex = 18;
            this.leaderboard.UseCompatibleStateImageBehavior = false;
            this.leaderboard.View = System.Windows.Forms.View.Details;
            // 
            // botPlacement
            // 
            this.botPlacement.Text = "Placement";
            this.botPlacement.Width = 70;
            // 
            // botName
            // 
            this.botName.Text = "Name";
            this.botName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botName.Width = 120;
            // 
            // botScore
            // 
            this.botScore.Text = "Score";
            this.botScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.botScore.Width = 70;
            // 
            // botEditMenu
            // 
            this.botEditMenu.Name = "botEditMenu";
            this.botEditMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 451);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Panel";
            this.Shown += new System.EventHandler(this.ControlPanel_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoFull)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView leaderboard;
        private System.Windows.Forms.ColumnHeader botPlacement;
        private System.Windows.Forms.ColumnHeader botName;
        private System.Windows.Forms.ColumnHeader botScore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label indicatorLabel;
        private System.Windows.Forms.ContextMenuStrip botEditMenu;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.PictureBox logoFull;
    }
}