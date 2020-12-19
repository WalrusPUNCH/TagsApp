using Moq;
using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Command;
using TagsApp.Fabric_Method;

namespace TagsAppTests
{
    [TestFixture]
    public class HardFieldTests
    {
        Field actual;
        FromToCoords fromto;
        [SetUp]
        public void SetUp()
        {
            //create field with 100% cancellation and random move
            actual = new HardField(3, 3, 100);
            actual.Tags[0, 0].Name = Tag.Empty;
        }

        [Test]
        public void MoveTagOverride_AcceptFromtoCoords_TagsNotEqual()
        {
            //arange
            Core core = new Mock.Of<>()
            Field expected = new Field(3, 3);
            expected.Tags[1, 0].Name = Tag.Empty;
            expected.Tags[0, 0].Name = "4";

            fromto = new FromToCoords(0, 0, 1, 0);

            //act 
            actual.MoveTag(fromto);

            //assert
            Assert.AreNotEqual(expected.Tags[0, 0].Name, actual.Tags[0, 0].Name);
        }
    }

}
