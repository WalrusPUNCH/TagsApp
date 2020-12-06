using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Fabric_Method
{
    public class RndFieldCreator:FieldCreator
    {
        private uint NumOfSwaps;
        public RndFieldCreator(uint numOfSwaps) : base("Random creator")
        {
            NumOfSwaps = numOfSwaps;
        }
        public override Field Generate(uint w, uint l)
        {
            var rfield = new RndField(w, l, NumOfSwaps);
            int currentMaxVal = 0;
            int maxValX = 0, maxValY = 0;
            for (int i = 0; i < rfield.Width; i++)
            {
                for (int j = 0; j < rfield.Length; j++)
                {
                    int value = Convert.ToInt32(rfield.Tags[i, j].Name);
                    if (value>currentMaxVal)
                    {
                        maxValX = i;
                        maxValY = j;
                        currentMaxVal = value;
                    }
                }
            }
            rfield.Tags[maxValX, maxValY] = new Tag();

            return rfield;
        }
    }
}

