﻿using System;
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
        private static FieldCreator fieldCreator;
        public static ICommand UndoCommand { get; private set; }
        private static UserInputController user;
        private static HistoryCareTaker history;
        private static Field field;
        private static Field winField;
        private static FieldType FieldType;
        //private Core core;

        // private Core()

        //private FieldType returnFieldType(string ans)
        //{
        //    user = new UserInputController();

        //    return (FieldType)(user.ChooseFieldType(ans));
        //}
        public static void Init()
        {
            uint[] size = null;
            while (true)
            {
                PrintOut.PrintMenu();
             
                try
                {
                    string initAns = Console.ReadLine();

                    user = new UserInputController();
                    FieldType = (FieldType)(user.ChooseFieldType(initAns));
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
            history = new HistoryCareTaker();
            UndoCommand = new UndoCommand(history);
            Console.Clear();
        }

        private static void Switch(FieldType ft, uint width, uint length)
        {
            winField = FieldCreator.GenerateWinField(width, length);

            switch (ft)
            {
                case FieldType.RandomField:
                    PrintOut.GetNumOfSwapsText();
                    string numOfSwaps = Console.ReadLine();

                    fieldCreator = new RndFieldCreator(user.GetNumOfSwaps(numOfSwaps));
                    field = fieldCreator.Generate(width, length);
                    break;

                case FieldType.BackwardsField:
                    fieldCreator = new BckwrdFieldCreator();
                    field = fieldCreator.Generate(width, length);
                    break;

                case FieldType.HardField:
                    PrintOut.GetChanceOfRndcancelText();
                    string chanceOfRandomCancel = Console.ReadLine();
                    fieldCreator = new HardFieldCreator(user.GetChanceOfRndCancel(chanceOfRandomCancel));
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
                try
                {
                    PrintOut.ShowTags(field);
                    PrintOut.ShowRules();
                    Console.WriteLine();

                    string ans = Console.ReadLine();
                    if (user.CancelMove(ans.ToLower()))
                    {
                        UndoCommand.Execute();
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
