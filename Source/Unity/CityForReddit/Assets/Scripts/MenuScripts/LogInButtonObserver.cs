﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**Caleb Whitman
 * calebrwhitman@gmail.com
 * Spring 2017
 */ 

/// <summary>
/// Handles logging in/out.
/// </summary>
public class LogInButtonObserver : Menu,LoginObserver {

	public GameObject loginButton;
	public GameObject loginMenu;

	/// <summary>
	/// Registers this object with the redditRetriever. 
	/// </summary>
	public new void Start()
	{
		base.Start ();
		WorldState.instance.redditRetriever.register (this);

		if (WorldState.instance.reddit.User != null) {
			notify (true);
		} else {
			notify (false);
		}
	}

	/// <summary>
	/// Changes login button text and functionailty based on whether or not the user is already logged in.
	/// </summary>
	/// <param name="loginBool">If set to <c>true</c> login.</param>
	public void notify(bool loginBool)
	{

		if (loginBool) {
			loginButton.GetComponent<Button> ().onClick.RemoveAllListeners ();
			loginButton.GetComponent<Button> ().onClick.AddListener ( () => logout() );
			loginButton.GetComponentInChildren<Text> ().text = "Logout";
		} else {
			loginButton.GetComponent<Button> ().onClick.RemoveAllListeners ();
			loginButton.GetComponent<Button> ().onClick.AddListener (() => login());
			loginButton.GetComponentInChildren<Text> ().text = "Login";
		}


	}

	/// <summary>
	/// Brings up the login menu.
	/// </summary>
	public void login()
	{
		Instantiate (loginMenu);
	}

	/// <summary>
	/// Logs out ths current user.
	/// </summary>
	public void logout()
	{
		WorldState.instance.redditRetriever.logout ();

	}

	/// <summary>
	/// Unregisters this object and then destroys the instance.
	/// </summary>
	public new void OnDestroy()
	{
		WorldState.instance.redditRetriever.unRegister (this);
		base.OnDestroy ();
	}

}
