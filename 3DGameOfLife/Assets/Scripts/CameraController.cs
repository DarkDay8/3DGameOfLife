using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private float speed;
    private float distanceBetweenObjects = 10;
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveRange = Input.GetAxis("Mouse ScrollWheel");

        transform.Rotate(moveVertical * Time.deltaTime * speed, moveHorizontal * Time.deltaTime * speed, 0);
        camera.localPosition = new Vector3(0, 0, camera.localPosition.z + moveRange * speed) ;

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void SetPosition(byte boolInRow)
    {
        float point = distanceBetweenObjects * boolInRow / 2;
        transform.position = new Vector3(point, -point, -point);
    }
}
