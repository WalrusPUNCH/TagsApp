using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Command;

namespace TagsApp.Meemento
{
    public class HistoryCareTaker
    {
        private Stack<IMemento> history;
        private Stack<ICommand> commandHistory;
        
        public HistoryCareTaker()
        {
            history = new Stack<IMemento>();
            commandHistory = new Stack<ICommand>();
        }

        public void Save(IMemento memento, ICommand command)
        {
            history.Push(memento);
            commandHistory.Push(command);
        }
        
        public void Undo()
        {
            if (history.Count == 0)
            {
                throw new InvalidOperationException("no move to cancel");
            }
            history.Pop().Restore();
            commandHistory.Pop();

        }
    }
}
