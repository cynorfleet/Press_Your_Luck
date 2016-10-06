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

        static public List<Image> fileimgs = new List<Image>();
        // contains a List of images captured from the clients computer

        List<Player>Players = new List<Player>(2);
        List<Tile> Tilelist = new List<Tile>();

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
             ************************************************************************/;
            
            storeTiles();
            randTile();
        }

        public void storeTiles()
        {
            foreach (var picpath in ReadImages.SnatchImages())
            //  crawl directory to snatch array of image paths
            //  use each path to create an Image and store it in Tilelist
            {
                Tilelist.Add(new Tile(picpath));
            }
        }

        public void randTile()
        {
            Random rand = new Random();
            Random randhighlight = new Random();

            foreach(PictureBox tile in this.TileBox.Controls)
            {
                var randomTile = Tilelist[rand.Next(0, Tilelist.Count)];
                tile.Image = randomTile.pic;

                try
                {
                    if (randomTile.whammy)
                        tile.Tag = "whammy";
                    else
                        tile.Tag = randomTile.value;
                }
                catch
                {
                        MessageBox.Show("UH OHHHHHHHHH\nCould NOT load Tile from:\n\n" + randomTile.fullpath);
                        // In case of invalid file throw exception
                }
                finally
                {
                //    MessageBox.Show("Tile Value: " + tile.Tag);
                }
            }
        }

        public void SelectTile()
        {
            Random randhighlight = new Random();
            var randTile = this.TileBox.Controls;
            var pickedtile = randTile[randhighlight.Next(0, this.TileBox.Controls.Count)];
                pickedtile.BackColor = System.Drawing.Color.DarkSlateBlue;
           //MessageBox.Show("Selected: " + pickedtile.Name);
        }

        public void ClearTile()
        {
            foreach (PictureBox tile in this.TileBox.Controls)
                tile.BackColor = System.Drawing.Color.Empty;
           // MessageBox.Show("All Tiles Cleared");
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


        private void SpinButton_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = 250;
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ClearTile();
            randTile();
            SelectTile();
        }
    }
}
