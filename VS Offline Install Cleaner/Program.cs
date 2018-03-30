using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace VS_Offline_Install_Cleaner
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            string vsOfflineDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string catalogFileName = "Catalog.json";
            string unneededPackagesfolderName = "ToBeRemoved";

            Console.WriteLine($"Please Enter Visual Studio Offline Directory [Default : {vsOfflineDirectory}]");
            string tempVsOfflineDirectory = Console.ReadLine();

            if (!string.IsNullOrEmpty(tempVsOfflineDirectory))
                vsOfflineDirectory = tempVsOfflineDirectory;

            Console.WriteLine($"Please Enter CatalogFileName [Default : {catalogFileName}]");
            string tempCatalogFileName = Console.ReadLine();

            if (!string.IsNullOrEmpty(tempCatalogFileName))
                catalogFileName = tempCatalogFileName;

            HashSet<string> folderNames = new CleanVs().GetFolderNames(vsOfflineDirectory);
            Console.WriteLine($"Number of Folder before cleanup : {folderNames.Count}");

            HashSet<string> packageNames = new CleanVs().GetPackageNames(vsOfflineDirectory + "\\" + catalogFileName);
            //Console.WriteLine($"Number of Packages in the catalog File : {packageNames.Count}");

            IEnumerable<string> pakagesNotListedInCatalog = folderNames.Except(packageNames).ToHashSet();
            Console.WriteLine($"Number of Folder Needs to be Cleaned : {pakagesNotListedInCatalog.Count()}");

            Console.WriteLine($@"Unneeded Folder will be moved to ""{unneededPackagesfolderName}"" Folder");
            bool moving = new CleanVs().MoveUnneededPackagesToUnneededPackagesfolderFolder(vsOfflineDirectory, pakagesNotListedInCatalog, unneededPackagesfolderName);


            if (!moving) return;
            try
            {
                string savedDiskSpace = DirectorySize.GetFolderSize($@"{vsOfflineDirectory}\{unneededPackagesfolderName}");
                Console.WriteLine($@"Yaaay cleanup process is Done, Saved about {savedDiskSpace} in disk Space, Please Remove the ""{unneededPackagesfolderName}"" directory to Save Disk Space");
            }
            catch (Exception)
            {
                Console.WriteLine($@"Yaaay cleanup process is Done, Please Remove the ""{unneededPackagesfolderName}"" directory to Save Disk Space");
            }

            Console.WriteLine("Press any key to Exit");
            Console.ReadLine();
        }
    }
}