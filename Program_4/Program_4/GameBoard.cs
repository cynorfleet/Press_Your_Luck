﻿using System;
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
        List<Player> Players = new List<Player>(2);
        public GameBoard()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
           // ************************************************************************
           //                 //   this code works                                 *
           //                 Players[0].setScore(3);                               
           //                label5.Text = Players[0].getScore();                 
           // *************************************************************************/

        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

        }


        //Method containing help button functionality
        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
