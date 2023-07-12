using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class TimeController
    {
        private float _currentTime = 0;
        private float _speedTime = 1;

        public float CurrentTime => _currentTime;
        public float SpeedTime => _speedTime;

        public void Start() 
        {
            
        }

        public void Update()
        {
            _currentTime += Time.deltaTime * _speedTime;
        }
    }
}