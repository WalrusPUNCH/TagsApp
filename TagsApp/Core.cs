using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Command;
using TagsApp.Fabric_Method;
using TagsApp.Fabric_Method.Creators;
using TagsApp.Fabric_Method.Products;

namespace TagsApp
{
    public static class Core
    {
        private static FieldCreator _fieldCreator;
        public static ICommand UndoCommand { get; private set; }
        private static UserInputController user;
        private static HistoryCareTaker history;
        private static Field field;
        private static Field winField;
        private static FieldType FieldType;
        
        public static void Init()
        {
            history = new HistoryCareTaker();
            UndoCommand = new UndoCommand(history);
            user = new UserInputController();
            
            ChooseFieldType();
            uint[] size = ChooseFieldSize();
            
            CreateField(FieldType, size[0], size[1]);
            Console.Clear();
        }

        private static uint[] ChooseFieldSize()
        {
            uint[] size = null;

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

            return size;
        }
        private static void ChooseFieldType()
        {
            while (true)
            {
                PrintOut.PrintMenu();
                try
                {
                    string initAns = Console.ReadLine();

                    FieldType = (FieldType)user.ChooseFieldType(initAns);
                    break;
                }
                catch (InvalidInputException e)
                {
                    CatchActions(e);
                }
            }
        }
        private static void CreateField(FieldType ft, uint width, uint length)
        {
            winField = FieldCreator.GenerateWinField(width, length);

            switch (ft)
            {
                case FieldType.RandomField:
                    PrintOut.GetNumOfSwapsText();
                    string numOfSwaps = Console.ReadLine();

                    _fieldCreator = new RndFieldCreator(user.GetNumOfSwaps(numOfSwaps));
                    field = _fieldCreator.Generate(width, length);
                    break;

                case FieldType.BackwardsField:
                    _fieldCreator = new BckwrdFieldCreator();
                    field = _fieldCreator.Generate(width, length);
                    break;

                case FieldType.HardField:
                    PrintOut.GetChanceOfRndcancelText();
                    string chanceOfRandomCancel = Console.ReadLine();
                    _fieldCreator = new HardFieldCreator(user.GetChanceOfRndCancel(chanceOfRandomCancel));
                    field = _fieldCreator.Generate(width, length);
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
                try
                {
                    PrintOut.ShowTags(field);
                    PrintOut.ShowRules();
                    Console.WriteLine();

                    string ans = Console.ReadLine()?.ToLower();
                    
                    if (ans.Equals(UserInputController.CancelCommand))
                    {
                        try
                        {
                            UndoCommand.Execute();
                            Console.Clear();
                            continue;
                        }
                        catch (InvalidOperationException e)
                        {
                            CatchActions(e);
                        }
                        
                    }
                    else if (ans.Equals(UserInputController.GiveUpCommand))
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
                    UndoCommand.Execute();//if move failed, but memento already created
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
