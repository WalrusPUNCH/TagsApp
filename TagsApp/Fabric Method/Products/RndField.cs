using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Fabric_Method
{
    public class RndField : Field
    {
        public RndField(uint w, uint l, uint numOfSwaps) : base(w, l)
        {
            Random rand = new Random();
            for (int i = 0; i < numOfSwaps; i++)
            {
                int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
                while (true)
                {
                    if (x1 == x2 && y1 == y2)
                    {
                        x1 = rand.Next(0, WidthInt);
                        x2 = rand.Next(0, WidthInt);
                        y1 = rand.Next(0, LengthInt);
                        y2 = rand.Next(0, LengthInt);
                        continue;
                    }
                    break;
                }
                var temp = Tags[x1, y1];
                Tags[x1, y1] = Tags[x2, y2];
                Tags[x2, y2] = temp;
            }
        }
    }
}
