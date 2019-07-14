using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class GameController
{
    private byte fieldSize = 5;
    private GameModel gameModel;
    private bool[,,] baseParam =
    {
        {{true, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{true, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{true, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} }

    };

    private bool[,,] baseParam1 =
{
        {{true, false, false, false, false}, {true, false, false, false, false}, {true, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, true, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, true, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, true, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
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
        gameModel.InstantiateGameObjects(baseParam);
        TimersManager.SetTimer(this, 5, Tick);

    }

    public void Tick()
    {
        gameModel.SetNewStatus(gameModel.NextStep(1,3,3,5));
    }

}
