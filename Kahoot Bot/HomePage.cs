using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
// TODO change way logo is loaded after figuring out how software distrubution on VS-2022 works
// Logo currently is loaded via a hardcoded path
// change this so it will work on someone else's computer (that person being a customer not developer)
// Potentially add settings menu to adjust join delay (see host.cs) to account for different network speeds

namespace Kahoot_Bot
{
    public partial class HomePage : Form
    {
        private Bitmap logo;
        public HomePage()
        {
            InitializeComponent();
            invalidJoinLbl.Visible = false;
            if (logo is not null)
            {
                logo.Dispose();
            }
            logoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logo = new Bitmap(@"C:\Users\John\Source\Repos\Kahoot-Bot\Kahoot Bot\logo.png");
            logoBox.ClientSize = new Size(50, 50);
            logoBox.Image = logo; 
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string lobbyID;
            string botName;
            int botNumber = 0;
            bool textBoxesContainData = false;

            lobbyID = lobbyIDTextbox.Text;
            if (!String.IsNullOrEmpty(lobbyID))
            {
                textBoxesContainData = true;
            }
            else { textBoxesContainData = false; }

            botName = botNameTextbox.Text;

            if (!String.IsNullOrEmpty(botName))
            {
                textBoxesContainData = true;
            }
            else { textBoxesContainData = false; }

            if (!String.IsNullOrEmpty(botNumberTextbox.Text))
            {
                textBoxesContainData = true;
                botNumber = int.Parse(botNumberTextbox.Text);
            }
            else { textBoxesContainData = false; }

            if (textBoxesContainData)
            {
                Clear_Text_Boxes();
                Hide();
                var loadingPage = new Loading(lobbyID, botName, botNumber);
                loadingPage.Show();
            }
            else
            {
                invalidJoinLbl.Text = "Please ensure all fields are filled";
                invalidJoinLbl.Visible = true;
                lobbyIDTextbox.Focus();
            }
        }
        private void Clear_Text_Boxes()
        {
            lobbyIDTextbox.Text = null;
            botNameTextbox.Text = null;
            botNumberTextbox.Text = null;
        }
    }
}
