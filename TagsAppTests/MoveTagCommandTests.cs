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
        Field f;
        FromToCoords coords;
        HistoryCareTaker history;
        Mock<ICommand> mockMoveCommand;

        [Test]
        public void Execute_MoveTagResult()
        {
            //arrange
            coords = new FromToCoords(0, 0, 1, 0);

            f = new Field(4, 4);
            f.Tags[0, 0].Name = Tag.Empty;

            history = new HistoryCareTaker();
            
            mockMoveCommand = new Mock<ICommand>();
            mockMoveCommand.Setup(move => move.Execute()).Verifiable();
            ICommand command = mockMoveCommand.Object;

            //act
            MoveTagCommand moveCommand = new MoveTagCommand(coords, f, history);
            moveCommand.Execute();

            //assert

            mockMoveCommand.Verify(move => move.Execute());
        
        }
    }
}
