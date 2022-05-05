using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Managers
{
    public class DailyBonusManager : IDailyBonusManager
    {
        public bool CheckForDailyBonus(IUserManager userManager)
        {
            if (userManager.CurrentUser.PresentTime.Date == DateTime.Now.Date) return false;
            userManager.CurrentUser.PresentTime = DateTime.Now;
            return true;
        }

        public long GetCoinsFromDate()
        {
            var seasonDay = 0;
            var data = DateTime.Now;
            var seasonMonth = new int[3];
            var month = new GregorianCalendar().GetMonth(data);

            switch (month)
            {
                case 12:
                case 1:
                case 2:
                    seasonMonth = new[] { 12, 1, 2 };
                    break;
                case 3:
                case 4:
                case 5:
                    seasonMonth = new[] { 3, 4, 5 };
                    break;
                case 6:
                case 7:
                case 8:
                    seasonMonth = new[] { 6, 7, 8 };
                    break;
                case 9:
                case 10:
                case 11:
                    seasonMonth = new[] { 9, 10, 11 };
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            for (var i = 0; i < 2; i++)
            {
                if (seasonMonth[i] == month) break;
                seasonDay += new GregorianCalendar().GetDaysInMonth(DateTime.Now.Year, seasonMonth[i]);
            }

            seasonDay += new GregorianCalendar().GetDayOfMonth(data);
            
            var coinsValue = 1.0;
            var coinsValues = new long[seasonDay];

            for (var i = 1; i <= seasonDay; i++)
            {
                if (i < 3)
                {
                    coinsValue++;
                    coinsValues[i - 1] = (int)coinsValue;
                    continue;
                }

                coinsValue = coinsValues[i - 3] + coinsValues[i - 2] * 0.6f;
                coinsValues[i - 1] = (long)Math.Round(coinsValue);
            }
            
            return coinsValues[seasonDay - 1];
        }
    }
}