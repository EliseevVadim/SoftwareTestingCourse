using System;
using System.IO;
using System.Linq;

namespace Lab2.ProductionCode.FileManagement
{
    public class FileService : IFileService
    {
        public int MergeTemporaryFiles(string dir)
        {
            if (!Directory.Exists(dir))
                throw new DirectoryNotFoundException();
            string[] files = Directory.GetFiles(dir).Where(file => file.EndsWith(".tmp")).ToArray();
            if (files.Length == 0)
                return 0;
            int processedFilesCounter = 0;
            FileStream stream = File.Create(dir + @"\backup.tmp");
            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (string file in files)
                {
                    string content = File.ReadAllText(file);
                    if (String.IsNullOrEmpty(content))
                        continue;
                    writer.WriteLine(content);
                    processedFilesCounter++;
                    File.Delete(file);
                }
            }
            return processedFilesCounter;
        }
    }
}
