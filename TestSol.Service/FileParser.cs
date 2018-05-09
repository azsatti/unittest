using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestSol.Service.Interface;
using TestSol.Service.ResultSet;

namespace TestSol.Service
{
    public class FileParser : IFileParser
    {
        private const char Separator = ' ';
        private readonly IConsoleWrapper _consoleWrapper;

        public FileParser(IConsoleWrapper consoleWrapper)
        {
            this._consoleWrapper = consoleWrapper;
        }

        public FileParserResultSet ParseFile(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var doorNumbersList = new List<int>();
            var parsed = false;

            if (!File.Exists(filePath))
            {
                this._consoleWrapper.Print("File not found");
            }

            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    doorNumbersList.AddRange(
                        line.Split(Separator).Select(str => Convert.ToInt32(str)));
                }

                if (doorNumbersList.Any())
                {
                    parsed = true;
                }
                else
                {
                    this._consoleWrapper.Print("No valid numbers found");
                }
                
            }
            catch (FormatException)
            {
                this._consoleWrapper.Print("Invalid file format");
            }
            catch (Exception ex)
            {
              this._consoleWrapper.Print($"Unexpected error:{ex.Message}");
            }

            return new FileParserResultSet(parsed, doorNumbersList);
        }
    }
}
