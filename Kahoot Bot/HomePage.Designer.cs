namespace Kahoot_Bot
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.label2 = new System.Windows.Forms.Label();
            this.lobbyIDTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.botNameTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botNumberTextbox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.indicatorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.invalidJoinLbl = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lobby ID";
            // 
            // lobbyIDTextbox
            // 
            this.lobbyIDTextbox.Location = new System.Drawing.Point(298, 171);
            this.lobbyIDTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lobbyIDTextbox.MaxLength = 7;
            this.lobbyIDTextbox.Name = "lobbyIDTextbox";
            this.lobbyIDTextbox.Size = new System.Drawing.Size(157, 27);
            this.lobbyIDTextbox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bot Name";
            // 
            // botNameTextbox
            // 
            this.botNameTextbox.Location = new System.Drawing.Point(298, 239);
            this.botNameTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botNameTextbox.MaxLength = 13;
            this.botNameTextbox.Name = "botNameTextbox";
            this.botNameTextbox.Size = new System.Drawing.Size(157, 27);
            this.botNameTextbox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Number of Bots";
            // 
            // botNumberTextbox
            // 
            this.botNumberTextbox.Location = new System.Drawing.Point(298, 303);
            this.botNumberTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botNumberTextbox.Name = "botNumberTextbox";
            this.botNumberTextbox.Size = new System.Drawing.Size(157, 27);
            this.botNumberTextbox.TabIndex = 6;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(247, 380);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(267, 55);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Send Bots";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // indicatorLabel
            // 
            this.indicatorLabel.AutoSize = true;
            this.indicatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.indicatorLabel.Location = new System.Drawing.Point(332, 536);
            this.indicatorLabel.Name = "indicatorLabel";
            this.indicatorLabel.Size = new System.Drawing.Size(0, 22);
            this.indicatorLabel.TabIndex = 12;
            this.indicatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(300, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Kahoot Bot";
            // 
            // invalidJoinLbl
            // 
            this.invalidJoinLbl.AutoSize = true;
            this.invalidJoinLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.invalidJoinLbl.Location = new System.Drawing.Point(203, 459);
            this.invalidJoinLbl.Name = "invalidJoinLbl";
            this.invalidJoinLbl.Size = new System.Drawing.Size(12, 18);
            this.invalidJoinLbl.TabIndex = 16;
            this.invalidJoinLbl.Text = " ";
            this.invalidJoinLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoBox
            // 
            this.logoBox.Location = new System.Drawing.Point(203, 79);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(73, 73);
            this.logoBox.TabIndex = 17;
            this.logoBox.TabStop = false;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 519);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.invalidJoinLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.indicatorLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.botNumberTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botNameTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lobbyIDTextbox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kahoot Bot";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lobbyIDTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox botNameTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox botNumberTextbox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label indicatorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label invalidJoinLbl;
        private System.Windows.Forms.PictureBox logoBox;
    }
}

