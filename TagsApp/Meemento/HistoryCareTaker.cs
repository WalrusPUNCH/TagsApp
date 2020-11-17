using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Meemento
{
    public class HistoryCareTaker
    {
        private Stack<IMemento> history;
//        private Field field;
        
        public HistoryCareTaker()
        {
            //field = _field;
        }

        public void Save(IMemento memento)
        {
            history.Push(memento);
        }

        public void Undo()
        {
            history.Pop().Restore();
        }
    }
}
