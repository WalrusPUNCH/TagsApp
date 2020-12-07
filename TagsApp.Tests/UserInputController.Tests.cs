using NUnit.Framework;
using System;
using TagsApp;

namespace TagsApp.Tests
{
    public class UserInputControllerTests
    {
        [Test]
        public void ChooseFieldType_string_UintReturned()
        {
            //arrange
            var teststr = "2";
            uint expected = 2;
            //act
            UserInputController u = new UserInputController();
            //assert

        }
        public uint ChooseFieldType(string fieldType)

    }
}
