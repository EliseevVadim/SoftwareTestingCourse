using Lab2.ProductionCode.FileManagement;

namespace Lab2.Tests.FileServiceFakes
{
    public class FileServiceWithEmptyDirectory : IFileService
    {
        public int MergeTemporaryFiles(string dir)
        {
            return 0;
        }
    }
}
