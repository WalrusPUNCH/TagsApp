using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Fabric_Method
{
    public class HardFieldCreator : FieldCreator
    {
        private uint Chance;
        public HardFieldCreator(uint chanceOfRandomCancel) : base("Hard mode")
        {
            Chance = chanceOfRandomCancel;
        }
        public override Field Generate(uint w, uint l)
        {
            return new HardField(w, l, Chance);
        }
    }
}
