namespace Managers
{
    public interface ITimer
    {
        void Init(UserManager userManager);
        string CalculateTime();
    }
}