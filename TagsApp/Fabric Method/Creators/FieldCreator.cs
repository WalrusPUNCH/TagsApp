using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public abstract class FieldCreator
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public FieldCreator(string _name)
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentNullException(nameof(_name));
            }
            Name = _name;
        }
        public abstract Field Generate(uint w, uint l);
        //{
        //    var field = new Field(w, l);
        //    field.Name = "WinField";
        //    field.Tags[w-1, l-1] = new Tag();
        //    return field;
        //}

    }
}
