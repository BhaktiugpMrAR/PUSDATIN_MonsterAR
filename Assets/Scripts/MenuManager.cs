using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MenuManager : MonoBehaviour
{
    public GameObject[] scrollViewChoice;
    public GameObject panelMenuManager;
    public VuforiaBehaviour vuforiaBehaviour;


    private void Start()
    {
        vuforiaBehaviour.enabled = false;
    }

    public void ChangescrollViewChoice(int index)
    {
        for(int i = 0; i < scrollViewChoice.Length; i++)
        {
            if(i == index)
            {
                scrollViewChoice[i].SetActive(true);
            }
            else
            {
                scrollViewChoice[i].SetActive(false);
            }

        }
    }

    public void SetNameObject(string nameObject)
    {
        GlobalVariable.objectNameOnActive = nameObject;
        vuforiaBehaviour.enabled = true;
        panelMenuManager.SetActive(false);
    }

    public void DeathActiveCamera()
    {
        vuforiaBehaviour.enabled = false;
    }
}
