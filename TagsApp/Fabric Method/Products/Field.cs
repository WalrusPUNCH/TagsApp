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

        public int LengthInt { get { return Convert.ToInt32(length); } }
        public int WidthInt { get { return Convert.ToInt32(width); } }

        public Field(string _name, uint w, uint l)
        {
            this.name = _name;
            this.width = w;
            this.length = l;
            this.tags = new Tag[w,l];
        }
        public Field(uint w, uint l)
        {
            this.name = "Standart";
            this.width = w;
            this.length = l;
            this.tags = new Tag[w,l];

            uint count = 1;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    this.Tags[i, j] = new Tag(count.ToString());
                    count++;
                    // Console.Write(this.Tags[i, j].Name + " ");
                }
            }
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

                if (Tags[fromTo.fromX, fromTo.fromY].Name != Tag.Empty && Tags[fromTo.toX, fromTo.toY].Name != Tag.Empty)
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
                Console.Write("+---", j);
            }
            Console.Write("+----\n");

            for (int i = 0; i < Width; i++)
            {
                Console.Write("|{0, 3}|", Utils.indexToChar(i));
                for (int j = 0; j < Length; j++)
                {
                    if(this.Tags[i, j].Name == Tag.Empty)
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

        public static bool operator ==(Field f1, Field f2)
        {
            if (f1.Length != f2.Length || f1.Width != f2.Width)
            {
                return false;
            }
            
            for (int i = 0; i < f1.Width; i++)
            {
                for (int j = 0; j < f1.Length; j++)
                {
                    if (f1.Tags[i, j] != f2.Tags[i, j])
                        return false;
                }
            }
            return true;
        }
        public static bool operator !=(Field f1, Field f2)
        {
            if (f1.Length != f2.Length || f1.Width != f2.Width)
            {
                return true;
            }
            
            for (int i = 0; i < f1.Width; i++)
            {
                for (int j = 0; j < f1.Length; j++)
                {
                    if (f1.Tags[i, j] == f2.Tags[i, j])
                        return false;
                }
            }
            return true;
        }

        public IMemento CreateMemento()
        {
            return new FieldMemento(this, tags, width, length );
        }
       
    }


   
}
