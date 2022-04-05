using Lab2.ProductionCode.FileManagement;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Lab2.Tests
{
    [TestFixture]
    internal class FileServiceTests
    {
        private FileService _fileService;

        [SetUp]
        public void InitializeFileService()
        {
            _fileService = new FileService();
        }

        [Test]
        public void TestUnexistedDirectory()
        {
            Assert.Throws<DirectoryNotFoundException>(delegate
            {
                _fileService.MergeTemporaryFiles("no_dir");
            });
        }

        [Test]
        public void TestEmptyDirectory()
        {
            string path = Environment.CurrentDirectory + @"\no_matches";
            int count = _fileService.MergeTemporaryFiles(path);
            int resultCount = Directory.GetFiles(path)
                .Where(file => file.EndsWith(".tmp"))
                .Count();
            Assert.That(count, Is.EqualTo(0));
            Assert.That(resultCount, Is.EqualTo(0));
        }

        [Test]
        public void TestDirectoryWithDeterminedQuantity()
        {
            string path = Environment.CurrentDirectory + @"\temps";
            int initialCount = _fileService.MergeTemporaryFiles(path);
            int resultCount = Directory.GetFiles(path)
                .Where(file => file.EndsWith(".tmp"))
                .Count();
            Assert.That(initialCount, Is.EqualTo(6));
            Assert.That(resultCount, Is.EqualTo(1));
        }
    }
}
