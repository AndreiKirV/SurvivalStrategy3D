using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper : MonoBehaviour
{
    public GameObject [] GameObjects;

    public void Open(GameObject target)
    {
        for (int i = 0; i < GameObjects.Length; i++)
        {
            if(GameObjects[i] != target)
            {
                GameObjects[i].SetActive(false);
            }
            else
            {
                GameObjects[i].SetActive(true);
            }
        }
    }

    public void ChangeActivity(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }
}