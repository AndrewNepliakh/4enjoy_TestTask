using System.Collections;

namespace Managers
{
    public interface IUIManager
    {
        public T ShowPanel<T>(string prefabPath, Hashtable args) where T : Panel;
    }
}