using System;
using System.Collections.Generic;

namespace TagsApp.Command
{
    public class HistoryCareTaker
    {
        private readonly Stack<IMemento> _history;

        public HistoryCareTaker()
        {
            _history = new Stack<IMemento>();
        }
        public void Save(IMemento memento)
        {
            _history.Push(memento);
        }
        public void Undo()
        {
            if (_history.Count == 0)
            {
                throw new InvalidOperationException("no move to cancel");
            }
            _history.Pop().Restore();
        }
    }
}
