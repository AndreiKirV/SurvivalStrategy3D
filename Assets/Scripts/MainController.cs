using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GWC;
using Main.Dictionary;
using Utils;
using Main.Ui;

namespace Main
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] public List<BuildingsList> _buildings;
        private static List<BuildingsList> _sharedBuildings;

        [SerializeField] private Canvas _currentCanvas;
        private WorldController _worldController = new WorldController();
        private UIController _UIController;


        public static List<BuildingsList> Buildings
        {
            get { return _sharedBuildings; }
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }
        private void Awake()
        {
            _sharedBuildings = _buildings;

            _UIController = new UIController(_currentCanvas);

            _worldController.Awake();
            _UIController.Awake();
            /*
            for (int i = 0; i < _buildings.Count; i++)
            {
                for (int x = 0; x < _buildings[i].Buildings.Count; x ++)
                {
                    _UIController.CreateMenuBuildings();
                }
            }
            */

            _UIController.Init();
        }

        private void Start()
        {
            _worldController.Start();
            _UIController.Start();
        }

        private void Update()
        {
            _worldController.Update();
            _UIController.Update();
        }

        public static void MainDestroy(GameObject tempObject)
        {
            Destroy(tempObject);
        }

        public static GameObject InstantiatePrefab(GameObject temp, Vector3 position, Transform parent)
        {
            return Instantiate<GameObject>(temp, position, Quaternion.identity, parent);
        }

        public static GameObject InstantiatePrefab(GameObject temp, Vector3 position)
        {
            return Instantiate<GameObject>(temp, position, Quaternion.identity);
        }

        public static GameObject InstantiatePrefab(GameObject temp)
        {
            return Instantiate<GameObject>(temp);
        }
    }
}