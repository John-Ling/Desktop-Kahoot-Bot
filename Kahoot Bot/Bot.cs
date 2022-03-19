// Custom data type for a single player bot
// Add additional attributes as needed 

namespace Kahoot_Bot
{
    internal class Bot
    {
        public string name;
        public bool joinSuccessful;

        public Bot(string botName, bool wasJoinSuccessful)
        {
            name = botName;
            joinSuccessful = wasJoinSuccessful;
        }
    }
}
