using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using UnityEngine.UI;
using Buildings;
using TMPro;

public class BuildingStorePanelHelper : MonoBehaviour
{
    [SerializeField] private GameObject [] _buttons;
    [SerializeField] private GameObject [] _contents;
    [SerializeField] private GameObject _prefBuildingIcon;
    [SerializeField] private MainController _controller;

    private void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            FreeListHelper tempFreeListHelper = _buttons[i].GetComponent<FreeListHelper>();

            for (int j = 0; j < tempFreeListHelper.FreeLists[0].Items.Count; j++)
            {
                GameObject tempBuildingIcon = MainController.Instantiate(_prefBuildingIcon);
                tempBuildingIcon.transform.SetParent(_contents[i].transform);
                tempBuildingIcon.transform.localScale = Vector3.one;
                tempBuildingIcon.transform.position = Vector3.zero;

                RectTransform tempRect = tempBuildingIcon.GetComponent<RectTransform>();
                tempRect.anchoredPosition3D = Vector3.zero;
                tempRect.localRotation = Quaternion.Euler(Vector3.zero);

                Button tempButton = tempBuildingIcon.GetComponent<Button>();

                BuildingConfig tempConfig = tempFreeListHelper.FreeLists[0].Items[j];

                tempButton.onClick.AddListener(() => _controller.CreateFlyBuilding(tempConfig));
                tempButton.GetComponentInChildren<TextMeshProUGUI>().text = tempConfig.name;


            }

        }

        for (int i = 0; i < _contents.Length; i++)
        {
            //_contents[i].GetComponent<GridLayoutGroup>().enabled = false;
        }
    }
}
