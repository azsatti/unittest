using System.Collections.Generic;
using System.Linq;
using TestSol.Service.Interface;

namespace TestSol.Service
{
    public class DoorService : IDoorService
    {
        private readonly IFileParser _fileParser;
        private readonly IConsoleWrapper _consoleWrapper;

        public DoorService(IFileParser fileParser, IConsoleWrapper consoleWrapper)
        {
            this._fileParser = fileParser;
            this._consoleWrapper = consoleWrapper;
        }

        public void ProcessForTownPlanner(string filePath)
        {
            if (this.ValidateFile(filePath, out var numbersList))
            {
                this._consoleWrapper.Print("Valid File");
                this._consoleWrapper.Print($"Total house count is: {GetTotalHouses(numbersList)}");
                this._consoleWrapper.Print($"Total house count on north side is: {GetTotalHousesOnNorthSide(numbersList)}");
                this._consoleWrapper.Print($"Total house count on south side is: {GetTotalHousesOnSouth(numbersList)}");
            }
            else
            {
                this._consoleWrapper.Print("Invalid file");
            }
        }

        public void ProcessForPaperDistributor(string filePath)
        {
            throw new System.NotImplementedException();
        }


        private bool ValidateFile(string filePath, out List<int> numbersList)
        {
            var parserResultSet = this._fileParser.ParseFile(filePath);

            if (!parserResultSet.Parsed)
            {
                numbersList = new List<int>(); 
                return false;
            }

            numbersList = parserResultSet.DoorNumbersList;
                
            if (!HasValidFirstNumber(numbersList))
            {
                return false;
            }

            if (HasDuplicates(numbersList))
            {
                return false;
            }

            var oddNumbers = numbersList.Where(IsOdd).ToArray();
                

            if (HasMissingOddNumbers(oddNumbers))
            {
                return false;
            }

            var evenNumbers = numbersList.Where(x => !IsOdd(x)).ToArray();
            if (HasMissingEvenNumbers(evenNumbers))
            {
                return false;
            }

            return true;
        }

        private static bool IsOdd(int doorNumber)
        {
            return doorNumber % 2 != 0;
        }

        private bool HasDuplicates(List<int> doorNumbers)
        {
            return doorNumbers != null && doorNumbers.GroupBy(x => x).Any(g => g.Count() > 1);
        }

        private bool HasMissingOddNumbers(int[] oddDoorNumbers)
        {
            return oddDoorNumbers.Any() && Enumerable.Range(oddDoorNumbers.Min(), oddDoorNumbers.Max()).Any(x => IsOdd(x) && !oddDoorNumbers.Contains(x));
        }

        private bool HasMissingEvenNumbers(int[] evenDoorNumbers)
        {
            return evenDoorNumbers.Any() && Enumerable.Range(evenDoorNumbers.Min(), evenDoorNumbers.Max())
                       .Any(x => !IsOdd(x) && !evenDoorNumbers.Contains(x));
        }

        private bool HasValidFirstNumber(List<int> doorNumbers)
        {
            return doorNumbers.First() == 1;
        }

        public static int GetTotalHouses(IEnumerable<int> doorNumbers)
        {
            return doorNumbers.Count();
        }

        public static int GetTotalHousesOnNorthSide(IEnumerable<int> doorNumbers)
        {
            return doorNumbers.Count(IsOdd);
        }

        public static int GetTotalHousesOnSouth(IEnumerable<int> doorNumbers)
        {
            return doorNumbers.Count(x => !IsOdd(x));
        }
    }
}
