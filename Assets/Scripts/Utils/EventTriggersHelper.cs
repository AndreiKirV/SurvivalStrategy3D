using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Utils
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EventTriggersHelper : MonoBehaviour
    {
        public UnityEvent PointerEnter;
        public UnityEvent PointerExit;

        public void PointerEnterInvoke()
        {
            PointerEnter?.Invoke();
        }

        public void  PointerExitInvoke()
        {
            PointerExit?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            Debug.Log("Enter");
            PointerEnter?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            Debug.Log("Exit");
            PointerExit?.Invoke();
        }
    }
}