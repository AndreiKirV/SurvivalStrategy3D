using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Utils
{
    [RequireComponent(typeof(EventTrigger))]
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
    }
}