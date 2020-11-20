using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Command;
using TagsApp.Fabric_Method;
using TagsApp.Meemento;

namespace TagsApp
{
    public enum FieldType
    {
        randomField,
        backwardsField,
        hardField
    }

    public static class Core
    {
        private static FieldCreator fieldCreator;
        private static ICommand moveTagCommand;
        private static ICommand undoCommand;
        private static UserInputController user;
        private static HistoryCareTaker history;
        private static Field field;
        private static Field winField;
        private static FieldType FieldType;
        //private Core core;

       // private Core()

        public static void Init()
        {
            user = new UserInputController();

            FieldType = (FieldType)(user.ChooseFieldType()-1);

            uint[] size = user.ChooseFieldSize();

            Switch(FieldType, size[0], size[1]);
            
            history = new HistoryCareTaker();

            undoCommand = new UndoCommand(history);            
        }

        private static void Switch(FieldType ft, uint width, uint length)
        {
            switch (ft)
            {
                case FieldType.randomField:
                    uint numOfSwaps = user.GetNumOfSwaps();
                    fieldCreator = new RndFieldCreator(numOfSwaps);
                    field = fieldCreator.Generate(width, length);
                    break;
                case FieldType.backwardsField:
                    fieldCreator = new BckwrdFieldCreator();
                    field = fieldCreator.Generate(width, length);
                    break;
                case FieldType.hardField:
                    uint chanceOfRandomCancel = user.GetChanceOfRndCancel();
                    fieldCreator = new HardFieldCreator(chanceOfRandomCancel);
                    field = fieldCreator.Generate(width, length);
                    break;
                default:
                    field = FieldCreator.GenerateWinField(width, length);
                    break;
            }
        }
        public static void MainLoop()
        {
            while (field != winField)
            {
                
            }
        }
        
    }
}
