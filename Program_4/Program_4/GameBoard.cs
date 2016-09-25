using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Playernsp;

namespace Program_4
{
    public partial class GameBoard : Form
    {
        public GameBoard()
        {
            InitializeComponent();

            List <Player> Players = new List<Player>(2);
            //  Create an array to hold Player objects
            //  This allows seamless switching of turns
            Players.Add(new Player());
            Players.Add(new Player());

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
