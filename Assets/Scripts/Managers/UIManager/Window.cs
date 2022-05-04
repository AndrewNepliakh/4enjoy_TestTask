using System;
using System.Collections;
using UnityEngine;

namespace Managers
{
    public class Window : MonoBehaviour
    {
        public Action OnClose;
        
        public virtual void Show(Hashtable args)
        {
        }
        
        public virtual void Close()
        {
            OnClose?.Invoke();
        }
    }
}