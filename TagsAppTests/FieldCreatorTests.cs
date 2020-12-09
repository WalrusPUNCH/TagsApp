using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;

namespace TagsAppTests
{
    [TestFixture]
    class FieldCreatorTests
    {
        [Test]
        public void GenerateWinField_WandLInsert_ReturnWinField()
        {
            //arrange
            var w = 4;
            var l = 5;
            //act
            Field f = FieldCreator.GenerateWinField((uint)w, (uint)l);
            //assert
            Assert.IsInstanceOf(typeof(Field), f);
        }
    }
}
