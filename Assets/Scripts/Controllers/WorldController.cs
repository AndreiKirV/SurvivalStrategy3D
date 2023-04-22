using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Buildings;
using Utils;
using Main;

namespace GWC
{
    public class WorldController
    {
        private BuildingController _buildingController;

        public void Awake()
        {
            _buildingController = new BuildingController();
            _buildingController.SetGridSize(15,15);
            _buildingController.Awake();
        }
        
        public void Start()
        {
            _buildingController.Start();
        }

        public void Update()
        {
            _buildingController.Update();
        }

        public void CreateFlyBuilding(BuildingConfig config)
        {
            _buildingController.CreateFlyBuilding(config);
        }

        public static void Destroy(GameObject tempObject)
        {
            MainController.MainDestroy(tempObject);
        }

        public static GameObject InstantiatePrefab(GameObject temp, Vector3 position)
        {
            return MainController.InstantiatePrefab(temp, position);
        }

        public static GameObject InstantiatePrefab(GameObject temp)
        {
            return MainController.InstantiatePrefab(temp);
        }
    }
}