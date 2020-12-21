using System;
using System.Collections.Generic;
using System.Text;
using TagsApp.Fabric_Method.Creators;
using TagsApp.Fabric_Method.Products;

namespace TagsApp.Fabric_Method
{
    public class BckwrdFieldCreator : FieldCreator
    {
        public BckwrdFieldCreator() : base("Backwards creator")
        {

        }
        public override Field Generate(uint w, uint l)
        {
            var bfield = new BckwrdField(w, l);
            bfield.Tags[0, 0] = new Tag();
            return bfield;
        }
    }
}
