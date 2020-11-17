using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public abstract class FieldCreator
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public FieldCreator(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }
        public abstract Field Generate();
    }
}
