using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    private string path = "Prefabs/GameObject";
    private byte field;
    private GameObjectView prefab;
    private GameObjectModel[,,] gameOjects;
    private Vector3 position;

    public GameModel(byte field)
    {
        this.field = field;
        prefab = Resources.Load(path, typeof(GameObjectView)) as GameObjectView;
    }

    public GameModel SetFieldSize(byte size)
    {
        field = size;
        return this;
    }
    public bool InstantiateGameObjects(bool[,,] status)
    {
        gameOjects = new GameObjectModel[field, field, field];
        if (status.Length != gameOjects.Length)
            return false;

        position = new Vector3();
        for (int i = 0; i < field; i++)
        {
            position.z = 0;
            for (int j = 0; j < field; j++)
            {
                position.x = 0;
                for (int k = 0; k < field; k++)
                {
                    gameOjects[i, j, k] = new GameObjectModel(GameObject.Instantiate(prefab, position, Quaternion.identity));
                    gameOjects[i, j, k].IsRed = status[i, j, k];
                    gameOjects[i, j, k].UpdateBollView(GameController.IsSet);
                    //gameOjects[i, j, k].SetIJKToView(i, j, k); to debug
                    position.x += 10;
                }
                position.z -= 10;
            }
            position.y -= 10;
        }
        return true;
    }
    public bool InstantiateGameObjects()
    {
        return InstantiateGameObjects(new bool[field, field, field]);
    }
    public void DestoyAll()
    {
        foreach (var item in gameOjects)
        {
            item.Destoy();
        }
    }
    public void SetNewStatus(bool[,,] status)
    {
        if (status.Length != gameOjects.Length)
            return;
        for (int i = 0; i < field; i++)
        {
            for (int j = 0; j < field; j++)
            {
                for (int k = 0; k < field; k++)
                {
                    gameOjects[i, j, k].IsRed = status[i, j, k];
                    gameOjects[i, j, k].UpdateBollView(GameController.IsSet);
                }
            }
        }
    }
    public void SetNewStatus()
    {
        foreach (var item in gameOjects)
            item.UpdateBollView(GameController.IsSet);
    }
    public bool[,,] NextStep(byte r1, byte r2, byte r3, byte r4)
    {
        bool[,,] newStatus = new bool[field, field, field];
        for (int i = 0; i < field; i++)
        {
            for (int j = 0; j < field; j++)
            {
                for (int k = 0; k < field; k++)
                {
                    newStatus[i, j, k] = gameOjects[i, j, k].IsRed ? 
                        !DestroyRedBoll(r3, r4, i, j, k) : CreateNewRedBoll(r1, r2, i, j, k);
                }
            }
        }
        return newStatus;
    }
    private bool CreateNewRedBoll(byte min, byte max, int i, int j, int k)
    {
        int neighborsCount = NeighborsCount(i, j, k, false);
        return neighborsCount >= min && neighborsCount <= max;
    }
    private bool DestroyRedBoll(byte min, byte max, int i, int j, int k)
    {
        int neighborsCount = NeighborsCount(i, j, k, true);
        return neighborsCount > min || neighborsCount < max;
    }
    private int NeighborsCount(int i, int j, int k, bool isRed)
    {
        int neighborsCount = 0;
        int minI = i - 1 < 0 ? 0 : i - 1;
        int maxI = i + 1 >= field ? field - 1 : i + 1;
        int minJ = j - 1 < 0 ? 0 : j - 1;
        int maxJ = j + 1 >= field ? field - 1 : j + 1;
        int minK = k - 1 < 0 ? 0 : k - 1;
        int maxK = k + 1 >= field ? field - 1 : k + 1;

        for (int _i = minI; _i <= maxI; _i++)
        {
            for (int _j = minJ; _j <= maxJ; _j++)
            {
                for (int _k = minK; _k <= maxK; _k++)
                {
                    if (gameOjects[_i, _j, _k].IsRed)
                        neighborsCount++;
                }
            }
        }
        return isRed ? neighborsCount - 1 : neighborsCount;
    }
}
