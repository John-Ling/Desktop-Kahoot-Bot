using System;
using System.Windows.Forms;

namespace Kahoot_Bot
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            invalidJoinLbl.Visible = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string lobbyID;
            string botName;
            uint botNumber = 0;
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
                botNumber = uint.Parse(botNumberTextbox.Text);
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
