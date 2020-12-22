using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Fabric_Method.Products;

namespace TagsApp.Command
{
    public class MoveTagCommand : ICommand
    {
        private Field field;
        private HistoryCareTaker history;
        private FromToCoords fromTo;

        public MoveTagCommand(FromToCoords _fromTo, Field _field, HistoryCareTaker _history)
        {
            field = _field;
            history = _history;
            fromTo = _fromTo;
        }

        public void Execute()
        {           
            field.MoveTag(fromTo);
            history.Save(field.CreateMemento());
        }
    }
}
