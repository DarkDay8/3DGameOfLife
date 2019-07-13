using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private byte fieldSize = 5;
    private GameModel gameModel;
    private bool[,,] baseParam =
    {
        {{false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false}, {false, false, false, false, false} },
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
        gameModel.InstantiateGameObjects(fieldSize, baseParam);
    }

}
