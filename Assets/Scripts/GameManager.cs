using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject target1, target2;
    public float distanceTarget1ToTarget2;
    public float minDIstance = 80;
    private string nameTarget1, nameTarget2;
    public GameObject panelNotice;
    public GameObject[] highLight, objectAR;

    private void Awake()
    {
        objectAR = GameObject.FindGameObjectsWithTag("ObjectAR");
    }

    public void EnableObjectAR()
    {
        for(int i = 0; i < objectAR.Length; i++)
        {
            objectAR[i].SetActive(true);
        }
    }

    public void AddTarget(GameObject gameObject)
    {
        if (GlobalVariable.objectNameOnActive == gameObject.name)
        {
            panelNotice.SetActive(false);
            gameObject.SetActive(true);
            if (target1 != null)
            {
                target2 = gameObject;
                nameTarget2 = target2.name;
            }
            else
            {
                target1 = gameObject;
                nameTarget1 = target1.name;
            }
        }
        else
        {
            panelNotice.SetActive(true);
            gameObject.SetActive(false);
        }

        highLight = GameObject.FindGameObjectsWithTag(gameObject.name);
    }

    public void RemoveTarget(string nameTarget)
    {
        if(nameTarget1 == nameTarget)
        {
            target1 = null;
        }
        else if (nameTarget2 == nameTarget)
        {
            target2 = null;
        }

        panelNotice.SetActive(false);

        highLight = new GameObject[0];
    }

    void Update()
    {
        if (target2 != null && target2 != null)
        {
            distanceTarget1ToTarget2 = Vector3.Distance(target1.transform.position, target2.transform.position);
        }

        if(distanceTarget1ToTarget2 < minDIstance && target2 != null && target2 != null)
        {
            if(target1.GetComponent<ObjectManager>().numberFoodChain > target2.GetComponent<ObjectManager>().numberFoodChain)
            {
                target1.GetComponent<ObjectManager>().Attack();
            }
            else
            {
                target1.GetComponent<ObjectManager>().Attacked();
            }

            if (target2.GetComponent<ObjectManager>().numberFoodChain > target1.GetComponent<ObjectManager>().numberFoodChain)
            {
                target2.GetComponent<ObjectManager>().Attack();
            }
            else
            {
                target2.GetComponent<ObjectManager>().Attacked();
            }
        }
        else if(distanceTarget1ToTarget2 > minDIstance && target2 != null && target2 != null)
        {
            target1.GetComponent<ObjectManager>().BackToIdle();
            target2.GetComponent<ObjectManager>().BackToIdle();
        }
    }


}
