using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public class FieldMemento:IMemento
    {
        private uint Width;
        private uint Length;

        private Tag[,] tags;
        Field field;

        public FieldMemento(Field f, Tag[,] _tags, uint Width, uint Length)
        {
            field = f;
            tags = new Tag[Width, Length];
            for(int i = 0; i < Length; i++)
            {
                for(int j = 0; i< Width; j++)
                {
                    tags[i,j] = _tags[i,j];
                }
            }
        }

        public void Restore()
        {
            field.Length = Length;
            field.Width = Width;
            
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; i < Width; j++)
                {
                    field.Tags[i, j] = tags[i, j];
                }
            }
        }
    }
}
