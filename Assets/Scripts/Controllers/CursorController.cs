using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.Dictionary;

namespace Main.Ui.Cursor
{
    public class CursorController
    {
        public Canvas TargetCanvas;
        private Camera _camera;
        //private RectTransform _mouseRect;
        //private GameObject _cursor = Resources.Load<GameObject>(Dictionaries.Path.UI.Cursor);
        private Plane _plane;
        

        public void Awake() 
        {
        }

        public void Init(Canvas canvas)
        {
            TargetCanvas = canvas;
            //UnityEngine.Cursor.visible = false;
            //_cursor = MainController.InstantiatePrefab(_cursor, TargetCanvas.transform.position, TargetCanvas.transform);
            //_mouseRect = _cursor.GetComponent<RectTransform>();
            //_mouseRect.localRotation = Quaternion.Euler(Vector3.zero);
            _plane = new Plane(Vector3.up , TargetCanvas.transform.position);
            _camera = Camera.main;
        }

        public void Start()
        {
            UnityEngine.Cursor.SetCursor(Resources.Load<Texture2D>("Graphics/Textures/UI/Cursors/Def"), Vector2.zero, CursorMode.Auto);
        }

        public void Update() 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_plane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                //_mouseRect.transform.position = new Vector3(worldPosition.x, TargetCanvas.transform.position.y, worldPosition.z);
            }
        }

    }
}