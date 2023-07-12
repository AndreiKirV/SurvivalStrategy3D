using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GWC;
using Main.Dictionary;
using Utils;
using Main.Ui;
using Buildings;
using TMPro;

namespace Main
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] public List<BuildingsList> _buildings;
        [SerializeField] private TextMeshProUGUI _text;
        private static List<BuildingsList> _sharedBuildings;

        [SerializeField] private Canvas _currentCanvas;
        private WorldController _worldController = new WorldController();
        private TimeController _timer = new TimeController();
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
            _timer.Start();
        }

        private void Update()
        {
            _worldController.Update();
            _UIController.Update();
            _timer.Update();
            _text.text = $"{(int)_timer.CurrentTime / 60} : {(int)_timer.CurrentTime % 60}";
        }

        public static void MainDestroy(GameObject tempObject)
        {
            Destroy(tempObject);
        }

        public static GameObject InstantiatePrefab(GameObject temp, Vector3 position, Transform parent)
        {
            GameObject tempGameObject = Instantiate<GameObject>(temp, position, Quaternion.identity, parent);
            tempGameObject.name = temp.name;
            return tempGameObject;
        }

        public static GameObject InstantiatePrefab(GameObject temp, Vector3 position)
        {
            GameObject tempGameObject = Instantiate<GameObject>(temp, position, Quaternion.identity);
            tempGameObject.name = temp.name;
            return tempGameObject;
        }

        public static GameObject InstantiatePrefab(GameObject temp)
        {
            GameObject tempGameObject = Instantiate<GameObject>(temp);
            tempGameObject.name = temp.name;
            return tempGameObject;
        }

        //temp

        public void CreateFlyBuilding(BuildingConfig config)
        {
            _worldController.CreateFlyBuilding(config);
        }
    }
}