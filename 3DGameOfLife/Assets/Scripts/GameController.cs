using System;
using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class GameController
{
    private byte fieldSize = 5;
    private GameModel gameModel;
    private ControlPanelController panelController;
    private CameraController cameraController;
    private string camerPath = "Prefabs/Camera";



    private bool[,,] baseParam =
    {
        {{true, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{true, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{true, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} }

    };


    public static bool IsSet { get; set; }

    public GameController()
    {
        IsSet = false;
    }
    public void StartGame()
    {
        cameraController = GameObject.Instantiate(Resources.Load(camerPath, typeof(CameraController)) as CameraController);
        gameModel = new GameModel(fieldSize);
        panelController = new ControlPanelController(ref gameModel);
        panelController.View.newFieldClick += NewFieldClick;
        gameModel.InstantiateGameObjects(baseParam);
        cameraController.SetPosition(fieldSize);
    }
    private void NewFieldClick()
    {
        cameraController.SetPosition(panelController.View.GetNewFieldSize());
    }
}
