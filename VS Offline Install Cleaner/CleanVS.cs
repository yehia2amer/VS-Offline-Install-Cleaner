using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace VS_Offline_Install_Cleaner
{
    public class CleanVs
    {
        internal bool MoveUnneededPackagesToUnneededPackagesfolderFolder(string vsOfflineDirectory, IEnumerable<string> pakagesTobeMoved, string unneededPackagesfolderName)
        {

            bool exists = Directory.Exists($@"{vsOfflineDirectory}\{unneededPackagesfolderName}");

            if (!exists)
                Directory.CreateDirectory($@"{vsOfflineDirectory}\{unneededPackagesfolderName}");

            Directory.CreateDirectory($@"{vsOfflineDirectory}\{unneededPackagesfolderName}");

            foreach (string packageFolderName in pakagesTobeMoved)
            {
                string sourceDirName = $@"{vsOfflineDirectory}\{packageFolderName}";
                string destinationDirName = $@"{vsOfflineDirectory}\{unneededPackagesfolderName}\{packageFolderName}";

                if (packageFolderName == unneededPackagesfolderName && packageFolderName == "certificates") continue;
                try
                {
                    Directory.Move(sourceDirName, destinationDirName);
                }
                catch (System.Exception)
                {
                    // ignored
                }

            }

            return true;
        }
        internal HashSet<string> GetPackageNames(string catalogFileName)
        {

            string catalogFileContent = File.ReadAllText(catalogFileName);

            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(catalogFileContent);

            List<string> packageNames = new List<string>();

            foreach (Package package in catalog.Packages)
            {
                string currentpackageName = package.Id;

                if (!string.IsNullOrEmpty(package.Version))
                    currentpackageName += $",version={package.Version}";

                if (!string.IsNullOrEmpty(package.Chip))
                    currentpackageName += $",chip={package.Chip}";

                if (!string.IsNullOrEmpty(package.Language))
                    currentpackageName += $",language={package.Language}";

                packageNames.Add(currentpackageName);
            }
            return packageNames.ToHashSet();
        }

        internal HashSet<string> GetFolderNames(string vsOfflineDirectory)
        {
            List<string> vsFolderNames = Directory.GetDirectories(vsOfflineDirectory).Select(folderpath => new DirectoryInfo(folderpath).Name).ToList();

            return vsFolderNames.ToHashSet();
        }
    }
}
