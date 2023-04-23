using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using GWC;
using Main;
using Main.Dictionary;
using Main.Ui.Cursor;

namespace Main.Ui
{

    public class UIController
    {
        public Canvas TargetCanvas;
        private GameObject _button = Resources.Load<GameObject>(Dictionaries.Path.UI.Button);
        private List <Button> _buttons = new List<Button>();
        private GameObject _content;
        private Camera _camera;
        private BuildingStore _buildingsStore;
        private CursorController _cursor = new CursorController();
        public UIController(Canvas canvas)
        {
            TargetCanvas = canvas;
        }

        public void Init()
        {
            _buildingsStore = new BuildingStore(TargetCanvas);
            _buildingsStore.Init();

            
            _cursor.Init(TargetCanvas);
        }

        public void Awake()
        {
            _camera = Camera.main;
            //CreateContainerMenuBuildings();  

            _cursor.Awake();
        }

        public void Start()
        {
            _cursor.Start();
        }

        public void Update()
        {
            _cursor.Update();
        }
        /*
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
        */
    }
}