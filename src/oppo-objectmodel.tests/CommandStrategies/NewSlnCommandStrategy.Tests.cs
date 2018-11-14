﻿using System.Linq;
using Moq;
using NUnit.Framework;
using Oppo.ObjectModel.CommandStrategies.NewCommands;

namespace Oppo.ObjectModel.Tests.CommandStrategies
{
    public class NewSlnCommandStrategyTests
    {
        private static string[][] ValidInputs()
        {
            return new[]
            {
                new[] {"-n", "anyName"},
                new[] {"-n", "ABC"},
                new[] {"--name", "ABC"}
            };
        }

        private static string[][] InvalidInputs()
        {
            return new[]
            {
                new[] {"-n", ""},
                new[] {"-n", "ab/yx"},
                new[] {"-n", "ab\\yx"},
                new[] {"-N", "ab/yx"},
                new[] {"", ""},
                new[] {""},
                new[] {"-n"},
                new string[] { }
            };
        }

        [Test]
        public void NewSlnCommandStrategy_Should_ImplementICommandOfNewStrategy()
        {
            // Arrange
            var fileSystemMock = new Mock<IFileSystem>();

            // Act
            var objectUnderTest = new NewSlnCommandStrategy(fileSystemMock.Object);

            // Assert
            Assert.IsInstanceOf<ICommand<NewStrategy>>(objectUnderTest);
        }

        [Test]
        public void NewSlnCommandStrategy_Should_CreateSlnAndProjectRelevantFiles([ValueSource(nameof(ValidInputs))]string[] inputParams)
        {
            // Arrange
            var slnFileName = $"{inputParams.Skip(1).First()}{Constants.FileExtension.OppoSln}";
            var infoWrittenOut = false;
            var loggerListenerMock = new Mock<ILoggerListener>();            
            loggerListenerMock.Setup(listener => listener.Info(It.IsAny<string>())).Callback(delegate { infoWrittenOut = true; });
            SetupOppoLogger(loggerListenerMock.Object);
            var fileSystemMock = new Mock<IFileSystem>();
            var objectUnderTest = new NewSlnCommandStrategy(fileSystemMock.Object);

            // Act
            var result = objectUnderTest.Execute(inputParams);

            // Assert
            Assert.IsTrue(infoWrittenOut);
            Assert.AreEqual(Constants.CommandResults.Success, result);
            fileSystemMock.Verify(x => x.CreateFile(slnFileName, It.IsAny<string>()), Times.Once);
            fileSystemMock.Verify(x => x.LoadTemplateFile(Resources.Resources.OppoSlnTemplateFileName), Times.Once);
            CleanupOppoLogger();
        }

        [Test]
        public void NewSlnCommandStrategy_Should_IgnoreInput([ValueSource(nameof(InvalidInputs))] string[] inputParams)
        {
            // Arrange
            var invalidCharsMock = new[] { '/', '\\' };
            var loggerListenerMock = new Mock<ILoggerListener>();
            var warnWrittenOut = false;
            loggerListenerMock.Setup(listener => listener.Warn(It.IsAny<string>())).Callback(delegate { warnWrittenOut = true; });
            SetupOppoLogger(loggerListenerMock.Object);

            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(x => x.GetInvalidFileNameChars()).Returns(invalidCharsMock);
            var objectUnderTest = new NewSlnCommandStrategy(fileSystemMock.Object);

            // Act
            var result = objectUnderTest.Execute(inputParams);

            // Assert
            Assert.IsTrue(warnWrittenOut);
            Assert.AreEqual(Constants.CommandResults.Failure, result);
            fileSystemMock.Verify(x => x.CreateFile(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            fileSystemMock.Verify(x => x.LoadTemplateFile(Resources.Resources.OppoSlnTemplateFileName), Times.Never);
            CleanupOppoLogger();
        }

        [Test]
        public void NewSlnCommandStrategy_Should_HaveCorrectCommandName()
        {
            // Arrange
            var fileSystemMock = new Mock<IFileSystem>();
            var objectUnderTest = new NewSlnCommandStrategy(fileSystemMock.Object);

            // Act
            var commandName = objectUnderTest.Name;

            // Assert
            Assert.AreEqual(Constants.NewCommandName.Sln, commandName);
        }

        [Test]
        public void NewSlnCommandStrategy_Should_ProvideEmptyHelpText()
        {
            // Arrange
            var fileSystemMock = new Mock<IFileSystem>();
            var objectUnderTest = new NewSlnCommandStrategy(fileSystemMock.Object);

            // Act
            var helpText = objectUnderTest.GetHelpText();

            // Assert
            Assert.AreEqual(string.Empty, helpText);
        }

        private static void SetupOppoLogger(ILoggerListener loggerListener)
        {
            OppoLogger.RegisterListener(loggerListener);
        }

        private static void CleanupOppoLogger()
        {
            OppoLogger.RemoveAllListeners();
            Assert.AreEqual(OppoLogger.LoggerListeners.Count(), 0);
        }
    }
}
