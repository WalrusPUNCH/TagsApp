using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace TagsApp
{
    public struct FromToCoords
    {
        public FromToCoords(uint fx, uint fy, uint tx, uint ty)
        {
            fromX = fx;
            fromY = fy;
            toX = tx;
            toY = ty;
        }
        public uint fromX;
        public uint fromY;
        public uint toX;
        public uint toY;
    }

    public class Field
    {
        private string name;
        private uint length;
        private uint width;
        private Tag[,] tags;

        public string Name { set { name = value; } get { return name; } }
        public uint Length { set { length = value; } get { return length; } }
        public uint Width { set { width = value; } get { return width; } }
        public Tag[,] Tags { set { tags = value; } get { return tags; } }

        public Field(string _name, uint w, uint l)
        {
            this.name = _name;
            this.width = w;
            this.length = l;
            this.tags = new Tag[w,l];
        }


        /*
         * throws exeptions on invalid moves or out of order
         * on sucssess checks moves swaps tags
         */
        public void MoveTag(FromToCoords fromTo)
        {
            if (Ceiling(Sqrt(Convert.ToDouble((fromTo.fromX - fromTo.toX) ^ 2 + (fromTo.fromY - fromTo.toY) ^ 2))) > 2)
            {
                throw new InvalidOperationException("too far. choose a closer tag");
            }
            else
            {
                if (fromTo.fromX == fromTo.toX && fromTo.fromY == fromTo.toY)
                {
                    throw new InvalidOperationException("same tags");
                }

                if (Tags[fromTo.fromX, fromTo.fromY].Name != "x" && Tags[fromTo.toX, fromTo.toY].Name != "x")
                {
                    throw new InvalidOperationException("No empty tag to move");
                }

                var temp = Tags[fromTo.fromX, fromTo.fromY];
                Tags[fromTo.fromX, fromTo.fromY] = Tags[fromTo.toX, fromTo.toY];
                Tags[fromTo.toX, fromTo.toY] = temp;
            }

                       
        }
        public void ShowTags()
        {
            Console.Write("|   |");

            for (int j = 1; j <= Length; j++)
            {
                Console.Write("{0, 3}|", j);
            }
            Console.Write("\n");


            for (int j = 1; j <= Length; j++)
            {
                Console.Write("=+=+", j);
            }
            Console.Write("=+=+" +
                "=\n");

            for (int i = 0; i < Width; i++)
            {
                Console.Write("|{0, 3}|", Utils.indexToChar(i));
                for (int j = 0; j < Length; j++)
                {
                    if(this.Tags[i, j].Name == "x")
                    {
                        //Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("{0, 3}", this.Tags[i, j].Name);
                       // Console.Write(" ");
                        Console.ResetColor();
                        Console.Write("|");
                        continue;
                    }
                    Console.Write("{0, 3}|", this.Tags[i, j].Name);

                }
                Console.Write("\n");
            }
        }


    }

    public static class Utils
    {
        public static string indexToChar(int n)
        {
            string res = "";
            int next = 1, val;
            while (next != 0)
            {
                next = n / 10;
                val = n - next * 10;
                switch (val) { 
                    case 0:
                        res += 'A';
                        break;
                    case 1:
                        res += 'B';
                        break;
                    case 2:
                        res += 'C';
                        break;
                    case 3:
                        res += 'D';
                        break;
                    case 4:
                        res += 'E';
                        break;
                    case 5:
                        res += 'F';
                        break;
                    case 6:
                        res += 'G';
                        break;
                    case 7:
                        res += 'H';
                        break;
                    case 8:
                        res += 'I';
                        break;
                    case 9:
                        res += 'J';
                        break;
                }
                n = next;
            }
            return res;
        }
    }


    //public IMemento CreateMapMemento()
    //{
    //    return null;
    //}
}
