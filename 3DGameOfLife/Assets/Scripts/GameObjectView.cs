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
