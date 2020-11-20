using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public  class UserInputController
    {

        //callMenu();

        public void ShowTags(Field f)
        {
            Console.Write("|   |");

            for (int j = 1; j <= f.Length; j++)
            {
                Console.Write("{0, 3}|", j);
            }
            Console.Write("\n");

            for (int j = 1; j <= f.Length; j++)
            {
                Console.Write("+---", j);
            }
            Console.Write("+----\n");

            for (int i = 0; i < f.Width; i++)
            {
                Console.Write("|{0, 3}|", Utils.indexToChar(i));
                for (int j = 0; j < f.Length; j++)
                {
                    if (f.Tags[i, j].Name == Tag.Empty)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("{0, 3}", f.Tags[i, j].Name);
                        Console.ResetColor();
                        Console.Write("|");
                        continue;
                    }
                    Console.Write("{0, 3}|", f.Tags[i, j].Name);

                }
                Console.Write("\n");
            }
        }
        public uint ChooseFieldType()
        {
            Console.WriteLine("There are 3 variants of gameplay. " +
                "\n choose one:");
            uint fieldType = Convert.ToUInt32(Console.ReadLine());
            Console.ReadKey();
            return fieldType;
        }
        public uint[] ChooseFieldSize()
        {
            Console.WriteLine("You can customize the field size. " 
                +"\n input width and lenght:");
            uint width = Convert.ToUInt32(Console.ReadLine());
            Console.ReadKey();
            uint length = Convert.ToUInt32(Console.ReadLine());
            Console.ReadKey();
            uint[] FieldSize = new uint[2] { width, length };
            return FieldSize;
        }
        public uint GetNumOfSwaps()
        {
            Console.WriteLine("You are about to have a randomly mixed field. " +
                "\nThe more you input, the harder it will be to solve the game." +
                "\nInput a number of random swaps:  ");
            uint numOfSwaps = Convert.ToUInt32(Console.ReadLine());
            Console.ReadKey();
            return numOfSwaps;
        }

        public uint GetChanceOfRndCancel()
        {
            Console.WriteLine("It's a hard mode. There's a chance your move will be randomly canceled. " +
                "\n The higher number you input, the lower chance it will get" +
                "\n input number:");
            uint chanceOfRndCancel = Convert.ToUInt32(Console.ReadLine());
            Console.ReadKey();
            return chanceOfRndCancel;
        }

        public FromToCoords ParseMove()
        {
            Console.WriteLine("input coords в формате а1 б2:");
            uint[] coords = new uint[4] { 0,0,0,0};
            int counter = 0;
            char[] mas = Console.ReadLine().ToUpper().ToCharArray();          
            foreach (char h in mas)
            {
                if (h == ' ')
                {   
                    counter+=2;
                    if (counter >2)
                    {
                        break;
                    }
                }
                else if (char.IsDigit(h) == true)
                {
                    coords[counter+1] = coords[counter+1] * 10 + Convert.ToUInt32(h.ToString());
                }
                else
                {
                    coords[counter] = coords[counter] * 10 + Utils.CharToIndex(h);
                }
            }
            return new FromToCoords(coords[0], coords[1], coords[2], coords[3]);
        }

        public bool CancelMove(string ans)
        {
             //= Console.ReadLine().ToLower();
            if (ans == "cancel")
            {
                return true;
            }
            return false;
            //else
            //{
            //    throw new InvalidInputException("Please, type in coords as in example. " +
            //        "\nIf you want to cancel move, type 'cancel'");
            //}
        }

        public bool GiveUp(string ans)
        {
             //= Console.ReadLine().ToLower();
            if (ans == "give up")
            {
                return true;
            }
            return false;
            //else
            //{
            //    throw new InvalidInputException("Please, type in coords as in example. " +
            //        "\nIf you want to give up, type 'give up'");
            //}
        }
    }

}
