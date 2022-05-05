namespace Managers
{
    public interface IDailyBonusManager
    {
        bool CheckForDailyBonus(IUserManager userManager);
        long GetCoinsFromDate();
    }
}