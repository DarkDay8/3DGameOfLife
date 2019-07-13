using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectModel
{
    private GameObjectView view;

    public bool IsRed { get; set; }


    public void UpdateBollView(bool isSet)
    {
        view.UpdateBoll(IsRed, isSet);
    }
    public GameObjectModel(GameObjectView view)
    {
        this.view = view;
    }


}
