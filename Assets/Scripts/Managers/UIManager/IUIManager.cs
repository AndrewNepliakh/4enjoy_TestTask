namespace Managers
{
    public interface IUIManager
    {
        public T ShowPanel<T>(string prefabPath) where T : Panel;
    }
}