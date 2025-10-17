using HRManagementApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace HRManagementApp.Files
{
    public static class FileGuider
    {
        // Use a relative path so the app works across OSes and environments
        public static string Path = System.IO.Path.Combine("Datas", "Departments", "Departments.json");

        private static void EnsureFileExists()
        {
            var dir = System.IO.Path.GetDirectoryName(Path) ?? "";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(Path))
            {
                // create empty JSON array
                File.WriteAllText(Path, "[]", Encoding.UTF8);
            }
        }

        public static List<Department> ReadJsonFile()
        {
            EnsureFileExists();

            using FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new StreamReader(fileStream);
            string datas = streamReader.ReadToEnd();

            var departments = JsonConvert.DeserializeObject<List<Department>>(datas) ?? new List<Department>();

            // Ensure Employees lists are not null after deserialization
            foreach (var d in departments)
            {
                if (d.Employees == null)
                    d.Employees = new List<Employee>();
            }

            return departments;
        }

        public static void WriteJsonFile(List<Department> objects)
        {
            EnsureFileExists();
            using FileStream fileStream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None);
            using StreamWriter streamWriter = new StreamWriter(fileStream);
            string datas = JsonConvert.SerializeObject(objects, Formatting.Indented);
            streamWriter.Write(datas);
        }
    }
}