using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chris
{
    class Tile
    {
        public Image pic { get; set; }
        public decimal value { get; set; }
        public bool whammy { get; set; }
        public String fullpath { get; set; }

        public Tile(String path)
        {
            whammy = false;
            // default the whammy to false until whammy is found

            pic = ReadImages.ResizeImage(Image.FromFile(path), 77, 60);
            // Resize the pic in high def and store it in Tile

            fullpath = path;
            // Store full path for error logging
            if (path.Contains("whammy"))
            {
                //  If the path contains the word"whammy" ... ITS A WHAMMY
                whammy = true;
            }

            else
            {
                var substringindex = ReadImages.ImageDirectory.Length;
                // Find the index of the where the value begins in the path

                var pathbuffer = path.Substring(substringindex + 1, 4);
                // Chop off leading path to image name and account for extra '\'
                // grab next 4 places
                //MessageBox.Show("Cropped:\t" + path + "\n\nTo Substring Value: " + pathbuffer);

                try
                {
                    value = System.Convert.ToDecimal(pathbuffer);
                    //  Try to store the value as an int
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could NOT convert VALUE");
                    //  If something goes wrong throw an error
                }
            }
        
        }

    }
}
