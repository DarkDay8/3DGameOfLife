using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectView : MonoBehaviour
{
    public event Action clickToBool;
    [SerializeField]
    private GameObject boll;
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material blue;

    private OnMouseDownInBoll bollClick;
    #region ToDebug
    /*
    [SerializeField]
    private int i;
    [SerializeField]
    private int j;
    [SerializeField]
    private int k;

    public void SetIJK(int i, int j, int k)
    {
        this.i = i;
        this.j = j;
        this.k = k;
    }
    */
    #endregion
    public void UpdateBoll(bool isRed, bool isSet)
    {      
        boll.GetComponent<MeshRenderer>().material = isRed ? red : blue;
        boll.SetActive(isRed || isSet);

        if (isSet && bollClick == null)
        {
            bollClick = boll.AddComponent<OnMouseDownInBoll>();
            bollClick.click += clickToBool;
        }
        else if (!isSet && bollClick != null)
        {
            Destroy(boll.GetComponent<OnMouseDownInBoll>());
            bollClick = null;
        }     
    }
    public void SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}
