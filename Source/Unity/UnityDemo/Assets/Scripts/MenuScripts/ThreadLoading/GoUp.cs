﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoUp : MonoBehaviour {

    public GameObject SubredditSceneSetup;

    /// <summary>
    /// Loads 25 new Threads.
    /// </summary>
	void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        GameInfo.instance.menuController.GetComponent<LoadingPanel>().loadPanel();
        SubredditSceneSetup.GetComponent<SubredditSceneSetup>().loadThreads(25,true);
        Debug.Log("Going Up!");
        GameInfo.instance.menuController.GetComponent<LoadingPanel>().unLoadMenu();
    }
}
