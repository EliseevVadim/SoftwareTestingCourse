using Lab2.ProductionCode.FileManagement;
using Lab2.Tests.FileServiceFakes;
using NUnit.Framework;
using System.IO;

namespace Lab2.Tests
{
    [TestFixture]
    internal class ReportViewerTests
    {
        [Test]
        public void TestEmptyDirectory()
        {
            IFileService service = new FileServiceWithEmptyDirectory();
            ReportViewer reportViewer = new ReportViewer(service);
            reportViewer.PrepareData();
            Assert.That(reportViewer.BlockCount, Is.Null);
        }

        [Test]
        public void TestUnexistedDirectoty()
        {
            IFileService service = new FileServiceWithUnexistedDirectory();
            ReportViewer reportViewer = new ReportViewer(service);
            Assert.Throws<DirectoryNotFoundException>(delegate { reportViewer.PrepareData(); });
        }

        [Test]
        public void TestInitialDirectoryOutput()
        {
            IFileService service = new FakeFileService();
            ReportViewer reportViewer = new ReportViewer(service);
            reportViewer.PrepareData();
            Assert.That(reportViewer.BlockCount, Is.EqualTo(6));
        }

        [Test]
        public void TestMergeFileMethodGetsCalled()
        {
            FakeFileService service = new FakeFileService();
            ReportViewer reportViewer = new ReportViewer(service);
            reportViewer.PrepareData();
            Assert.That(service.MethodWasCalled, Is.True);
        }
    }
}
