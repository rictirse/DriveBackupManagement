using System;
using System.IO;

namespace DriveBackupManagement
{
    public static class RarCtrl
    {
        public static bool Compression(string aDirPath, 
            string aDirName, 
            int aRarLevel = 5, 
            int aRecoveryRecord = 3)
        {
            string RarPath = Environment.CurrentDirectory + "\\Rar.exe";

            if (!File.Exists(RarPath)) return false;

            string WorkingDirectory = DirectoryCtrl.GetParentDirectoryPath(aDirPath);
            string RarCmd = string.Format("a -m{0} -rr{1} -ep1 {2}\\{3}.rar {4}", 
                aRarLevel,
                aRecoveryRecord, 
                WorkingDirectory, 
                aDirName, 
                aDirPath);

            ProcessCtrl.Run(RarPath, WorkingDirectory, false, RarCmd).WaitForExit();

            return true;
        }
    }
}
