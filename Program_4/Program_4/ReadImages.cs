using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chris
{
    class ReadImages
    {
       static public List<Image> fileimgs = new List<Image>();
        // contains a List of images captured from the clients computer

        static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
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
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

        static String FindDir()

        {
            string path = Directory.GetCurrentDirectory();

            path = __FindDirRecur(path);

            MessageBox.Show(path);
            return path;
        }

        static String __FindDirRecur(string currentpath)
        {
            string[] dirbuffer = Directory.GetDirectories(currentpath);

            if (currentpath.Contains("\\Images"))
            {
                return currentpath;
            }

                currentpath = "" + Directory.GetParent(currentpath);
                MessageBox.Show("NOT: \n" + currentpath);

                foreach (var folder in dirbuffer)
                {
                    if (folder.Contains("Images"))
                    {
                        currentpath = folder;
                        MessageBox.Show("Found: \n" + currentpath);
                        return currentpath;
                    }
                }

               currentpath = __FindDirRecur(currentpath);
               return currentpath;
        }

        public static void SnatchImages(String folderpath = null, String[] fltr = null, bool isRecursive = false)
        {
            folderpath = folderpath ?? FindDir();
            // if the folderpath was not passed in make it equal to the current directory by default

            String searchFolder = @"" + folderpath;
            // set the target searchFolder

            var filters = fltr ?? (new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" });
            // if the filter array was not passed in make it equal to the above by default

            MessageBox.Show("SnatchImages: \n" + searchFolder);
            // DEBUG

            var filepaths = GetFilesFrom(searchFolder, filters, isRecursive);
            // store the array of returned image-paths to filepaths

            var count = 0;
            foreach (var pic in filepaths)
            //  use each path to create an Image and store it in fileimgs List
            {
                count++;
                fileimgs.Add(Image.FromFile(filepaths[count - 1]));
            }
        }


    }
}
