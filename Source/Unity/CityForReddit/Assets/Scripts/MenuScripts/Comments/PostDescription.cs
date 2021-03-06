using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedditSharp.Things;
using UnityEngine.UI;

/**Caleb Whitman
 * calebrwhitman@gmail.com
 * Spring 2017
 */ 

/// <summary>
/// Script that sets up the description for a post.
/// </summary>
public class PostDescription : VotableInfo {

	public GameObject image;
	public GameObject title;
	public GameObject info;
	public GameObject link;

	private ThingMenu menu;
	/// <summary>
	/// Creates the post.
	/// </summary>
	/// <param name="childDepth">Child depth.</param>
	/// <param name="post">Post.</param>
	public void Init(Post post, ThingMenu menu)
	{
		this.thing = post;
		this.menu = menu;

		title.GetComponent<Text> ().text = post.Title;
		info.GetComponent<Text>().text = "Submitted "+getTimeCreated(post.CreatedUTC)+" by "+post.AuthorName;
		upvotes.GetComponent<Text> ().text = "Upvotes: "+post.Upvotes;
		body.GetComponent<Text> ().text = post.SelfText;


		initializeButtons ();

		WorldState.instance.redditRetriever.register (this);

		if (post.Url != null) {
			StartCoroutine(loadLink(post.Url.AbsoluteUri));
		}

	}

	protected override void initializeButtons()
	{
		replyButton.GetComponent<Button> ().onClick.AddListener (() => reply ());
		saveButton.GetComponent<Button> ().onClick.AddListener (() => toggleSave());
		saveButton.GetComponentInChildren<Text> ().text = thing.Saved ? "Unsave" : "Save";
		downvoteButton.GetComponent<Button> ().onClick.AddListener (() => downvote ());
		downvoteButton.GetComponentInChildren<Text> ().text = (thing.Vote == VotableThing.VoteType.Downvote) ? "Downvoted!" : "Downvote";
		upvoteButton.GetComponent<Button> ().onClick.AddListener (() => upvote ());
		upvoteButton.GetComponentInChildren<Text> ().text = (thing.Vote == VotableThing.VoteType.Upvote) ? "Upvoted!" : "Upvote";

		//no need for these buttons if the user isn't logged in.
		if (WorldState.instance.reddit.User == null) {
			actionPanel.SetActive (false);
		}

	}

	/// <summary>
	/// Reply to this post.
	/// </summary>
	public void reply()
	{
		var replyMenu = Instantiate(replyMenuPrefab);
		replyMenu.GetComponent<ReplyMenu>().init((Post)thing,this);
	}

	/// <summary>
	/// Adds a the comment child to the post.
	/// </summary>
	/// <param name="comment">Comment.</param>
	public override void addChild(Comment comment)
	{
		var newComment = menu.initializeThing (menu.content, comment, 0);
		newComment.transform.SetSiblingIndex (1);
	}

	/// <summary>
	/// Loads the linked content. If linked content cannout be loaded, simply adds a button linking to that content.
	/// </summary>
	/// <returns>The image.</returns>
	/// <param name="loadedURL">Loaded UR.</param>
	private IEnumerator loadLink(string loadedURL)
	{
		Texture2D temp = new Texture2D(0,0);
		WWW www = new WWW(loadedURL);
		yield return www;

		temp = www.texture;

		//Unity doesn't really tell you if a texture laoded or not, so for now this is used.
		if (temp.height == 8 && temp.width == 8) {
			image.SetActive (false);
			link.GetComponent<Button> ().onClick.AddListener (() => linkButton (loadedURL));
		}
		else {
			link.SetActive (false);
			Sprite sprite = Sprite.Create (temp, new Rect (0, 0, temp.width, temp.height), new Vector2 (0.5f, 0.5f));
			Transform thumb = image.transform;
			thumb.GetComponent<Image> ().sprite = sprite;
		}
	}

	/// <summary>
	/// Opens the URL in a user's browser.
	/// </summary>
	/// <param name="url">URL.</param>
	public void linkButton(string url)
	{

		Application.OpenURL (url);
	}
}
