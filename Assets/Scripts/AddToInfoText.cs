using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInfoText : MonoBehaviour
{
    public static AddToInfoText instance;
    public List<Outline> outlineForResetColor;

    private void Awake()
    {
        instance = this;
    }
    public void AddTextInfo()
    {
       // InfoTextManager.instance.SetContent(GlobalVariable.descriptionPart, GlobalVariable.namepart);
    }
}
