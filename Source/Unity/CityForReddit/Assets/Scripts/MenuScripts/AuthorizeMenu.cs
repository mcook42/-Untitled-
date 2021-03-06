﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Net;
using UnityEngine.UI;

/**Caleb Whitman
 * calebrwhitman@gmail.com
 * Spring 2017
 */ 

/// <summary>
/// The menu to let the user allow our application to access their account. 
/// Is created after a user logs in.
/// </summary>
public class AuthorizeMenu : Menu{

	public JToken token {get; set;}
	public string postParams {get; set;}
	public GameObject scopeList;
	public GameObject title;

	public void init(JToken token, string postParams,string userName)
	{
		this.token = token;
		this.postParams = postParams;

		Dictionary<string,string> scopes = WorldState.instance.redditRetriever.getAppScopeDescriptions ();

		Text text = scopeList.GetComponent<Text> ();
		foreach (KeyValuePair<string,string> scope in scopes) {
			text.text += " - " + scope.Value + "\n\n";
		}

		title.GetComponent<Text> ().text = "Hey "+userName+"! City For Reddit would like to connect with your reddit account.";
	}
		

	/// <summary>
	/// Authorizes the user.
	/// </summary>
	public void allow()
	{
		try{
			var code = WorldState.instance.redditRetriever.getCode (token, postParams);
			WorldState.instance.redditRetriever.authenticateUser (code);
		}
		catch(WebException w) {
			WorldState.instance.menuController.GetComponent<MenuController> ().loadErrorMenu("Web Error: " + w.Message);
		}
		catch (System.Security.Authentication.AuthenticationException ae)
		{
			WorldState.instance.menuController.GetComponent<MenuController> ().loadErrorMenu("Authentication Error: " + ae.Message);

		}

		Destroy (gameObject);

	}

	/// <summary>
	/// Cancel the Authorization.
	/// </summary>
	public void decline()
	{
		Destroy (gameObject);
	}

}
