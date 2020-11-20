using System;
using TagsApp.Fabric_Method;

namespace TagsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //FieldCreator creator = new HardFieldCreator(6);
            //var tags1 = creator.Generate(4, 4);
            //tags1.ShowTags();


            //Console.WriteLine();
            //Console.ReadKey();

            UserInputController user = new UserInputController();
            user.ParseMove();


        }
    }
}
