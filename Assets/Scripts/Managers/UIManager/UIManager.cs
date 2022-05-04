using System.Collections;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private Transform _mainCanvas;

        public T ShowPanel<T>(string prefabPath, Hashtable args) where T : Panel
        {
            var panelPrefab = Resources.Load<Panel>(prefabPath);
            var panel = Instantiate(panelPrefab, _mainCanvas) as T;
            panel.Show(args);
            return panel;
        }
    }
}