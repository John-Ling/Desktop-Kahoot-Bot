﻿namespace Kahoot_Bot
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
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.indicatorLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.forceNone = new System.Windows.Forms.RadioButton();
            this.listView2 = new System.Windows.Forms.ListView();
            this.kickName = new System.Windows.Forms.ColumnHeader();
            this.kickStatus = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.forceSquare = new System.Windows.Forms.RadioButton();
            this.forceCircle = new System.Windows.Forms.RadioButton();
            this.forceDiamond = new System.Windows.Forms.RadioButton();
            this.forceTriangle = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
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
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.indicatorLabel);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.forceNone);
            this.tabPage1.Controls.Add(this.listView2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.forceSquare);
            this.tabPage1.Controls.Add(this.forceCircle);
            this.tabPage1.Controls.Add(this.forceDiamond);
            this.tabPage1.Controls.Add(this.forceTriangle);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listView1);
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
            this.questionLabel.Location = new System.Drawing.Point(628, 404);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(55, 17);
            this.questionLabel.TabIndex = 43;
            this.questionLabel.Text = "Loading";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 26);
            this.button2.TabIndex = 42;
            this.button2.Text = "Disable All Bots";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(20, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "Global Actions";
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
            this.progressBar.Size = new System.Drawing.Size(616, 22);
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
            // forceNone
            // 
            this.forceNone.AutoSize = true;
            this.forceNone.Location = new System.Drawing.Point(187, 366);
            this.forceNone.Name = "forceNone";
            this.forceNone.Size = new System.Drawing.Size(103, 19);
            this.forceNone.TabIndex = 35;
            this.forceNone.TabStop = true;
            this.forceNone.Text = "None (Default)";
            this.forceNone.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.kickName,
            this.kickStatus});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(363, 27);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(119, 368);
            this.listView2.TabIndex = 27;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // kickName
            // 
            this.kickName.Text = "Name";
            this.kickName.Width = 55;
            // 
            // kickStatus
            // 
            this.kickStatus.Text = "Status";
            this.kickStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(404, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Bots";
            // 
            // forceSquare
            // 
            this.forceSquare.AutoSize = true;
            this.forceSquare.Location = new System.Drawing.Point(187, 341);
            this.forceSquare.Name = "forceSquare";
            this.forceSquare.Size = new System.Drawing.Size(61, 19);
            this.forceSquare.TabIndex = 25;
            this.forceSquare.TabStop = true;
            this.forceSquare.Text = "Square";
            this.forceSquare.UseVisualStyleBackColor = true;
            // 
            // forceCircle
            // 
            this.forceCircle.AutoSize = true;
            this.forceCircle.Location = new System.Drawing.Point(187, 316);
            this.forceCircle.Name = "forceCircle";
            this.forceCircle.Size = new System.Drawing.Size(55, 19);
            this.forceCircle.TabIndex = 24;
            this.forceCircle.TabStop = true;
            this.forceCircle.Text = "Circle";
            this.forceCircle.UseVisualStyleBackColor = true;
            // 
            // forceDiamond
            // 
            this.forceDiamond.AutoSize = true;
            this.forceDiamond.Location = new System.Drawing.Point(187, 292);
            this.forceDiamond.Name = "forceDiamond";
            this.forceDiamond.Size = new System.Drawing.Size(74, 19);
            this.forceDiamond.TabIndex = 23;
            this.forceDiamond.TabStop = true;
            this.forceDiamond.Text = "Diamond";
            this.forceDiamond.UseVisualStyleBackColor = true;
            // 
            // forceTriangle
            // 
            this.forceTriangle.AutoSize = true;
            this.forceTriangle.Location = new System.Drawing.Point(187, 267);
            this.forceTriangle.Name = "forceTriangle";
            this.forceTriangle.Size = new System.Drawing.Size(66, 19);
            this.forceTriangle.TabIndex = 22;
            this.forceTriangle.TabStop = true;
            this.forceTriangle.Text = "Triangle";
            this.forceTriangle.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(170, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Force Answer Globally";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(21, 298);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 26);
            this.button1.TabIndex = 20;
            this.button1.Text = "Kick All Bots";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(550, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Leaderboard";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.botPlacement,
            this.botName,
            this.botScore});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(498, 27);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(194, 368);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // 
            // botScore
            // 
            this.botScore.Text = "Score";
            this.botScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
        private System.Windows.Forms.RadioButton forceNone;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader kickName;
        private System.Windows.Forms.ColumnHeader kickStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton forceSquare;
        private System.Windows.Forms.RadioButton forceCircle;
        private System.Windows.Forms.RadioButton forceDiamond;
        private System.Windows.Forms.RadioButton forceTriangle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader botPlacement;
        private System.Windows.Forms.ColumnHeader botName;
        private System.Windows.Forms.ColumnHeader botScore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label indicatorLabel;
        private System.Windows.Forms.ContextMenuStrip botEditMenu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.PictureBox logoFull;
    }
}