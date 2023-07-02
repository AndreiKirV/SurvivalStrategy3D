using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.Dictionary;

namespace Main.Ui.Cursor
{
    public class CursorController
    {
        private RaycastHit[] _points;
        private Canvas TargetCanvas;
        private Camera _camera;
        private GameObject _cursor = Resources.Load<GameObject>(Dictionaries.Path.UI.Cursor);
        private RectTransform _cursorTransform;

        public RaycastHit[] Points => _points;


        public void Awake()
        {
            _camera = Camera.main;
        }

        public void Init(Canvas canvas)
        {
            TargetCanvas = canvas;
            UnityEngine.Cursor.visible = false;
            _cursor = MainController.InstantiatePrefab(_cursor, Vector3.zero, TargetCanvas.transform);
            _cursorTransform = _cursor.GetComponent<RectTransform>();
            _cursorTransform.anchoredPosition3D = Vector3.zero;
            _cursorTransform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        public void Start()
        {

        }

        public void Update()
        {
            Vector2 mousePosition = Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(TargetCanvas.transform as RectTransform, mousePosition, TargetCanvas.worldCamera, out Vector2 localPoint);
            _cursorTransform.localPosition = localPoint;

            GetRayCollisions();
        }

        private void GetRayCollisions()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            _points = Physics.RaycastAll(ray);
        }

        public Vector3? GiveTerrainPoint()
        {
            if (_points != null && _points.Length > 0)
            {
                for (int i = 0; i < _points.Length; i++)
                {
                    if (_points[i].transform.gameObject.layer == LayerMask.NameToLayer(Dictionaries.Layers.Terrain))
                    {
                        return _points[i].point;
                    }
                }
            }

            return null;
        }
    }
}