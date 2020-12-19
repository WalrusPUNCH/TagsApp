using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public class FieldMemento:IMemento
    {
        private uint width;
        
        private uint length;
        private Tag[,] tags;
        Field field;

        public FieldMemento(Field f, Tag[,] _tags, uint Width, uint Length)
        {
            field = f;
            this.width = Width;
            this.length = Length;
            tags = new Tag[width, length];
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    tags[i,j] = _tags[i,j];
                }
            }
        }

        public uint Width { get => width; set => width = value; }
        public uint Length { get => length; set => length = value; }
        public Tag[,] Tags { get => tags; set => tags = value; }
        public Field Field { get => field; set => field = value; }

        public void Restore()
        {
            field.Length = length;
            field.Width = width;
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    field.Tags[i, j] = tags[i, j];
                }
            }
        }
    }
}
