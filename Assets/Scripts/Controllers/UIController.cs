using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using GWC;
using Main;
using Main.Dictionary;

namespace Main.Ui
{

    public class UIController
    {
        public Canvas TargetCanvas;
        private GameObject _button = Resources.Load<GameObject>(Dictionaries.Path.UI.Button);
        private List <Button> _buttons = new List<Button>();
        private GameObject _content;
        private GameObject _cursor = Resources.Load<GameObject>(Dictionaries.Path.UI.Cursor);
        private RectTransform _mouseRect;
        private Camera _camera;
        private Plane _plane;
        private BuildingStore _buildingsStore;

        public UIController(Canvas canvas)
        {
            TargetCanvas = canvas;
        }

        public void Init()
        {
            Cursor.visible = false;
            _cursor = MainController.InstantiatePrefab(_cursor, TargetCanvas.transform.position, TargetCanvas.transform);
            _mouseRect = _cursor.GetComponent<RectTransform>();
            _mouseRect.localRotation = Quaternion.Euler(Vector3.zero);

            _buildingsStore = new BuildingStore(TargetCanvas);
            _buildingsStore.Init();
        }

        public void Awake()
        {
            _camera = Camera.main;
            _plane = new Plane(Vector3.up , TargetCanvas.transform.position);
            //CreateContainerMenuBuildings();  
        }

        public void Start()
        {

        }

        public void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_plane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                _mouseRect.transform.position = new Vector3(worldPosition.x, TargetCanvas.transform.position.y, worldPosition.z);
            }
        }

        public void CreateMenuBuildings()
        {
           GameObject temoGameObject = MainController.InstantiatePrefab(_button, Vector3.zero, _content.transform);
           RectTransform tempRect = temoGameObject.GetComponent<RectTransform>();
           tempRect.localRotation = Quaternion.Euler(Vector3.zero);
           tempRect.localPosition = Vector3.zero;

           _buttons.Add(temoGameObject.GetComponent<Button>());
        }

        private void CreateContainerMenuBuildings()
        {
            _content = MainController.InstantiatePrefab(Resources.Load<GameObject>(Dictionaries.Path.UI.ScrollView), Vector3.zero, TargetCanvas.gameObject.transform);  
            RectTransform tempRect = _content.GetComponent<RectTransform>();
            tempRect.localRotation = Quaternion.Euler(Vector3.zero);
            tempRect.localPosition = Vector3.zero;
            tempRect.offsetMin = Vector2.zero;
            tempRect.offsetMax = Vector2.zero;
        }
    }
}