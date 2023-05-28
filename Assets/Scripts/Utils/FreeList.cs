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
        public List <BuildingConfig> Items;

        public FreeList(params BuildingConfig [] configs)
        {
            Items = new List<BuildingConfig>();

            for (int i = 0; i < configs.Length; i++)
            {
                Items.Add(configs[i]);
            }
        }
    }
}