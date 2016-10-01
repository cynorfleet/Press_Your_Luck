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

namespace Program_4
{
    public partial class GameBoard : Form
    {

        List<Image> fileimgs = new List<Image>();

        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        /*-------------------------------------------- GetFilesFrom -----
        |  Function GetFilesFrom
        |
        |  Purpose: Identify the earthquake from the list of earthquake
        |			intensities (quake_list) that has the largest magnitude.
        |			It is assumed that the given list of quake intensities is
        |			an array-based list of unordered Richter Scale
        |			magnitudes; this function performs a simple sequential
        |			search through the array to locate the position of the
        |			largest magnitude (the largest value) in the list.
        |
        |  Parameters:
        |	searchFolder, filters, isRecursive (IN) -- the array of earthquake magnitudes.  This
        |					is just an array of real numbers; the first magnitude
        |					is assumed to be at index 0.
        |	searchFolder, filters, isRecursive (IN) -- the quantity of magnitudes in quake_list.
        |
        |  Returns:  	The index (position) of the largest earthquake
        |					magnitude in the quake_list array.
        *-------------------------------------------------------------------*/
        

        {
            List<Image> fileimg = new List<Image>();
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
            String searchFolder = @"C:\Users\kumin\GitHub\Press_Your_Luck\Program_4\Images";
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            var files = GetFilesFrom(searchFolder, filters, false);

            var count=0;
            foreach (var pic in files)
            {
                count++;
                fileimgs.Add(Image.FromFile(pic));
            }
        }

        public void randpic()
        {
            Random rand = new Random();
            pictureBox1.Image = fileimgs[rand.Next(0, fileimgs.Count)];
        }

        public void storebutton()
        {

        }
    }
}
