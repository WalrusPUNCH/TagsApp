namespace TagsApp.Fabric_Method.Products
{
    public class Tag
    {
        public const string Empty = "X";
        public string Name { set; get; }

        public Tag(string name = Empty)
        {
           Name = name;
        }
    }
}