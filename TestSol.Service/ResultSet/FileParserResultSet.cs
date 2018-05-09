using System.Collections.Generic;

namespace TestSol.Service.ResultSet
{
    public class FileParserResultSet
    {
        public FileParserResultSet(bool parsed, List<int> doorNumbersList)
        {
            this.Parsed = parsed;
            this.DoorNumbersList = doorNumbersList;
        }

        public bool Parsed { get; set; }

        public List<int> DoorNumbersList { get; set; }
    }
}
