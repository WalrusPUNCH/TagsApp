using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TagsApp;
using TagsApp.Command;
using TagsApp.Meemento;

namespace TagsAppTests
{
    [TestFixture]
    class MoveTagCommandTests
    {
        FromToCoords coords;
        Mock<ICommand> mockMoveCommand;
        Mock<HistoryCareTaker> h;

        Field f1, f2;
        [SetUp]
        public void SetUp()
        {
            f1 = new Field(4, 4);
            f2 = new Field(4, 4);
            coords = new FromToCoords(0, 0, 0, 1);
        }


        [Test]
        public void Execute_MoveTagResult()
        {
            mockMoveCommand = new Mock<ICommand>();
            mockMoveCommand.Setup(move => move.Execute()).Verifiable();
            ICommand command = mockMoveCommand.Object;
            //act
            command.Execute();
            //assert
            mockMoveCommand.Verify(move => move.Execute());        
        }

        [Test]
        public void MoveTag_SaveMoveAndRestore_InstancesShouldBeSame()
        {
            //arrange
            f1.Tags[0, 0].Name = Tag.Empty;

            f2.Tags[0, 1].Name = Tag.Empty;
            f2.Tags[0, 0].Name = "2";


            f1.MoveTag(coords);
            var memento = f1.CreateMemento();
            //act
            h = new Mock<HistoryCareTaker>();
            h.Object.Save(memento);
            //assert
            Assert.AreEqual(f2.Tags[0, 0].Name, f1.Tags[0,0].Name);            
        }
    }
}
