using TestSol.Service.ResultSet;

namespace TestSol.Service.Interface
{
    public interface IFileParser
    {
        FileParserResultSet ParseFile(string filePath);
    }
}
