using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownInBoll : MonoBehaviour
{
    public event Action click;
    private void OnMouseDown()
    {
        click();
    }
}
