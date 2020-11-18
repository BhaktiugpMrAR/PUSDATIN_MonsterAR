using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAssignType : MonoBehaviour
{
    public GlobalVariable.Type type;

    private void Start()
    {
      //  Debug.Log(GlobalVariable.typeObject);
    }
    public void AssignObjectType()
    {
        GlobalVariable.typeObject = type;
    }
}
