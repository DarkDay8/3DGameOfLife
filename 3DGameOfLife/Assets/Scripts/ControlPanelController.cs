using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelController
{
    private string path = "Prefabs/ControlPanel";
    private ControlPanelView prefab;
    private GameModel gameModel;
    private ControlPanelView view;

    public ControlPanelController(ref GameModel gameModel)
    {
        this.gameModel = gameModel;
        prefab = Resources.Load(path, typeof(ControlPanelView)) as ControlPanelView;
        view = GameObject.Instantiate(prefab);
        view.newFieldClick += CreateNewFiel;
        view.tickClick += Tick;
        view.setClick += CanSet;
    }
    private void CreateNewFiel()
    {
        gameModel.DestoyAll();
        gameModel.SetFieldSize(view.GetNewFieldSize()).InstantiateGameObjects();
    }
    private void Tick()
    {
        gameModel.SetNewStatus(gameModel.NextStep(view.GetR1(), view.GetR2(), view.GetR3(), view.GetR4()));
    }
    private void CanSet()
    {
        GameController.IsSet = !GameController.IsSet;
        gameModel.SetNewStatus();
    }
}
