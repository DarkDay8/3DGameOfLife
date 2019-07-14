using System;
using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class ControlPanelController
{
    private string path = "Prefabs/ControlPanel";
    private GameModel gameModel;
    public ControlPanelView View { private set; get; }

    public ControlPanelController(ref GameModel gameModel)
    {
        this.gameModel = gameModel;
        View = GameObject.Instantiate(Resources.Load(path, typeof(ControlPanelView)) as ControlPanelView);
        View.newFieldClick += CreateNewField;
        View.tickClick += Tick;
        View.setClick += CanSet;
        View.autoTickClick += StartAutoTick;
    }
    private void CreateNewField()
    {
        gameModel.DestoyAll();
        gameModel.SetFieldSize(View.GetNewFieldSize()).InstantiateGameObjects();
        View.autoTickClick -= StartAutoTick;
        StopAutoTick();
    }
    private void Tick()
    {
        gameModel.SetNewStatus(gameModel.NextStep(View.GetR1(), View.GetR2(), View.GetR3(), View.GetR4()));
    }
    private void CanSet()
    {
        GameController.IsSet = !GameController.IsSet;
        gameModel.SetNewStatus();
    }
    private void AutoTick()
    {
        Tick();
        TimersManager.SetTimer(this, View.GetDelay(), AutoTick);
    }
    private void StartAutoTick()
    {
        View.autoTickClick -= StartAutoTick;
        View.autoTickClick += StopAutoTick;
        AutoTick();
    }
    private void StopAutoTick()
    {
        View.autoTickClick -= StopAutoTick;
        View.autoTickClick += StartAutoTick;      
        TimersManager.ClearTimer(AutoTick);
    }
}
