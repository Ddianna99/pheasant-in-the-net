using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fazan
{
    public class Manager
    {
        List<string> WordHistory = new List<string>();
        Network GameNetwork;
        Label GameLabel;
        Label MySCoreLabel;
        Label OtherScoreLabel;

        bool isServer;
        int MyScore = 0;
        int OtherSCore = 0;
        bool isNewRound;

        static string FAZAN = "FAZAN";


        public Manager(bool isServer)
        {
            if (isServer)
                GameNetwork = new NetworkServer();
            else
                GameNetwork = new NetworkClient();
            this.isServer = isServer;
            isNewRound = this.isServer;
        }

        public void Initialize(Label label, Label myScore, Label otherScore)
        {
            GameLabel = label;
            MySCoreLabel = myScore;
            OtherScoreLabel = otherScore;


            GameLabel.Text = "";

            if (!isServer)
                WaitForOponent();
        }
        void WaitForOponent()
        {
            string recieved = GameNetwork.Recieve();
            if (recieved == "<BAD>")
            {
                isNewRound = true;
                OtherSCore++;
                OtherScoreLabel.Text = FAZAN.Substring(0, OtherSCore);
                if (OtherSCore == FAZAN.Length)
                {
                    MessageBox.Show("YOU WON");
                }
                else
                {
                    GameLabel.Text = "CHOSE THE NEXT WORD";
                }
            }
            else if (CheckWord(recieved))
            {
                WordHistory.Add(recieved.ToLower());
                GameLabel.Text = recieved;
            }
        }
        void BadSend()
        {
            MyScore++;
            MySCoreLabel.Text = FAZAN.Substring(0, MyScore);
            GameNetwork.Send("<BAD>");
            isNewRound = true;

            if (MyScore == FAZAN.Length)
            {
                MessageBox.Show("YOU LOST");
            }
            else
            {
                WaitForOponent();
            }
        }
        public void Turn(string word)
        {
            if (CheckWord(word))
            {
                WordHistory.Add(word.ToLower());
                GameNetwork.Send(word);
                isNewRound = false;
                WaitForOponent();
            }
            else
            {
                BadSend();
            }
        }

        public void Stuck()
        {
            BadSend();
        }

        protected bool CheckWord(string currentWord)
        {
            if (WordHistory.Contains(currentWord.ToLower()))
                return false;
            if (isNewRound)
                return true;
            if (WordHistory.Count > 0)
                return WordHistory.Last().ToLower().EndsWith(currentWord.Substring(0, 2).ToLower());
            else
                return true;
        }
    }
}
