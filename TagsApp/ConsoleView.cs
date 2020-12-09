using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public class ConsoleController
    {
        private Core core = Core.GetInstance();
        private FieldType fieldType;

        public void Init()
        {
            uint[] size = null;
            while (true)
            {
                PrintOut.PrintMenu();
                try
                {
                    string initAns = Console.ReadLine();
                    fieldType = core.GetFieldType(initAns);
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

                    size = core.SetFieldSize(w, l);
                }
                catch (Exception e)
                {
                    CatchActions(e);
                }
            }
            
            hzchtoproishodit(fieldType, size[0], size[1]);
            Console.Clear();
        }
        //enum Answer
        //{
        //    cancel,
        //    giveup
        //}
        public void MainLoop()
        {
            while (core.Field != core.WinField)
            {
                try
                {
                    PrintOut.ShowTags(core.Field);
                    PrintOut.ShowRules();
                    Console.WriteLine();

                    string ans = Console.ReadLine().ToLower();
                    //var ansinenum = Enum.GetNames(typeof(Answer));

                    //foreach(var i in ansinenum)
                    //{
                    //    if (i == ans)
                    //    {
                    switch (ans)
                    {
                        case "cancel":
                            core.Undo(ans);
                            Console.Clear();
                            continue;
                        case "give up":
                            PrintOut.Restart();
                            break;
                        default:
                            core.Move(ans);
                            break;                   
                    }
                   
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

            if (core.Field == core.WinField)
            {
                PrintOut.Win();
            }
        }

        public Field hzchtoproishodit(FieldType ft, uint w, uint l)
        {
            switch (ft)
            {
                case FieldType.randomField:
                    PrintOut.GetNumOfSwapsText();
                    string numofswaps = Console.ReadLine();
                   // var field = core.CreateRandomF(numofswaps, w, l);
                    break;

                case FieldType.backwardsField:

                    break;

                case FieldType.hardField:
                    PrintOut.GetChanceOfRndcancelText();


                    break;

                default:
                    field = FieldCreator.GenerateWinField(width, length);
                    break;
            }
            return field;
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
