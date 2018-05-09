using System.IO;
using Moq;
using NUnit.Framework;
using SpecsFor;
using TestSol.Service.Interface;

namespace TestSol.Service.Tests.AcceptanceTest
{
    public class TownPlanner
    {
        public class WhenValidFile : SpecsFor<DoorService>
        {
            private Mock<IConsoleWrapper> _consoleWrapperMock;

            protected override void InitializeClassUnderTest()
            {
                this._consoleWrapperMock = new Mock<IConsoleWrapper>();

                this.SUT = new DoorService(
                    new FileParser(this._consoleWrapperMock.Object), 
                    this._consoleWrapperMock.Object);
            }

            protected override void When()
            {
                this.SUT.ProcessForTownPlanner(Path.Combine(TestContext.CurrentContext.TestDirectory, @"TestFiles\validfile.txt"));
            }

            [Test]
            public void ThenShouldPrintValidation()
            {
                this._consoleWrapperMock.Verify(x => x.Print("Valid File"));
            }

            [Test]
            public void ThenShouldPrintTotalHouses()
            {
                this._consoleWrapperMock.Verify(x => x.Print($"Total house count is: 5"));
            }

            [Test]
            public void ThenShouldPrintHousesontheNorthSide()
            {
                this._consoleWrapperMock.Verify(x => x.Print($"Total house count on north side is: 3"));
            }

            [Test]
            public void ThenShouldPrintHousesontheSouthSide()
            {
                this._consoleWrapperMock.Verify(x => x.Print("Total house count on south side is: 2"));
            }
        }

        public class WhenInValidFile : SpecsFor<DoorService>
        {
            private Mock<IConsoleWrapper> _consoleWrapperMock;

            protected override void InitializeClassUnderTest()
            {
                this._consoleWrapperMock = new Mock<IConsoleWrapper>();

                this.SUT = new DoorService(
                    new FileParser(this._consoleWrapperMock.Object),
                    this._consoleWrapperMock.Object);
            }

            protected override void When()
            {
                this.SUT.ProcessForTownPlanner(Path.Combine(TestContext.CurrentContext.TestDirectory, @"TestFiles\invalidfile.txt"));
            }

            [Test]
            public void ThenShouldPrintValidation()
            {
                this._consoleWrapperMock.Verify(x => x.Print("Invalid file"));
            }
        }
    }
}
