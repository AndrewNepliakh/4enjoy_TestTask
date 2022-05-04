namespace Managers
{
    public interface ITimer
    {
        void Init(IUserManager userManager);
        string CalculateTime();
    }
}