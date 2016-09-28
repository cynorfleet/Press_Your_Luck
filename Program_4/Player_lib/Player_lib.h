// Player_lib.h

#pragma once

using namespace System;

namespace Player_lib {

	public ref class Player
	{
		int score;
		int whammy;
		// TODO: Add your methods for this class here.
	public:Player()
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

	public:char* getScore()
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
		char* result = "score: $";
		result += score;

		return (result + '.00');
	}

	public:void setScore(int scaler)
		/*-------------------------------------------- setScore ------------------------------
		|  Function:    setScore
		|
		|  Purpose:     This function will increment/decrement the players score
		|               depending if the argument being passed is +/-.
		|
		|  Parameters:
		|	 (IN) --    a double variable "scaler?". This is just a value used to increment
		|               the player's score.
		|
		|  Returns:  	N/A
		*------------------------------------------------------------------------------------*/
	{
		score += scaler;
	}


	public:int getWhammy()
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

	public:void setWhammy(int scaler)
		/*-------------------------------------------- setWhammy -------------------------------
		|  Function:    setWhammy
		|
		|  Purpose:     This function will increment/decrement the players whammies
		|               depending if the argument being passed is +/-.
		|
		|  Parameters:
		|	 (IN) --    a double variable "scaler?". This is just a value used to increment
		|               the player's whammy accumulation.
		|
		|  Returns:  	N/A
		*-------------------------------------------------------------------------------------*/
	{
		whammy += scaler;
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
		   {}
	};
}
