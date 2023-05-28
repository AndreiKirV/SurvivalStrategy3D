using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.Dictionary;
using Main;
using UnityEngine.UI;
using System;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Utils;

public class BuildingStore
{
    public Canvas TargetCanvas;

    public BuildingStore(Canvas canvas)
    {
        TargetCanvas = canvas;
    }
    
    public void Init()
    {
            /*_buttons[buildingType].GetComponent<EventTriggersHelper>().PointerEnter.AddListener(
                () => OpenInfooPanel(buildingType)
                );*/
    }

    public void CreateMenuTypeBuildings(string name, Sprite sprite)
    {
    }

    public void CreateInfoPanel(string name)
    {
    }

    public void OpenInfooPanel(string target)
    {
    }

    private void SetZeroRect()
    {
    }
}