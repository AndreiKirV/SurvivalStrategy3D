using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buildings;

namespace Utils
{
    [CreateAssetMenu(fileName = "FreeList", menuName = "FreeList", order = 52)]
    public class FreeList : ScriptableObject
    {
        public string Type;
        public List <BuildingConfig> Buildings;

        public FreeList(params BuildingConfig [] configs)
        {
            Buildings = new List<BuildingConfig>();

            for (int i = 0; i < configs.Length; i++)
            {
                Buildings.Add(configs[i]);
            }
        }
    }
}