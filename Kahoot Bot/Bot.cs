using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kahoot_Bot
{
    internal class Bot
    {
        public int answersCorrect;
        public int answersWrong;
        private string name;
        public bool joinSuccessful;
        public int score;
        private string status;

        public Bot()
        {
            score = 0;
            answersCorrect = 0;
            answersWrong = 0;
            joinSuccessful = false;
            status = "Joining";
        }

        public string Status
        {
            get { return status; }
            set
            {
                string[] acceptable = { "Success", "Failed", "Kicked", "Deactivated", "Disabled", "Joining", "Timeout" };
                if (Array.IndexOf(acceptable, value) != -1)
                {
                    status = value;
                }
                else
                {
                    status = "Invalid";
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length <= 15 && value is not null)
                {
                    name = value;
                }
                else
                {
                    name = "Default_Name";
                }
            }
        }
    }
}
