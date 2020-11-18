﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    public float rotSpeed = 20;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        // float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -rotX);
        //  transform.Rotate(Vector3.right, rotY);
    }
}
