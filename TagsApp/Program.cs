using System;
using TagsApp.Fabric_Method;

namespace TagsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tags = new BckwrdField("a", 10, 10);
            var fromtocoords = new FromToCoords(0, 0, 0, 1);
            tags.MoveTag(fromtocoords);
            tags.ShowTags();
        }
    }
}
