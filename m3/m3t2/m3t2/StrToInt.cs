using System;
using System.ComponentModel;

namespace m3t2
{
    public class StrToInt
    {
        private readonly char[] sNums = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        public void DoParse(String str, out int outputNum)
        {
            if (IsEmpty(str))
            {
                throw new Exception("Empty string");
            }

            Boolean isNegative = str[0] == '-'? true: false;
            if (isNumber(str, isNegative)==false)
            {
                throw new Exception("String consist non-numeric symbol");
            }
            outputNum = DoConvert(str, isNegative);
        }

        public int DoConvert(string str, Boolean isNegative=false)
        {
            int numberOutput = 0;
            int digit = isNegative? str.Length-1: str.Length;
            for (int i = isNegative? 1:0; i<str.Length; i++)
            {
                if (digit>=0)
                {
                    numberOutput += (int)(str[i] - '0') * Convert.ToInt32(Math.Pow(10.0, digit - 1));
                    digit--;                }
            }

            return isNegative? -numberOutput:+numberOutput ;
        }

        //returns true if string is null or empty
        public Boolean IsEmpty(String str)
        {
            Boolean isEmpty = false;
            if (str == null | str == "" )
            {
                isEmpty = true;
            }

            return isEmpty;
        }
        //returns true if string consist only numbers 
        public Boolean isNumber(string str, Boolean isNegative = false)
        {
            Boolean isNumber = false;
            char sChar;
            int iStart = isNegative? 1: 0;
            for (int i = iStart; i<str.Length; i++)
            {
                isNumber = false;
                sChar = Convert.ToChar(str[i]);
                for (int j = 0; j<sNums.Length; j++)
                {
                    if (sChar == sNums[j])
                    {
                        isNumber = true;
                        break;
                    }
                }
                if (isNumber == false)
                {
                    break;
                }
            }
            return isNumber;
        }
    }
}
