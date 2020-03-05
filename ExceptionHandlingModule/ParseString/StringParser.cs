using System;

namespace ParseString
{
    public class StringParser
    {
        public int ParseToInt(string s)
        {
            const string LookupTable = "0123456789";
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int charValue = LookupTable.IndexOf(s[i]);
                if (charValue == -1)
                {
                    throw new FormatException();
                }
                result = (result * 10) + charValue;
            }
            return result;
        }
    }
}
