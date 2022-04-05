using System;

namespace Lab2.ProductionCode.FileManagement
{
    public class ReportViewer
    {
        private readonly IFileService _fileService;
        private int? _blockCount;

        public ReportViewer(IFileService fileService)
        {
            _fileService = fileService;
        }

        public int? BlockCount { get => _blockCount; set => _blockCount = value; }

        public void PrepareData()
        {
            /*
             * Some complicated data preparing logic
            */
            int count = _fileService.MergeTemporaryFiles(Environment.CurrentDirectory + @"\temps");
            if (count == 0)
                return;
            _blockCount = count;
        }
    }
}
