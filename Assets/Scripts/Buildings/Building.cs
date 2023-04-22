using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buildings
{    
    public class Building
    {
        private GameObject _prefab;
        private Vector2Int _size = Vector2Int.one;

        public GameObject Prefab => _prefab;
        public Vector2Int Size => _size; 

        public Building(BuildingConfig config)
        {
            _prefab = config.Prefab;
            _size = config.Size;
        }
    }
}