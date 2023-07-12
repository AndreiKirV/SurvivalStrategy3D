using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buildings;
using Main.Dictionary;
using Main;
using Main.Ui;

namespace GWC
{
    public class BuildingController
    {
        private Vector2Int _size;
        private Vector2 _offset = new Vector2(0.5f, 0.5f);
        private Building[,] _buildings;
        private Building _currentFlyBuilding;
        private Plane _plane = new Plane(Vector3.up, Vector3.zero);
        private Camera _camera;

        public void Awake()
        {
            _camera = Camera.main;

            _buildings = new Building[_size.x, _size.y];
        }

        public void Start()
        {

        }

        public void Update()
        {
            if(_currentFlyBuilding != null)
            {
                Vector3? worldPosition = UIController.Cursor.GiveTerrainPoint();

                if(worldPosition != null)
                {
                    int x = Mathf.RoundToInt(worldPosition.Value.x);
                    int z = Mathf.RoundToInt(worldPosition.Value.z);

                    bool available = true;

                    _currentFlyBuilding.Prefab.transform.position = new Vector3(x + _offset.x, worldPosition.Value.y, z + _offset.y);

                    if(x < 0 || x > _size.x - _currentFlyBuilding.Size.x + _offset.x || z < 0 || z > _size.y - _currentFlyBuilding.Size.y + _offset.y)
                    {
                        available = false;
                    }

                    if(available && Input.GetMouseButtonUp(0) && !IsPlaceTaken(x,z))
                    {
                        PlaceBuilding(x, z);
                    }
                }
            }
        }

        //устанавливает здание, в случае если к курсору привязано здание - удаляет его
        public void CreateFlyBuilding(BuildingConfig config)
        {
            BuildingConfig temp = ScriptableObject.CreateInstance<BuildingConfig>();
            temp.Prefab = MainController.InstantiatePrefab(config.Prefab);
            temp.Size = config.Size;

            if(_currentFlyBuilding == null)
            _currentFlyBuilding = new Building(temp);
            else
            {
                MainController.Destroy(_currentFlyBuilding.Prefab);
                _currentFlyBuilding = new Building(temp);
            }
        }

        public void SetGridSize(int x, int y)
        {
            _size = new Vector2Int(x, y);
        }

        //заполняет массив билдингов при строительстве
        private void PlaceBuilding(int placeX, int placeY)
        {
            for (int x = 0; x < _currentFlyBuilding.Size.x; x++)
            {
                for (int z = 0; z < _currentFlyBuilding.Size.y; z++)
                {
                    _buildings[placeX + x, placeY + z] = _currentFlyBuilding;
                }
            }

            _currentFlyBuilding = null;
        }

        //проверяет возможность установки
        private bool IsPlaceTaken(int placeX, int placeY)
        {
            for (int x = 0; x < _currentFlyBuilding.Size.x; x++)
            {
                for (int z = 0; z < _currentFlyBuilding.Size.y; z++)
                {
                    if (_buildings[placeX + x, placeY + z] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}