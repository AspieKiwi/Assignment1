using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUniversal
{
    public static class clsBookStoreUtility
    {
        public static bool CheckDecimalValue(string prValue)
        {
            decimal lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!decimal.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult <= 0)
                    return false;
            }
            return true;
        }

        public static bool CheckIntValue(string prValue)
        {
            int lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!int.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult < 0)
                    return false;
            }
            return true;
        }

        public static bool CheckFloatValue(string prValue)
        {
            float lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!float.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult <= 0)
                    return false;
            }
            return true;
        }
    }
}
