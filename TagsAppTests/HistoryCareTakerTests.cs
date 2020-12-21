﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Command;

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
            mementomock = new Mock<IMemento>();
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
            throw new NotImplementedException();
            /*
            //arrange
            IMemento memento = mementomock.Object;
            //act
            history.Save(memento);
            //assert
            Assert.IsNotEmpty(history.History);*/
        }

        [Test]
        public void Undo_1elementInStack_StockIsEmpty()
        {
            throw new NotImplementedException();
            /*
            //arrange
            history.Save(mementomock.Object);
            //act
            history.Undo();
            //assert
            Assert.IsEmpty(history.History);*/
        }

    }
}
