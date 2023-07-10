using NUnit.Framework;

namespace Core.Helpers
{
    public static class DirectoryHelper
    {
        public static bool CheckFileExist(string fileName, string? path = null) 
        {
            path ??= TestContext.Parameters.Get("DownloadFolder");
            return WaitForFile(path + fileName, TimeSpan.FromMinutes(1));
        }
        public static void RemoveFile(string fileName, string? path = null)
        {
            path ??= TestContext.Parameters.Get("DownloadFolder");
            var fileInf = new FileInfo(path + fileName);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
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
