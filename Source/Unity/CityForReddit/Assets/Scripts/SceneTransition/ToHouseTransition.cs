using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**Caleb Whitman
 * calebrwhitman@gmail.com
 * Spring 2017
 */ 

/// <summary>
/// Loads the House from the SubredditDome.
/// </summary>
public class ToHouseTransition : SceneTransition {



	protected override void transferInfo()
	{
		WorldState.instance.menuController.GetComponent<MenuController> ().clearMenus ();
		SceneManager.LoadScene ("House");
	}
}
