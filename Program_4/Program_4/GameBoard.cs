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
using System.IO;

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

        /*************************************************/
        private string userAns = "";
        private string correctAns = "";
        private const int MAX_Questions = 100;
        private int num_questions;
        private string file = "luckfile.txt";   //source file name
        private static QuestionAnswer[] qA = new QuestionAnswer[MAX_Questions];
        private static int questionIndex = 0;
        private static int questionCount = 0; 
        private int numSpins = 0;  //number of spins
        private const int Ask_MAX_Questions = 3;

        

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
/**********************************************************************************************************/
            submitbutton.Enabled = false; 
            answerBox.ReadOnly = true;
            num_questions = readQuestions(file);
            randQuestions();
        }
        
/********************************************************************************************************/
        private void randQuestions()
        {
            Random rand = new Random();
            int rand_index;
            QuestionAnswer temp;
            for (int i =0; i <num_questions; i++)
            {
                rand_index = rand.Next() % num_questions;
                temp = qA[i];
                qA[rand_index] = temp;
            }
        }

        /********************************************************************************************************/



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



        private void label3_Click(object sender, EventArgs e)
        {

        }
       

        private void qtextbox_TextChanged(object sender, EventArgs e)
        {
            
        }

/***********************************************************************************************************************/


   
        private int readQuestions(string file)
        {
            StreamReader streamReader;
                    
            try
            {
                //read file
                streamReader = new StreamReader(file);
                int count;

                //read pairs of question and answer until end file
                //(two lines are pair:first line is question,second line is answer)
                for (count = 0; !streamReader.EndOfStream && count < MAX_Questions; ++count)
                {
                    qA[count] = new QuestionAnswer();
                    qA[count].Question = streamReader.ReadLine();
                    qA[count].Answer = streamReader.ReadLine();
                    
                }
                return count;
            }

            //if can't find the file to read
            catch (Exception exception)
            {
                MessageBox.Show("Error" + exception.Data, "Error!", MessageBoxButtons.OK);
                return -1; 
            }
        }

        //when click the "get spins" button, call askQuestion and clean answerbox
        private void getSpinbutton_Click(object sender, EventArgs e)
        {
            askQuestion();
            answerBox.Clear();
        }

        private void askQuestion()
        {
            //show question in question textbox.
            qtextbox.Text = qA[questionIndex].Question; 
            answerBox.ReadOnly = false;
            submitbutton.Enabled = true;
            nextButton.Enabled = false;
        }

        public int NumSpins
        {
            get
            {
                return numSpins;
            }

        }

        //when click the submitbutton
        private void submitbutton_Click(object sender, EventArgs e)
        {
            submitbutton.Enabled = false;
            userAns = answerBox.Text.ToLower();
            correctAns = qA[questionIndex].Answer.ToLower();
          
            if (userAns==correctAns)
            {
                //if answer is correc, show "Correct!"
                cwlabel.ForeColor = Color.Green;
                cwlabel.Text = "Correct!";
                ++numSpins; //add number of spins

/*****************************************************************/

                string plyspins = numSpins.ToString();
                player1spins.Text=plyspins;

                //print number of spins into the player1 board
/*****************************************************************/


            }
            else
            {
                //if answer is wrong, show text "wrong!"
                cwlabel.ForeColor = Color.Red;
                cwlabel.Text = "wrong!";
            }
            //after finish answering 3 questions, next button change to done
            if (questionCount==Ask_MAX_Questions -1)
                nextButton.Text = "Done!";
            
            questionIndex = (questionIndex + 1) % num_questions;
            nextButton.Enabled = true;
        }


        //when click the next button, 
        //clearing answerbox and result label for next question.
        private void nextButton_Click(object sender, EventArgs e)
        {

            answerBox.Clear();
            cwlabel.Text = "";
            
            if (nextButton.Text != "Done!")
            {
                questionIndex = (questionIndex + 1) % num_questions;
                ++questionCount; //increment question count

                //after answering all 3 questioins
                if (questionCount == Ask_MAX_Questions)
                {
                    nextButton.Text = "Done!";
                    submitbutton.Enabled = false;
                }
                //not finish to answer the 3 questions, ask more question.
                else
                {
                    askQuestion();
                }
            }
         
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        

    }
}
