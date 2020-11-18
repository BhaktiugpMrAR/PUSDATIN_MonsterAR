﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject panelLoading;

    private void Start()
    {
        if (panelLoading != null)
            panelLoading.SetActive(false);
    }

    public void LoadScene(string nameScene)
    {
        if (panelLoading != null)
            panelLoading.SetActive(true);
        StartCoroutine(LoadYourAsyncScene(nameScene));
    }
    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
