﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Fabric_Method;
using TagsApp.Fabric_Method.Products;

namespace TagsAppTests
{
    [TestFixture]
    class BckwrdsFieldCreatorTests
    {
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
    }
}
