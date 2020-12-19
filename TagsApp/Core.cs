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

    public class Core
    {
        private FieldCreator fieldCreator;
        private ICommand undoCommand;
        private UserInputController user;
        private HistoryCareTaker history;
        private Field field;
        private Field winField;
        private FieldType FieldType;
        private static Core core;

        private Core()
        {
            history = new HistoryCareTaker();
            undoCommand = new UndoCommand(history);
        }

        public static Core GetInstance()
        {
            if (core == null)
            {
                core = new Core();
            }
            return core;
        }
        private FieldType returnFieldType(string ans)
        {
            user = new UserInputController();

            return (FieldType)(user.ChooseFieldType(ans));
        }
        public void Init()
        {
            uint[] size = null;
            while (true)
            {
                PrintOut.PrintMenu();             
                try
                {
                    string initAns = Console.ReadLine();
                    returnFieldType(initAns);
                    break;
                }
                catch (InvalidInputException e)
                {
                    CatchActions(e);
                }
            }

            while (size == null)
            {
                try
                {
                    PrintOut.CustomizeSizeW();
                    string w = Console.ReadLine();
                    PrintOut.CustomizeSizeL();
                    string l = Console.ReadLine();

                    size = user.ChooseFieldSize(w, l);
                }
                catch (Exception e)
                {
                    CatchActions(e);
                }
            }
            
            Switch(FieldType, size[0], size[1]);
            Console.Clear();
        }

        private void Switch(FieldType ft, uint width, uint length)
        {
            winField = FieldCreator.GenerateWinField(width, length);

            switch (ft)
            {
                case FieldType.randomField:
                    PrintOut.GetNumOfSwapsText();
                    string numOfSwaps = Console.ReadLine();

                    fieldCreator = new RndFieldCreator(user.GetNumOfSwaps(numOfSwaps));
                    field = fieldCreator.Generate(width, length);
                    break;

                case FieldType.backwardsField:
                    fieldCreator = new BckwrdFieldCreator();
                    field = fieldCreator.Generate(width, length);
                    break;

                case FieldType.hardField:
                    PrintOut.GetChanceOfRndcancelText();

                    string chanceOfRandomCancel = Console.ReadLine();
                    fieldCreator = new HardFieldCreator(
                        user.GetChanceOfRndCancel(chanceOfRandomCancel), undoCommand);
                    field = fieldCreator.Generate(width, length);
                    break;

                default:
                    field = FieldCreator.GenerateWinField(width, length);
                    break;
            }
        }
        public void MainLoop()
        {
            while (field != winField)
            {
                try
                {
                    PrintOut.ShowTags(field);
                    PrintOut.ShowRules();
                    Console.WriteLine();

                    string ans = Console.ReadLine();
                    if (user.CancelMove(ans.ToLower()))
                    {
                        undoCommand.Execute();
                        Console.Clear();
                        continue;
                    }
                    if (user.GiveUp(ans.ToLower()))
                    {
                        PrintOut.Restart();
                        break;
                    }

                    ICommand moveTagCommand = new MoveTagCommand(user.ParseMove(ans), field, history);
                    moveTagCommand.Execute();
                    Console.Clear();
                }
                catch (InvalidOperationException e)
                {
                    CatchActions(e);
                    undoCommand.Execute();//if move failed, but memento already created
                }
                catch (Exception e)
                {
                    CatchActions(e);
                }
            }

            if(field == winField)
            {
                PrintOut.Win();
            }
        }
        private static void CatchActions(Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
