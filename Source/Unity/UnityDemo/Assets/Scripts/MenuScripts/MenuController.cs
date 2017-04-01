﻿/* MenuController.cs
 * Author: Caleb Whitman
 * January 20, 2016
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
///  A class that holds the canvas. This class also contains a few menu functions that don't belong to any particular menu.
/// </summary>
public class MenuController : MonoBehaviour {

    public GameObject canvas;

	//number of menus currently loaded. This is used to tell if the player is still in the menu screen.
	public int menusLoaded = 0;


    /// <summary>
    /// Exists the application. This will not work within the editor.
    /// </summary>
    public void quit(){
		
		Application.Quit ();

	}


}
