using System.IO;

namespace DriveBackupManagement
{
    public static class DirectoryCtrl
    {
        /// <summary>
        /// 取得某目錄的上幾層的目錄路徑
        /// </summary>
        /// <param name="folderPath">目錄路徑</param>
        /// <param name="levels">要往上幾層</param>
        /// <returns></returns>
        public static string GetParentDirectoryPath(this string folderPath, int levels)
        {
            string result = folderPath;
            for (int i = 0; i < levels; i++)
            {
                if (Directory.GetParent(result) != null)
                {
                    result = Directory.GetParent(result).FullName;
                }
                else
                {
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// 取得某目錄的上層的目錄路徑
        /// </summary>
        /// <param name="folderPath">目錄路徑</param>
        /// <returns></returns>
        public static string GetParentDirectoryPath(this string folderPath)
        {
            return GetParentDirectoryPath(folderPath, 1);
        }

        /// <summary>
        /// 取得路徑的目錄路徑
        /// </summary>
        /// <param name="filePath">路徑</param>
        /// <returns></returns>
        public static string GetDirectoryPath(this string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }
    }
}
