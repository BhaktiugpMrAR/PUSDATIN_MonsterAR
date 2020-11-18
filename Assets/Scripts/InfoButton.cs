using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InfoButton : MonoBehaviour
{   
    string mainContentText, judulContent;
    public ColliderForInteraktif colliderForInteraktif;

    private void Start()
    {
        judulContent = colliderForInteraktif.nameObject;
        mainContentText = colliderForInteraktif.description_object;

    }
    private void OnMouseDown()
    {
        if(GlobalVariable.interactiveAR)
          InfoTextManager.instance.SetContent(mainContentText, judulContent);
    }
}
