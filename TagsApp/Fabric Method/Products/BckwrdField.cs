namespace TagsApp.Fabric_Method.Products
{
    public class BckwrdField: Field
    {
        public BckwrdField(uint w, uint l) 
            :base(w, l,"bckwrd")
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
