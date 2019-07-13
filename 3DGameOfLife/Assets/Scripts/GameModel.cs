using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    private string path = "Prefabs/GameObject";
    private byte field;
    private GameObjectView prefab;
    private GameObjectModel [,,] GameOjects;
    private Vector3 position;

    public GameModel(byte field)
    {
        this.field = field;
        position = new Vector3();
        prefab = Resources.Load(path, typeof(GameObjectView)) as GameObjectView;
        GameOjects = new GameObjectModel[field, field, field];
    }

    public bool InstantiateGameObjects(byte size ,bool [,,] status)
    {
        if (field != size)
            return false;

        for (int i = 0; i < field; i++)
        {
            position.y = 0;
            for (int j = 0; j < field; j++)
            {
                position.x = 0;
                for (int k = 0; k < field; k++)
                {
                    GameOjects[i,j,k] = new GameObjectModel(GameObject.Instantiate(prefab, position, Quaternion.identity));
                    GameOjects[i, j, k].IsRed = status[i, j, k];
                    GameOjects[i, j, k].UpdateBollView(GameController.IsSet);
                    position.x += 10;
                }
                position.y += 10;
            }
            position.z += 10;
        }
        return true;       
    }

}
