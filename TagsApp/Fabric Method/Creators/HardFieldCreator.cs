using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Command;

namespace TagsApp.Fabric_Method
{
    public class HardFieldCreator : FieldCreator
    {
        private uint Chance;
        private ICommand undocommand;
        public HardFieldCreator(uint chanceOfRandomCancel, ICommand undo) : base("Hard mode")
        {
            Chance = chanceOfRandomCancel;
            undocommand = undo;
        }
        public override Field Generate(uint w, uint l)
        {
            return new HardField(w, l, Chance, undocommand);
        }
    }
}
