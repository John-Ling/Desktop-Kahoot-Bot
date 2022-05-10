using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO actually implement functinality
// Add getters and setters across entire program for private variables
// Things to implement 
// - Manual override (make all bots pick a specific option)
// - Remove individual bots
// - End all bots
// - Internal Bot scoreboard
// - Show bot placements
// - Show progress of game using webscraping to get the number of kahoot questions
// - Log top 5 bots and bottom 5 in points and accuracy
// - Add manual editing of each bot via context menu (context menu will open a tab)
// Manual Bot Editing:
//  - See name
//  - Disable (not answer)
//  - Kick (permanent)
//  - See points and accuracy
//  - Set manual override

namespace Kahoot_Bot
{
    public partial class ControlPanel : Form
    {
        private Bitmap fullLogo;
        private Host host;
        public ControlPanel(Host host)
        {
            InitializeComponent();
            this.host = host;
            if (fullLogo is not null)
            {
                fullLogo.Dispose();
            }
            logoFull.SizeMode = PictureBoxSizeMode.StretchImage;
            fullLogo = new Bitmap(@"C:\Users\John\Source\Repos\Kahoot-Bot\Kahoot Bot\logo_full.png");
            logoFull.Image = fullLogo;

            int questions = 10; // temporary value real value will be found via webscraping.
            progressBar.Minimum = 0;
            progressBar.Maximum = questions * 10;
            progressBar.Step = 1;
            
        }

        private void Intialise_List_Views()
        {
            throw new NotImplementedException();
        }
    }
}
