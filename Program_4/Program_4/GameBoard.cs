using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Player;

namespace Program_4
{

    public partial class GameBoard : Form
    {
        const int NUM_PLAYERS = 3;

        int player1 = (int)setPlayer.player1;
        int player2 = (int)setPlayer.player2;

        List<NewPlayer> listPlayer = new List<NewPlayer>(2);
        public GameBoard()
        {
            InitializeComponent();

            for(int i = 0; i < NUM_PLAYERS; i++)
            listPlayer.Add( new NewPlayer() );
            /************************************************************************
             *   Creates an array to hold Player objects.
             *   This allows seamless switching of turns.
             *   Players may be indexed by either name 
             *   or index (i.e. "player1" or '0').  
             ************************************************************************/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /****************************** DEBUG **********************************/                               
            listPlayer[player1].setScore(3);     //      OR listPlayer[0].setScore(3);
            textBox2.Text = listPlayer[0].getScore();
            /***********************************************************************/

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
