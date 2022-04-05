using Lab2.ProductionCode.FileManagement;

namespace Lab2.Tests.FileServiceFakes
{
    public class FakeFileService : IFileService
    {
        public bool MethodWasCalled { get; private set; }

        public int MergeTemporaryFiles(string dir)
        {
            MethodWasCalled = true;
            return 6;
        }
    }
}
