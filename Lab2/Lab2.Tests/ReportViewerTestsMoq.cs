using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Lab2.ProductionCode.FileManagement;
using System.IO;

namespace Lab2.Tests
{
    [TestFixture]
    internal class ReportViewerTestsMoq
    {
        private readonly Mock<IFileService> _mockFileService = new Mock<IFileService>();

        [TearDown]
        public void ResetInvokations()
        {
            _mockFileService.Invocations.Clear();
        }

        [Test]
        public void TestEmptyDirectoryWithMoq()
        {
            _mockFileService.Setup(service => service.MergeTemporaryFiles("emptyDir")).Returns(0);
            var reportViewer = new ReportViewer(_mockFileService.Object);
            reportViewer.PrepareData();
            Assert.That(reportViewer.BlockCount, Is.Null);
        }

        [Test]
        public void TestUnexistedDirectotyWithMoq()
        {
            _mockFileService.Setup(service => service.MergeTemporaryFiles(It.IsAny<string>())).Throws<DirectoryNotFoundException>();
            var reportViewer = new ReportViewer(_mockFileService.Object);
            Assert.Throws<DirectoryNotFoundException>(delegate
            {
                reportViewer.PrepareData();
            });
        }

        [Test]
        public void TestInitialDirectoryOutputWithMoq()
        {
            _mockFileService.Setup(service => service.MergeTemporaryFiles(It.IsAny<string>())).Returns(6);
            var reportViewer = new ReportViewer(_mockFileService.Object);
            reportViewer.PrepareData();
            Assert.That(reportViewer.BlockCount, Is.EqualTo(6));
        }

        [Test]
        public void TestMergeFileMethodGetsCalledWithMoq()
        {
            var reportViewer = new ReportViewer(_mockFileService.Object);
            reportViewer.PrepareData();
            _mockFileService.Verify(service => service.MergeTemporaryFiles(It.IsAny<string>()));
        }
    }
}
