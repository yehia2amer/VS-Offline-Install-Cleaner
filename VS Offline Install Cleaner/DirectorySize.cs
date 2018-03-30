using System;

namespace VS_Offline_Install_Cleaner
{
    internal static class DirectorySize
    {
        public static string GetFolderSize(string folderPath)
        {
            Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
            Scripting.Folder folder = fso.GetFolder(folderPath);
            dynamic dirSize = folder.Size;
            long dirSizeInt = Convert.ToInt64(dirSize);
            string dirSizeString = BytesToString(dirSizeInt);
            return dirSizeString;
        }

        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num) + suf[place];
        }
    }
}