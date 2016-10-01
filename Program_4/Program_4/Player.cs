/*-------------------------------------------- Player -----------------------------------
|  Class:   Player
|
|  Purpose: This class will act as a container for player 
|           related variables and functionality.
|
*--------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player /* Defines a custom namespace for the Player class */
{

    enum setPlayer { player1, player2, player3 };

    class NewPlayer
    {
        int score;
        int whammy;

        public NewPlayer(int default_score = 0, int default_whammy = 0)
        /*-------------------------------------------- Player --------------------------------
        |  Function:    constructor
        |
        |  Purpose:     The constructor simply initializes member data using optional parameters.
        |
        |  Parameters:
        |   (IN/opt) -- An optional integer "default_score". If no argument is sent the value
        |               zero will be used by default.
        |
        |   (IN/opt) -- An optional integer "default_whammy". If no argument is sent the value
        |               zero will be used by default.
        |
        |            -- If neither argument is sent, this will be treated as Default Constructor
        |
        |  Returns:  	N/A
        *-----------------------------------------------------------------------------------*/
        {
            score = default_score;
            whammy = default_whammy;
        }
        
     public string getScore()
        /*-------------------------------------------- getScore -----------------------------
        |  Function:    getScore
        |
        |  Purpose:     This function will provide the money available to the
        |               current Player.
        |
        |  Parameters:  N/A
        |
        |  Returns:  	The Player's score in dollar format.
        *-----------------------------------------------------------------------------------*/
        {
            return ("$" + score + ".00");
        }

     public void setScore(int ?scaler)
        /*-------------------------------------------- setScore ------------------------------
        |  Function:    setScore
        |
        |  Purpose:     This function will increment/decrement the players score
        |               depending if the argument being passed is +/-.
        |
        |  Parameters:
        |	 (IN) --    a double variable "scaler?". This is just a value used to increment
        |               the player's score. The '?' on the variable makes it a null-able value 
        |               (which means that you can assign null to it).
        |
        |  Returns:  	N/A
        *------------------------------------------------------------------------------------*/
        {
            score += scaler ?? 0;
           /**********************************************************************************   
            *    The ?? operator is called the null-coalescing operator.                     *
            *    It returns the left-hand operand if the operand is not null;                *
            *    otherwise it returns the right hand operand.                                *
            **********************************************************************************/
        }


        public int getWhammy()
        /*-------------------------------------------- getWhammy -------------------------------
        |  Function:    getWhammy
        |
        |  Purpose:     This function will provide the amount of whammies accumulated by the
        |               current Player.
        |
        |  Parameters:  N/A
        |
        |  Returns:  	The Player's whammies
        *-------------------------------------------------------------------------------------*/
        { 
            return (whammy);
        }

        public void setWhammy(int? scaler)
        /*-------------------------------------------- setWhammy -------------------------------
        |  Function:    setWhammy
        |
        |  Purpose:     This function will increment/decrement the players whammies
        |               depending if the argument being passed is +/-.
        |
        |  Parameters:
        |	 (IN) --    a double variable "scaler?". This is just a value used to increment
        |               the player's score. The '?' on the variable makes it a null-able value 
        |                (which means that you can assign null to it).
        |
        |  Returns:  	N/A
        *-------------------------------------------------------------------------------------*/
        {
            whammy += scaler ?? 0;
            /**********************************************************************************   
             *    The ?? operator is called the null-coalescing operator.                     *
             *    It returns the left-hand operand if the operand is not null;                *
             *    otherwise it returns the right hand operand.                                *
             **********************************************************************************/
        }

        public override string ToString()
        /*-------------------------------------------- ToString ------------------------------
        |  Function:    ToString
        |
        |  Purpose:     Overrides the base class's ToString method for appropriate formatting
        |
        |  Parameters:  N/A
        |
        |  Returns:  	The player's score and whammies
        *------------------------------------------------------------------------------------*/     
        {
            return ("score: " + score + "\nwhammy" + whammy);
        }

        ~NewPlayer()
        /*-------------------------------------------- ~Player -------------------------------
        |  Function:    Destructor
        |
        |  Purpose:     This function will prepare the object for garbage collection
        |
        |  Parameters:  N/A
        |
        |  Returns:  	N/A
        *-------------------------------------------------------------------------------------*/
        { 
        }


    }
}
