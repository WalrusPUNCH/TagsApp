using Moq;
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
    class HardFieldCreatorTests
    {
        Mock<ICommand> mockCom;
        [Test]
        public void Generate_WandLInserted_ReturnBckwrdsField()
        {
            //arrange
            var w = 4;
            var l = 5;
            var chanceofrndcancel = 4;
            mockCom = new Mock<ICommand>();
            var bckwrdFieldCreator = new HardFieldCreator(
                (uint)chanceofrndcancel, mockCom.Object);
            //act
            Field f = bckwrdFieldCreator.Generate((uint)w, (uint)l);
            //assert
            Assert.IsInstanceOf(typeof(HardField), f);
        }
    }
}
