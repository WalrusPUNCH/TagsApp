using System;
using TagsApp.Fabric_Method;

namespace TagsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FieldCreator creator = new HardFieldCreator(6);
            var tags1 = creator.Generate(4, 4);
            tags1.ShowTags();


            Console.WriteLine();
            Console.ReadKey();

            //creator = new FieldCreator("Basic");
            //var tags2 = creator.Generate(4, 4);
            //tags2.ShowTags();

            //Console.WriteLine();
            //Console.ReadKey();

            creator = new RndFieldCreator(6);
            var tags3 = creator.Generate(4, 4);
            tags3.ShowTags();

            Console.WriteLine();
            Console.ReadKey();

            creator = new BckwrdFieldCreator();
            var tags4 = creator.Generate(4, 4);
            tags4.ShowTags();


            var fromtocoords = new FromToCoords(0, 0, 0, 1);
            //tags.MoveTag(fromtocoords);



        }
    }
}
