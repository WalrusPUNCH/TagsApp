using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Fabric_Method
{
    public class HardField : Field
    {
        private uint Chance;
        public HardField(uint w, uint l, uint chanceOfRandomCancel) :base(w, l)
        {
            Name = "bckwrd";
            Tags[w-1, l-1] = new Tag();
            Chance = chanceOfRandomCancel;
            try
            {
                base.MoveTag(new FromToCoords(w - 1, l - 1, w - 1, l - 2));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public new void MoveTag(FromToCoords fromTo)//overloaded func, can cancel users move
        {
            throw new NotImplementedException("to do");
        }
    }
}
