using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private Transform _mainCanvas;
        
        public T ShowPanel<T>(string prefabPath) where T : Panel
        {
            var panelPrefab = Resources.Load<Panel>(prefabPath);
            var panel = Instantiate(panelPrefab, _mainCanvas) as T;
            return panel;
        }
    }
}