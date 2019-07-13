using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = new GameController();
        gameController.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
