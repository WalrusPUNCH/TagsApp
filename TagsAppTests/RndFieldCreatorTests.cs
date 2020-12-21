using Moq;
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
    class RndFieldCreatorTests
    {
        [Test]
        public void Generate_WandLinput_ReturnRndField()
        {
            //arrange
            var w = 7;
            var l = 8;
            var randomswaps = 1;

            //act
            var rndfCreator = new RndFieldCreator((uint)randomswaps);
            var result = rndfCreator.Generate((uint)w, (uint)l);

            //aassert
            Assert.IsInstanceOf(typeof(RndField), result) ;
        }
    }
}
