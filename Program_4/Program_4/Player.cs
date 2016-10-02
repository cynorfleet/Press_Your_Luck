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

namespace Chris       /* Defines a custom namespace for the Player class */
{

    enum setPlayer { player1, player2, player3 };
    class Player
    {
        public int score { get; set ; }
        /*-------------------------------------------- score -------------------------------
       |  Property:    score
       |
       |  Purpose:     This function will provide/scale the money available to the
       |               current Player.
       |  Extension:
       |    (set) --   This allows assignment of the score variable
       |
       |    (get) --   This provides the score
       |
       |  Returns:  	The Player's score in dollar format as a string type.
       *-----------------------------------------------------------------------------------*/

        public int whammy { get; set; }
        /*-------------------------------------------- score -------------------------------
        |  Property:    whammy
        |
        |  Purpose:     This function will provide/scale the amount of whammies accumulated
        |               by the current Player.
        |  Extension:
        |    (set) --   This allows assignment of the whammy variable
        |
        |    (get) --   This provides the whammies
        |
        |  Returns:  	The Player's whammies in as a int type.
        *-----------------------------------------------------------------------------------*/

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
            score = 0;
            whammy = 0;
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
            return ("score: $" + score + ".00\nwhammy" + whammy);
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
