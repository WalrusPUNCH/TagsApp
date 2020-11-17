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
    }


    //public IMemento CreateMapMemento()
    //{
    //    return null;
    //}
}
