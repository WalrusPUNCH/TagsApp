using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Fabric_Method;

namespace TagsAppTests
{
    [TestFixture]
    class BckwrdsFieldCreatorTests
    {
        FieldCreator c;
        [Test]
        public void Generate_WandLInserted_ReturnBckwrdsField()
        {
            //arrange
            var w = 4;
            var l = 5;
            var bckwrdFieldCreator = new BckwrdFieldCreator();
            //act
            Field f = bckwrdFieldCreator.Generate((uint)w, (uint)l);
            //assert
            Assert.IsInstanceOf(typeof(BckwrdField), f);
        }

        [Test]
        public void Generate_InvokesGenerateOnBckwrdsFieldCreatorWithCorrectArguments()
        {
            Mock<FieldCreator> mockedField = new Mock<FieldCreator>();
            mockedField.Setup(c => c.Generate(7, 8)).Verifiable();
            FieldCreator fc = mockedField.Object;

            FieldCreator actualfc = new BckwrdFieldCreator();
            actualfc.Generate(7, 8);

            mockedField.Verify(c => c.Generate(7, 8));
        }
    }
}
