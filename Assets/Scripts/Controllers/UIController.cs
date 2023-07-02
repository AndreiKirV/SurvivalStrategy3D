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
        private Camera _camera;
        private BuildingStore _buildingsStore;
        public static CursorController _cursor = new CursorController();

        public static CursorController Cursor => _cursor;

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
    }
}