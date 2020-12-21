using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Fabric_Method.Products;
using TagsApp.Meemento;

namespace TagsAppTests
{
    [TestFixture]
    class FieldMementoTests
    {
        Field f;
        FieldMemento stub;
        [Test]
        public void Restore_AcceptW_L_Tags_ReturnFieldWithSameParameters()
        {
            throw new NotImplementedException();
            /*
            //arrange
            f = new Field(3, 3);
            f.Width = 3;
            f.Length = 3;
            f.Tags[0, 0].Name = Tag.Empty;
            stub = new FieldMemento(f, f.Tags, f.Width, f.Length);

            stub.Tags[0, 1].Name = Tag.Empty;
            //act
            stub.Restore();
            //assert
            Assert.AreEqual(f.Tags[0,1].Name, stub.Tags[0,1].Name);
            */
        }
    }
}
