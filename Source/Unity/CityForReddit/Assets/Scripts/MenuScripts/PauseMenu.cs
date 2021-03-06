﻿/**Caleb Whitman
 * calebrwhitman@gmail.com
 * Spring 2017
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A menu to pause the game.
/// </summary>
public class PauseMenu : LogInButtonObserver {


    /// <summary>
    /// Resumes the applicaton.
    /// </summary>
    public void resume()
    {
		Destroy (gameObject);

    }

	/// <summary>
	/// Loads the main menu.
	/// </summary>
	public void mainMenu()
	{
		var transition = GetComponent<ToMainTransition> ();
		transition.loadMainMenu ();
		Destroy (gameObject);
	}


    
}
