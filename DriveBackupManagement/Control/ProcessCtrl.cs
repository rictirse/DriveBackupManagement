using System.Diagnostics;
using System.IO;

namespace DriveBackupManagement
{
    public static class ProcessCtrl
    {
        /// <summary>
        /// 執行程式
        /// </summary>
        /// <param name="aFilePath">執行程式的目標位置</param>
        /// <param name="aWorkingDirectory">工作目錄</param>
        /// <param name="aUseShellExecute">UseShellExecute</param>
        /// <param name="aArguments">參數</param>
        /// <param name="WaitForExit">是否等到執行完成(1min time out)</param>
        /// <returns></returns>
        static public Process Run(string aFilePath,
            string aWorkingDirectory = "",
            bool aUseShellExecute = false,
            string aArguments = "",
            bool WaitForExit = false)
        {
            if (!File.Exists(aFilePath)) return null;

            var fi = new FileInfo(aFilePath);

            if (string.IsNullOrEmpty(aWorkingDirectory))
            {
                aWorkingDirectory = fi.Directory.FullName;
            }

            Process P = new Process();
            P.StartInfo = new ProcessStartInfo()
            {
                FileName = aFilePath,
#if !DEBUG
                    CreateNoWindow   = true,
#endif
                WorkingDirectory = aWorkingDirectory,
                UseShellExecute = aUseShellExecute,
                Arguments = aArguments
            };

            P.Start();
            if (WaitForExit)
            {
                P.WaitForExit(60000); //1分鐘 timeout
            }
            return P;
        }
    }
}
