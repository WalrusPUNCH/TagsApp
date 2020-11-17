using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Fabric_Method
{
    public class RndFieldCreator:FieldCreator
    {
        //1 generate random map 
        //2 find the biggest digit(coords)
        //3 replace it with the Tag.Empty
        private uint NumOfSwaps;
        public RndFieldCreator(uint numOfSwaps) : base("Random creator")
        {
            NumOfSwaps = numOfSwaps;
        }
        public override Field Generate(uint w, uint l)
        {
            var bfield = new RndField(w, l, NumOfSwaps);
            int currentMaxVal = 0;
            int maxValX = 0, maxValY = 0;
            for (int i = 0; i < bfield.Width; i++)
            {
                for (int j = 0; j < bfield.Length; j++)
                {
                    int value = Convert.ToInt32(bfield.Tags[i, j].Name);
                    if (value>currentMaxVal)
                    {
                        maxValX = i;
                        maxValY = j;
                        currentMaxVal = value;
                    }
                }
            }
            bfield.Tags[maxValX, maxValY] = new Tag();

            return bfield;
        }
    }
}

