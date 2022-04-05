using Lab2.ProductionCode.FileManagement;
using System.IO;

namespace Lab2.Tests.FileServiceFakes
{
    public class FileServiceWithUnexistedDirectory : IFileService
    {
        public int MergeTemporaryFiles(string dir)
        {
            throw new DirectoryNotFoundException();
        }
    }
}
