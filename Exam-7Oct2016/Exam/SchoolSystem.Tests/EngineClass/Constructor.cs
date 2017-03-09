using System;
using NUnit.Framework;
using ConsoleApplication3.Core;
using Moq;
using ConsoleApplication3.Contracts;

namespace SchoolSystem.Tests.EngineClass
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldNotThrow_WhenCalledWithAnyIReaderOrIWriterSuccesor()
        {
            // Arrange
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWriter>();

            // Act & Assert
            Assert.DoesNotThrow(() => new Engine(mockedReader.Object, mockedWriter.Object));
        }
    }
}
