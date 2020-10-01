using System;
using System.IO;
using System.Reflection;

namespace ConfigureEFDbContext.MSUnitTest
{
    public static class Helper
    {
        public static string GetParentProjectPath()
        {
            var parentProjectName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var parentProjectFullName = $"{parentProjectName}.csproj";
            var applicationBasePath = Directory.GetCurrentDirectory();
            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directoryInfo != null)
            {
                var projectDirectoryInfo = new DirectoryInfo(directoryInfo.FullName);
                var parentProjectPath = Path.Combine(projectDirectoryInfo.FullName, parentProjectName, parentProjectFullName);
                if (projectDirectoryInfo.Exists && new FileInfo(parentProjectPath).Exists)
                {
                    return Path.Combine(projectDirectoryInfo.FullName, parentProjectName);
                }
                directoryInfo = directoryInfo.Parent;
            }

            throw new Exception($"Th parent project {parentProjectName} could not be located using the current application root {applicationBasePath}.");
        }
    }
}
