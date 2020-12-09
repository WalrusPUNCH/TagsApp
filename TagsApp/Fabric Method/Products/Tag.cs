using System;

namespace TagsApp
{
    public class Tag
    {
        private string name;
        public string Name { set { name = value; } get { return name; } }
        public Tag(string _name)
        {
           Name = _name  ;
        }

        private const string emptyTag = "X";
        public static string Empty { get { return emptyTag; } }

        public Tag()
        {
            Name = emptyTag;
        }
    }
}