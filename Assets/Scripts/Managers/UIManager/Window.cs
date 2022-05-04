using System;
using System.Collections;
using Controllers.FloatingWindow;
using TMPro;
using UnityEngine;

namespace Managers
{
    public abstract class Window : MonoBehaviour, IWindow
    {
        public virtual Action OnClose { get; set; }

        public virtual TextMeshProUGUI TimerText { get; set; }
        public virtual TextMeshProUGUI HealthText { get; set; }
        
        public virtual void Show(Hashtable args)
        {
        }
        
        public virtual void Close()
        {
            OnClose?.Invoke();
        }
    }
}