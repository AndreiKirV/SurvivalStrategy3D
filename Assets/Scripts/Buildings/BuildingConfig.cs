using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buildings
{  
    [CreateAssetMenu(fileName = "BuildingConfig", menuName = "Buildings", order = 51)]
    public class BuildingConfig : ScriptableObject
    {
        public GameObject Prefab;
        public Vector2Int Size = Vector2Int.one;
    }
}