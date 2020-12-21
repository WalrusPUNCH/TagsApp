using System;

namespace TagsApp.Fabric_Method.Products
{
    public class RndField : Field
    {
        public RndField(uint w, uint l, uint numOfSwaps) : base(w, l)
        {
            Random rand = new Random();
            for (int i = 0; i < numOfSwaps; i++)
            {
                int x1, x2, y1, y2;
                do
                {
                    x1 = rand.Next(0, (int)Width);
                    x2 = rand.Next(0, (int)Width);
                    y1 = rand.Next(0, (int)Length);
                    y2 = rand.Next(0, (int)Length);
                    
                } while (x1 == x2 && y1 == y2);
                FromToCoords fromToCoords = new FromToCoords((uint)x1, (uint)y1, (uint)x2, (uint)y2);

                SwapTags(fromToCoords);
            }
        }
    }
}
