using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.Dictionary;
using Main;
using UnityEngine.UI;
using System;
using TMPro;
using System.IO;

public class BuildingStore
{
    public Canvas TargetCanvas;
    private GameObject _buttonPrefab = Resources.Load<GameObject>(Dictionaries.Path.UI.Button);
    private GameObject _storePrefab = Resources.Load<GameObject>(Dictionaries.Path.UI.STORE.BuildingStore);
    private List <Button> _buttons = new List<Button>();
    private GridLayoutGroup _storeGrid;
    private RectTransform _storeRect;

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

        _storeGrid = _storePrefab.GetComponentInChildren<GridLayoutGroup>();
        _storeRect = _storeGrid.GetComponent<RectTransform>();
        _storeGrid.padding.bottom = -(int)_storeRect.anchoredPosition.y;
        _storeGrid.cellSize = new Vector2((int)_storeRect.anchoredPosition.y, (int)_storeRect.anchoredPosition.y);

        for (int i = 0; i < Dictionaries.Buildings.Type.Length; i++)
        {
            CreateMenuTypeBuildings(Dictionaries.Buildings.Type[i]);
        }
    }

    public void CreateMenuTypeBuildings(string name)
    {
        GameObject tempGameObject = MainController.InstantiatePrefab(_buttonPrefab, Vector3.zero, _storeGrid.transform);
        RectTransform tempRect = tempGameObject.GetComponent<RectTransform>();
        tempRect.localRotation = Quaternion.Euler(Vector3.zero);
        tempRect.localPosition = Vector3.zero;
        tempGameObject.name = name;
        tempGameObject.GetComponentInChildren<TextMeshProUGUI>().text = name;
        Image tempButtonImage = tempGameObject.GetComponent<Image>();

        tempButtonImage.sprite = Resources.Load<Sprite>(Dictionaries.Buildings.BuildingsTypeIcon + name);
        Button tempButton = tempGameObject.GetComponent<Button>();

        _buttons.Add(tempButton);
    }
}