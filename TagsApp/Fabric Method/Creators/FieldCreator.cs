using System;
using TagsApp.Fabric_Method.Products;

namespace TagsApp.Fabric_Method.Creators
{
    public abstract class FieldCreator
    {
        private string name;

        public FieldCreator(string _name)
        {
            if (string.IsNullOrEmpty(_name))
            {
                throw new ArgumentNullException(nameof(_name));
            }
            name = _name;
        }
        public abstract Field Generate(uint w, uint l);
        public static Field GenerateWinField(uint w, uint l)
        {
            var field = new Field(w, l)
            {
                Tags = {[w - 1, l - 1] = new Tag()}
            };
            return field;
        }
    }
}
