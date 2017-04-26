﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Graph;
using RedditSharp.Things;

/// <summary>
/// The class that draws the lines between the objects.
/// </summary>
public class Line: MonoBehaviour
{

	public  Node<Subreddit> pt1;
	public Node<Subreddit> pt2;

	/// <summary>
	/// Creates the line with points 1 and 2.
	/// </summary>
	/// <param name="pt1">Pt1.</param>
	/// <param name="pt2">Pt2.</param>
	public void Init(Node<Subreddit> pt1, Node<Subreddit> pt2)
	{
		this.pt1 = pt1;
		this.pt2 = pt2;
		Draw ();

	}

	void Draw()
	{
		if (pt1 != null && pt2 != null) {
			Vector2 position1 = pt1.position;
			Vector2 position2 = pt2.position;

			Vector2 center = ((position1 - position2) / 2) + position2;
			float length = (position1 - position2).magnitude;



			RectTransform rectangle = transform.GetComponent<RectTransform>();
			rectangle.anchoredPosition = new Vector3(center.x,center.y,1);

			rectangle.sizeDelta = new Vector2(8, length);
			transform.eulerAngles = new Vector3 (0,0,-(float) (360*Mathf.Atan2((position1.x-position2.x),(position1.y-position2.y))/(2*Math.PI)) );
			transform.SetAsFirstSibling ();



		}
	}

}






