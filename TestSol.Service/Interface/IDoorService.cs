namespace TestSol.Service.Interface
{
    public interface IDoorService
    {
        void ProcessForTownPlanner(string filePath);
        void ProcessForPaperDistributor(string filePath);
    }
}
