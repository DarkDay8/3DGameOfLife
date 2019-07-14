using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectView : MonoBehaviour
{
    [SerializeField]
    private GameObject boll;
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material blue;

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
        if(isRed)
        {
            boll.GetComponent<MeshRenderer>().material = red;
            boll.SetActive(true);
        }
        else if (isSet)
        {
            boll.GetComponent<MeshRenderer>().material = blue;
            boll.SetActive(true);
        }
        else
        {
            boll.SetActive(false);
        }
    }
    public void SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}
