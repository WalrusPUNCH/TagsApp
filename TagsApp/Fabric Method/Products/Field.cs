using System;
using TagsApp.Meemento;
using static System.Math;

namespace TagsApp.Fabric_Method.Products
{
    public class Field : ICloneable
    {
        private string _name;
        public uint Length { set; get; }
        public uint Width { set; get; }
        public Tag[,] Tags { set; get; }

        public Field(uint w, uint l, string name = "Standart")
        {
            this._name = name;
            this.Width = w;
            this.Length = l;
            this.Tags = new Tag[w,l];

            uint count = 1;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    this.Tags[i, j] = new Tag(count.ToString());
                    count++;
                }
            }
        }
        
        /*
         * throws exeptions on invalid moves or out of order
         * on sucssess checks moves swaps tags
         */
        public virtual void MoveTag(FromToCoords fromTo)
        {
            ValidateMove(fromTo);
            SwapTags(fromTo);
        }

        protected void SwapTags(FromToCoords fromTo)
        {
            var temp = Tags[fromTo.FromX, fromTo.FromY];
            Tags[fromTo.FromX, fromTo.FromY] = Tags[fromTo.ToX, fromTo.ToY];
            Tags[fromTo.ToX, fromTo.ToY] = temp;
        }

        private void ValidateMove(FromToCoords fromTo)
        {
            double summ = Pow(Convert.ToInt32(fromTo.FromX) - Convert.ToInt32(fromTo.ToX), 2) +
                          Pow(Convert.ToInt32(fromTo.FromY) - Convert.ToInt32(fromTo.ToY), 2);
            double len = Sqrt(summ);
            
            if (Ceiling(len) >= 2)
            {
                throw new InvalidOperationException("too far. choose a closer tag");
            }
            if (fromTo.FromX == fromTo.ToX && fromTo.FromY == fromTo.ToY)
            {
                throw new InvalidOperationException("same tags");
            }
            if (Tags[fromTo.FromX, fromTo.FromY].Name != Tag.Empty && Tags[fromTo.ToX, fromTo.ToY].Name != Tag.Empty)
            {
                throw new InvalidOperationException("No empty tag to move");
            }
        }
        
        private void FindEmptyTag(out uint x, out uint y)
        {
            x = 0;
            y = 0;
            for(uint i = 0; i < Width; i++)
            {
                for(uint j = 0; j < Length; j++)
                {
                    if(Tags[i, j].Name ==  Tag.Empty)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
        }
        
        public IMemento CreateMemento()
        {
            return new FieldMemento(this, (Field)Clone());
        }
        public object Clone()
        {
            Field clonedField = (Field)MemberwiseClone();
            clonedField.Tags = CloneTags();
            return clonedField;
        }

        private Tag[,] CloneTags()
        {
            Tag[,] tagsCopy = new Tag[Width, Length];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    tagsCopy[i, j] = Tags[i, j];
                }
            }

            return tagsCopy;
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
                    if (f1.Tags[i, j].Name != f2.Tags[i, j].Name)
                        return true;
                }
            }
            return false;
        }
    }   
}
