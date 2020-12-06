using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Fabric_Method
{
    public class BckwrdField: Field
    {
        public BckwrdField(uint w, uint l) 
            :base("bckwrd", w, l)
        {
            uint count = Width * Length;
            for(int i=0; i< Width; i++)
            {
                for(int j=0; j<Length; j++)
                {                    
                    this.Tags[i, j] = new Tag(count.ToString());
                    count--;
                }
            }
        }
    }
}
