using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.Dictionary;
using Main;
using UnityEngine.UI;
using System;

public class BuildingStore
{
    public Canvas TargetCanvas;
    private GameObject _button = Resources.Load<GameObject>(Dictionaries.Path.UI.Button);
    private List <Button> _buttons = new List<Button>();
    private GameObject _storePrefab = Resources.Load<GameObject>(Dictionaries.Path.UI.STORE.BuildingStore);

    public BuildingStore(Canvas canvas)
    {
        TargetCanvas = canvas;
    }
    
    public void Init()
    {
        _storePrefab = MainController.InstantiatePrefab(_storePrefab, TargetCanvas.transform.position, TargetCanvas.transform);
       RectTransform tempRect =  _storePrefab.GetComponent<RectTransform>();
       tempRect.localRotation = Quaternion.Euler(Vector3.zero);
        tempRect.localPosition = Vector3.zero;
        tempRect.offsetMin = Vector2.zero;
        tempRect.offsetMax = Vector2.zero;

        for (int i = 0; i < Enum.GetValues(typeof(Dictionaries.Buildings.Type)).Length; i++)
        {
            CreateMenuBuildings();
        }
    }

    public void CreateMenuBuildings()
        {
           GameObject temoGameObject = MainController.InstantiatePrefab(_button, Vector3.zero, _storePrefab.GetComponentInChildren<GridLayoutGroup>().transform);
           RectTransform tempRect = temoGameObject.GetComponent<RectTransform>();
           tempRect.localRotation = Quaternion.Euler(Vector3.zero);
           tempRect.localPosition = Vector3.zero;

           _buttons.Add(temoGameObject.GetComponent<Button>());
        }
}