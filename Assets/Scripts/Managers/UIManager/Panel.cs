using System;
using System.Collections;
using Controllers;
using TMPro;
using UnityEngine;

namespace Managers
{
    public abstract class Panel : MonoBehaviour, IPanel
    {
        public virtual Action OnPanelClick { get; set; }
        public virtual TextMeshProUGUI TimerText { get; set; }
        public virtual TextMeshProUGUI HealthText { get; set; }
        public virtual void Show(Hashtable args){}
    }
}