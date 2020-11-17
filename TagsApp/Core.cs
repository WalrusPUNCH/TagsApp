using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Command;
using TagsApp.Meemento;

namespace TagsApp
{
    public static class Core
    {
        private static FieldCreator fieldCreator;
        private static MoveTagCommand moveTagCommand;
        private static UndoCommand undoCommand;
        private static UserInputController user;
        private static HistoryCareTaker history;
        //private Core core;

       // private Core()

        public static void Init()
        {
            
        }

    }
}
