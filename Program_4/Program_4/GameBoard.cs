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
using System.IO;
using GetFile;

namespace Program_4
{
    public partial class GameBoard : Form
    {
        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {

            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

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
            /************************************************************************/
                             //   this code works                                 
                             Players[0].score += 3;
                            textBox2.Text = "$" + Players[0].score + ".00";             
            /*************************************************************************/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String searchFolder = @"C:\Users\kumin\Pictures";
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            var files = GetFilesFrom(searchFolder, filters, false);

            MessageBox.Show(files[0], "Title", MessageBoxButtons.YesNo);
        }
    }
}
