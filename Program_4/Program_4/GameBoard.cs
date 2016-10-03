using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Chris;

namespace Program_4
{

    public partial class GameBoard : Form
    {
        const int NUM_PLAYERS = 3;
        int score_scaler = 3;
        int player1 = (int)setPlayer.player1;
        int player2 = (int)setPlayer.player2;
        int player3 = (int)setPlayer.player3;

        List<Player>Players = new List<Player>(2);
        List<PictureBox> Tilelist;

        public GameBoard()
        {
            InitializeComponent();

            for(int i = 0; i < NUM_PLAYERS; i++)
                Players.Add( new Player() );
            /************************************************************************
             *   Creates an array to hold Player objects.
             *   This allows seamless switching of turns.
             *   Players may be indexed by either name 
             *   or index (i.e. "player1" or '0').  
             ************************************************************************/
        }

        public void storeTiles()
        {
            
        }

        public void randpic()
        {
            Random rand = new Random();
            Image picbuffer;

            for (int i = 1; i < 19; i++)
            {
                picbuffer = ReadImages.fileimgs[rand.Next(0, ReadImages.fileimgs.Count)];
                ((PictureBox)this.Controls["pictureBox" + i.ToString()]).Image = picbuffer;
            }

            Random randhighlight = new Random();
            ((PictureBox)this.Controls["pictureBox" + randhighlight.Next(1,17).ToString()]).BackColor = System.Drawing.Color.LightGoldenrodYellow;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            /****************************** DEBUG **********************************/
            Players[player1].score += score_scaler;     //      OR listPlayer[0].setScore(3);
            scoreP1.Text = "" + Players[0].score;
            /***********************************************************************/

        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

        }


        //Method containing help button functionality
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PRESS YOUR LUCK\n \nHow to Play Press Your Luck\n\nPLAYER ANSWERS THE TRIVIA QUESTION" +
                            "S TO EARN SPINS.\n\nTHE SPINS WILL BE USED ON THE GAME BOARD FOR A CHANCE TO WIN M" +
                            "ONEY OR GET MORE SPINS.");
        }


        private void SpinButton_Click(object sender, EventArgs e)
        {
            ReadImages.SnatchImages();
            
            randpic();
        }
    }
}
