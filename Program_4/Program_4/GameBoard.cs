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
using System.Text.RegularExpressions;

namespace Program_4
{

    public partial class GameBoard : Form
    {
        const int NUM_PLAYERS = 3;
        int score_scaler = 3;
        int player1 = (int)setPlayer.player1;
        int player2 = (int)setPlayer.player2;

        static public List<Image> fileimgs = new List<Image>();
        // contains a List of images captured from the clients computer

        List<Player> Players = new List<Player>(2);
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
        private Control currentTile;

        public static int currentplayer { get; set; }
        /*---------------------------------------- currentplayer -------------
        |  Property:    currentplayer
        |
        |  Purpose:     stores the current player
        |
        |  Extension:
        |    (set) --   This allows assignment of the current player
        |
        |    (get) --   This provides the index of current player
        |
        |  Returns:  	The index (position) of the current player
        *-------------------------------------------------------------------*/


        public GameBoard()
        {
            InitializeComponent();

            for (int i = 0; i < NUM_PLAYERS; i++)
                Players.Add(new Player());
            /************************************************************************
             *   Creates an array to hold Player objects.
             *   This allows seamless switching of turns.
             *   Players may be indexed by either name 
             *   or index (i.e. "player1" or '0').  
             ************************************************************************/
            

            storeTiles();
            randTile();
            SelectTile();
            /**********************************************************************************************************/
            submitbutton.Enabled = false;
            answerBox.ReadOnly = true;
            num_questions = readQuestions(file);
            randQuestions();
            Players[0].spins = 3;
            Players[player2].spins = 3;
            updateScore();
            timer2.Enabled= true;

        }

        /********************************************************************************************************/
        private void randQuestions()
        {
            Random rand = new Random();
            int rand_index;
            QuestionAnswer temp;
            for (int i = 0; i < num_questions; i++)
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

        public void SwitchPlayer()
        /*-------------------------------------------- SwitchPlayer ----------
        |  Function: SwitchPlayer
        |
        |  Purpose: alternates the Players array
        |
        |  Parameters:
        |  Returns:  	The index (position) of the next player
        *-------------------------------------------------------------------*/
        {
            getSpinbutton.Enabled = true;
            nextButton.Text = "next";
            nextButton.Enabled = false;
            submitbutton.Enabled = true;

            questionCount = 0;
            if (currentplayer == 1)
            {
                currentplayer = 0;
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                currentplayer = 1;
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

        }

        public void randTile()
        {
            Random rand = new Random();
            Random randhighlight = new Random();

            foreach (PictureBox tile in this.TileBox.Controls)
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

        public void buzzer()
        {

            if ((ModifierKeys & Keys.LShiftKey) != 0)
                currentplayer = 0;
            if ((ModifierKeys & Keys.Space) != 0)
                currentplayer = 1;
            if ((ModifierKeys & Keys.RShiftKey) != 0)
                currentplayer = 3;
            MessageBox.Show("Player " + (currentplayer + 1) + "buzzed in");

        }

        public void SelectTile()
        {
            Random randhighlight = new Random();
            var randTile = this.TileBox.Controls;
            currentTile = randTile[randhighlight.Next(0, this.TileBox.Controls.Count)];
            currentTile.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            Players[currentplayer].score += score_scaler;     //      OR listPlayer[0].setScore(3);
            p1score.Text = "" + Players[0].score;
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
                            "ONEY OR GET MORE SPINS.\n\nPress the Sign to stop the spin. Game is over win player goes to negative spins.");
        }


        private void SpinButton_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            submitbutton.Enabled = true;
            getSpinbutton.Enabled = true;
            if ((string)currentTile.Tag == "whammy")
            {
                Players[currentplayer].score -= Players[currentplayer].score;
                MessageBox.Show("WHAMMY!!!!");
            }

            askQuestion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ClearTile();
            randTile();
            SelectTile();
            submitbutton.Enabled = false;
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
                streamReader = new StreamReader("..\\..\\" + file);
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

        //when click the "get spins" button, call askQuestion and clean answer box
        private void getSpinbutton_Click(object sender, EventArgs e)
        {
            
            
            Players[currentplayer].spins--;

            askQuestion();
            answerBox.Clear();
            updateScore();
            timer1.Interval = 250;
            timer1.Enabled = true;
            
        }

        private void askQuestion()
        {
            //show question in question text box.
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
            if (Players[currentplayer].spins <= 0)
                getSpinbutton.Enabled = false;
            submitbutton.Enabled = false;
            userAns = answerBox.Text.ToLower();
            correctAns = qA[questionIndex].Answer.ToLower();

            if (userAns == correctAns)
            {
                //if answer is correct, show "Correct!"
                isitcorrect.ForeColor = Color.Green;
                isitcorrect.Text = "Correct!";

                
                Players[currentplayer].score += convertScore();
                Players[currentplayer].spins++; //add number of spins
            }
            else
            {
                //if answer is wrong, show text "wrong!"
                isitcorrect.ForeColor = Color.Red;
                isitcorrect.Text = "wrong!";
                Players[currentplayer].score -= convertScore();
            }
            //after finish answering 3 questions, next button change to done
            if (questionCount == Ask_MAX_Questions+1)
                nextButton.Text = "Turn Over!";

            questionIndex = (questionIndex + 1) % num_questions;
            nextButton.Enabled = true;
            updateScore();
        }

        private int convertScore()
        {
            int convertedstring;
            try
            {
                var resultString = Regex.Match(currentTile.Tag.ToString(), @"\d+").Value;
                 convertedstring = Int32.Parse(resultString);
            }
            catch
            {
                 convertedstring = Players[currentplayer].score;
            }
            return convertedstring;
        }

        private void updateScore()
        {
            /*****************************************************************/
            p1spins.Text = Players[0].spins.ToString();
            p2spins.Text = Players[1].spins.ToString();
            //print number of spins into the player1 board
            /*****************************************************************/

            /*****************************************************************/
            p1score.Text = Players[0].score.ToString();
            p2score.Text = Players[1].score.ToString();
            //print number of spins into the player1 board
            /*****************************************************************/
        }

        //when click the next button, 
        //clearing answer box and result label for next question.
        private void nextButton_Click(object sender, EventArgs e)
        {

            answerBox.Clear();
            isitcorrect.Text = "";

            if (nextButton.Text != "Turn Over!")
            {
                questionIndex = (questionIndex + 1) % num_questions;
                questionCount++; //increment question count

                //after answering all 3 questions
                if (questionCount == Ask_MAX_Questions +1)
                {
                    
                    nextButton.Text = "Turn Over!";
                    SwitchPlayer();
                    MessageBox.Show("Player " +(currentplayer+1)+"'s turn");
                    submitbutton.Enabled = true;
                    
                    askQuestion();
                }
                //not finish to answer the 3 questions, ask more question.
                else
                {
                    askQuestion();
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (Players[currentplayer].spins < 0)
            {
                
                timer2.Dispose();
                MessageBox.Show("Player " + currentplayer + " Looses");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
