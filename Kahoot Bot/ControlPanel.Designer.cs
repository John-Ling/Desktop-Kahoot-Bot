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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.listView1 = new System.Windows.Forms.ListView();
            this.botPlacement = new System.Windows.Forms.ColumnHeader();
            this.botName = new System.Windows.Forms.ColumnHeader();
            this.botScore = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.forceTriangle = new System.Windows.Forms.RadioButton();
            this.forceDiamond = new System.Windows.Forms.RadioButton();
            this.forceCircle = new System.Windows.Forms.RadioButton();
            this.forceSquare = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.kickName = new System.Windows.Forms.ColumnHeader();
            this.kickStatus = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.forceNone = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(510, 31);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(194, 409);
            this.listView1.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(564, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Leaderboard";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(14, 420);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kick All Bots";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(132, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Force Answer (All bots)";
            // 
            // forceTriangle
            // 
            this.forceTriangle.AutoSize = true;
            this.forceTriangle.Location = new System.Drawing.Point(141, 33);
            this.forceTriangle.Name = "forceTriangle";
            this.forceTriangle.Size = new System.Drawing.Size(66, 19);
            this.forceTriangle.TabIndex = 4;
            this.forceTriangle.TabStop = true;
            this.forceTriangle.Text = "Triangle";
            this.forceTriangle.UseVisualStyleBackColor = true;
            // 
            // forceDiamond
            // 
            this.forceDiamond.AutoSize = true;
            this.forceDiamond.Location = new System.Drawing.Point(141, 58);
            this.forceDiamond.Name = "forceDiamond";
            this.forceDiamond.Size = new System.Drawing.Size(74, 19);
            this.forceDiamond.TabIndex = 5;
            this.forceDiamond.TabStop = true;
            this.forceDiamond.Text = "Diamond";
            this.forceDiamond.UseVisualStyleBackColor = true;
            // 
            // forceCircle
            // 
            this.forceCircle.AutoSize = true;
            this.forceCircle.Location = new System.Drawing.Point(141, 82);
            this.forceCircle.Name = "forceCircle";
            this.forceCircle.Size = new System.Drawing.Size(55, 19);
            this.forceCircle.TabIndex = 6;
            this.forceCircle.TabStop = true;
            this.forceCircle.Text = "Circle";
            this.forceCircle.UseVisualStyleBackColor = true;
            // 
            // forceSquare
            // 
            this.forceSquare.AutoSize = true;
            this.forceSquare.Location = new System.Drawing.Point(141, 107);
            this.forceSquare.Name = "forceSquare";
            this.forceSquare.Size = new System.Drawing.Size(61, 19);
            this.forceSquare.TabIndex = 7;
            this.forceSquare.TabStop = true;
            this.forceSquare.Text = "Square";
            this.forceSquare.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kick Bots";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.kickName,
            this.kickStatus});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(7, 32);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(119, 383);
            this.listView2.TabIndex = 9;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(390, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Statistics";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(371, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total Correct:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(371, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total Wrong:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(460, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(460, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(371, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Overall Accuracy:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(480, 421);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "0%";
            // 
            // forceNone
            // 
            this.forceNone.AutoSize = true;
            this.forceNone.Location = new System.Drawing.Point(141, 132);
            this.forceNone.Name = "forceNone";
            this.forceNone.Size = new System.Drawing.Size(103, 19);
            this.forceNone.TabIndex = 17;
            this.forceNone.TabStop = true;
            this.forceNone.Text = "None (Default)";
            this.forceNone.UseVisualStyleBackColor = true;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 451);
            this.Controls.Add(this.forceNone);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.forceSquare);
            this.Controls.Add(this.forceCircle);
            this.Controls.Add(this.forceDiamond);
            this.Controls.Add(this.forceTriangle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ControlPanel";
            this.Text = "Control Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton forceTriangle;
        private System.Windows.Forms.RadioButton forceDiamond;
        private System.Windows.Forms.ColumnHeader botPlacement;
        private System.Windows.Forms.ColumnHeader botName;
        private System.Windows.Forms.ColumnHeader botScore;
        private System.Windows.Forms.RadioButton forceCircle;
        private System.Windows.Forms.RadioButton forceSquare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader kickName;
        private System.Windows.Forms.ColumnHeader kickStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton forceNone;
    }
}