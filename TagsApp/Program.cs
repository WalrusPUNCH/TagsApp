using System;
using TagsApp.Fabric_Method;

namespace TagsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = Core.GetInstance();
            var field = core.Init();
            core.MainLoop(field);
        }
    }
}
