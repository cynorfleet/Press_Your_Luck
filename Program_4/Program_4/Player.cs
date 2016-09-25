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

namespace Playernsp       /* Defines a custom namespace for the Player class */
{

    class Player
    {
        double score;
        int whammy;

    public Player()
        /*-------------------------------------------- Player ---------------------------
        |  Function:    default constructor
        |
        |  Purpose:     The default constructor simply initializes member data.
        |
        |  Parameters:  N/A
        |
        |  Returns:  	N/A
        *--------------------------------------------------------------------------------*/
        {
            score = 0.00;
            whammy = 0;
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
            return ("$" + score);
        }

     public void setScore(double ?scaler)
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

        ~Player()
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
