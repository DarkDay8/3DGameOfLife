using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectModel
{
    private GameObjectView view;

    public bool IsRed { get; set; }
    /* To Debug
    public void SetIJKToView(int i, int j, int k)
    {
        view.SetIJK(i, j, k);
    }
    */
    public GameObjectModel(GameObjectView view)
    {
        this.view = view;
        this.view.clickToBool += ClickToBool;
    }
    public void UpdateBollView(bool isSet)
    {
        view.UpdateBoll(IsRed, isSet);
    }
    public void Destoy()
    {
        GameObject.Destroy(view.gameObject);
    }
    private void ClickToBool()
    {
        IsRed = !IsRed;
        view.UpdateBoll(IsRed, GameController.IsSet);
    }
}
