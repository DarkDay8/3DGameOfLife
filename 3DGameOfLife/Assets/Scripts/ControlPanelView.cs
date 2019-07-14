using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelView : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private InputField FieldSize;
    [SerializeField]
    private InputField R1;
    [SerializeField]
    private InputField R2;
    [SerializeField]
    private InputField R3;
    [SerializeField]
    private InputField R4;
    [SerializeField]
    private InputField Delay;
    [SerializeField]
    private Button CreateNewField;
    [SerializeField]
    private Button Tick;
    [SerializeField]
    private Button Set;
    [SerializeField]
    private Button AutoTick;
    #endregion

    public event Action setClick; 
    public event Action tickClick; 
    public event Action autoTickClick;
    public event Action newFieldClick;

    public byte GetR1()
    {
        return byte.Parse(R1.text);
    }
    public byte GetR2()
    {
        return byte.Parse(R2.text);
    }
    public byte GetR3()
    {
        return byte.Parse(R3.text);
    }
    public byte GetR4()
    {
        return byte.Parse(R4.text);
    }
    public float GetDelay()
    {
        return float.Parse(Delay.text);
    }
    public byte GetNewFieldSize()
    {
        return byte.Parse(FieldSize.text);
    }

    void Awake()
    {
        CreateNewField.onClick.AddListener(() => newFieldClick());
        Tick.onClick.AddListener(() => tickClick());
        Set.onClick.AddListener(() => setClick());
        AutoTick.onClick.AddListener(() => autoTickClick());
    }
}
