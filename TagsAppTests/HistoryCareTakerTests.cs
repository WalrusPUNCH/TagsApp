using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Meemento;

namespace TagsAppTests
{
    [TestFixture]
    class HistoryCareTakerTests
    {
        private HistoryCareTaker history;
        Mock<IMemento> mementomock;

        [SetUp]
        public void SetUp()
        {
            history = new HistoryCareTaker();
        }

        [Test]
        public void Undo_NoElementInStack_ThrowException()
        {
            //assert
            Assert.Throws<InvalidOperationException>(() => history.Undo());
        }

        [Test]
        public void Save_1elementInStack_Saved()
        {
            //arrange
            mementomock = new Mock<IMemento>();
            IMemento memento = mementomock.Object;
            //act
            history.Save(memento);
            //assert
            Assert.IsNotEmpty(history.History);
        }

        [Test]
        public void Undo_1elementInStack_ReturnMemento()
        {
            //arrange
            var mementomock = new Mock<IMemento>();
            history.Save(mementomock.Object);
            //act
            history.Undo();
            //assert
            Assert.IsEmpty(history.History);
        }

    }
}
