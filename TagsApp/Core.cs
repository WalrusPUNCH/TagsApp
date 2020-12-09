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
        public ICommand UndoCommand { get { return undoCommand; } }
        private UserInputController user;
        private HistoryCareTaker history;
        private Field field;
        public Field Field { get { return field; } }
        private Field winField;
        public Field WinField { get { return winField; } }
        private FieldType FieldType;
        private static Core core;
        private Core() { }
        public static Core GetInstance()
        {
            if(core == null)
            {
                core = new Core();
            }
            return core;
        }

        public FieldType GetFieldType(string ans)
        {
            return (FieldType)(user.ChooseFieldType(ans));
        }

        public uint[] SetFieldSize(string w, string l)
        {
            return user.ChooseFieldSize(w, l);
        }

        public void BeforeTheStart(FieldType ft, uint width, uint length, string ansnumber)
        {
            history = new HistoryCareTaker();

            undoCommand = new UndoCommand(history);

            winField = FieldCreator.GenerateWinField(width, length);

            
        }

        public void CreateRandomF(string numofswaps, uint width, uint length)
        {
            fieldCreator = new RndFieldCreator(user.GetNumOfSwaps(numofswaps));
            field = fieldCreator.Generate(width, length);
        }
        public Field CreateBckwrdF(uint width, uint length)
        {
            fieldCreator = new BckwrdFieldCreator();
            field = fieldCreator.Generate(width, length);
            return field;
        }
        public Field CreateHardF(string ansnumber, uint width, uint length)
        {
            fieldCreator = new HardFieldCreator(user.GetChanceOfRndCancel(ansnumber));
            field = fieldCreator.Generate(width, length);
            return field;
        }
        public void Move(string ans)
        {
            ICommand moveTagCommand = new MoveTagCommand(user.ParseMove(ans), field, history);
            moveTagCommand.Execute();

        }
        public void Undo(string ans)
        {
            undoCommand.Execute();
        }
        //public void Init()
        //{
        //    uint[] size = null;
        //    while (true)
        //    {
        //        PrintOut.PrintMenu();

        //        try
        //        {
        //            string initAns = Console.ReadLine();

        //            user = new UserInputController();

        //            FieldType = (FieldType)(user.ChooseFieldType(initAns));
        //            break;
        //        }
        //        catch (InvalidInputException e)
        //        {
        //            CatchActions(e);
        //        }
        //    }

        //    while (size == null)
        //    {
        //        try
        //        {
        //            PrintOut.CustomizeSizeW();
        //            string w = Console.ReadLine();
        //            PrintOut.CustomizeSizeL();
        //            string l = Console.ReadLine();

        //            size = user.ChooseFieldSize(w, l);
        //        }
        //        catch (Exception e)
        //        {
        //            CatchActions(e);
        //        }
        //    }

        //    Switch(FieldType, size[0], size[1]);

        //    history = new HistoryCareTaker();

        //    undoCommand = new UndoCommand(history);

        //    Console.Clear();
        //}


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
                   //undoCommand.Execute();//if move failed, but memento already created

                    CatchActions(e);
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

       


        //private static void CatchActions(Exception e)
        //{
        //    Console.Clear();
        //    Console.WriteLine(e.Message);
        //    Console.ReadKey();
        //    Console.Clear();
        //}
    }
}
