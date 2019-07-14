using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class GameController
{
    private byte fieldSize = 5;
    private GameModel gameModel;
    private ControlPanelController panelController;
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
        gameModel = new GameModel(fieldSize);
        panelController = new ControlPanelController(ref gameModel);
        gameModel.InstantiateGameObjects(baseParam);
        //TimersManager.SetTimer(this, 5, Tick);

    }

    public void Tick()
    {
        gameModel.SetNewStatus(gameModel.NextStep(1,3,3,5));
        TimersManager.SetTimer(this, 5, () => gameModel.DestoyAll());
    }

}
