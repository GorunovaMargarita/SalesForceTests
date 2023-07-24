using NUnit.Framework;

namespace Core.Helpers
{
    public static class DirectoryHelper
    {
        //set DownloadFolder value in your appsettings.json in Browser section
        /// <summary>
        /// Check existing file in directory
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="path">Directory</param>
        /// <returns>True or false</returns>
        /// <example>CheckFileExist("myFile.jpeg")</example>
        public static bool CheckFileExist(string fileName, string? path = null) 
        {
            path ??= TestContext.Parameters.Get("DownloadFolder");
            return WaitForFile(path + fileName, TimeSpan.FromMinutes(1));
        }

        /// <summary>
        /// Remove file from directory
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="path">path</param>
        /// <example>RemoveFile("myFile.jpeg", "C:\\Users\\login\\Downloads\\")</example>
        public static void RemoveFile(string fileName, string? path = null)
        {
            path ??= TestContext.Parameters.Get("DownloadFolder");
            var fileInf = new FileInfo(path + fileName);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }

        /// <summary>
        /// Wait file in directory
        /// </summary>
        /// <param name="path">Directory</param>
        /// <param name="timeout">Time for waiting</param>
        /// <returns>True if file exist</returns>
        private static bool WaitForFile(string path, TimeSpan timeout)
        {
            var timeoutAt = DateTimeOffset.UtcNow + timeout;
            while (true)
            {
                if (File.Exists(path)) return true;
                if (DateTimeOffset.UtcNow >= timeoutAt) return false;
                Thread.Sleep(300);
            }
        }
    }
}
