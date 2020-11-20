using System;

namespace TagsApp
{
    public static class Utils
    {
        public static string indexToChar(int n)
        {
            string res = "";
            int next = 1, val;
            while (next != 0)
            {
                next = n / 10;
                val = n - next * 10;
                switch (val) { 
                    case 0:
                        res += 'A';
                        break;
                    case 1:
                        res += 'B';
                        break;
                    case 2:
                        res += 'C';
                        break;
                    case 3:
                        res += 'D';
                        break;
                    case 4:
                        res += 'E';
                        break;
                    case 5:
                        res += 'F';
                        break;
                    case 6:
                        res += 'G';
                        break;
                    case 7:
                        res += 'H';
                        break;
                    case 8:
                        res += 'I';
                        break;
                    case 9:
                        res += 'J';
                        break;
                }
                n = next;
            }
            return res;
        }

        internal static uint CharToIndex(char h)
        {
            uint res = 0;
            int next = 1, val;
            switch (h)
                {
                    case 'A':
                        res = 0;
                        break;
                    case 'B':
                        res = 1;
                        break;
                    case 'C':
                        res = 2;
                        break;
                    case 'D':
                        res = 3;
                        break;
                    case 'E':
                        res = 4;
                        break;
                    case 'F':
                        res = 5;
                        break;
                    case 'G':
                        res = 6;
                        break;
                    case 'H':
                        res = 7;
                        break;
                    case 'I':
                        res = 8;
                        break;
                    case 'J':
                        res = 9;
                        break;
                    default: 
                        res = 0;
                        break;
                }
           
            return res;
        }
    }
}
