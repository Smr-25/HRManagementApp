using HRManagementApp.Models;
using Newtonsoft.Json;

namespace HRManagementApp.Files
{
    public static class FileGuider
    {
        public static string path = "C:\\Users\\samiraa\\Desktop\\MiniApp\\HRManagementApp\\Datas\\Departments\\Departments.json";
        //public void CreateDirectory()
        //{
        //    if (!Directory.Exists(path))
        //    {
                
        //    }
        //}
        //public void CreateFile(ref string path)
        //{
        //    if (!File.Exists(path))
        //    {
        //        path += "";
        //        File.Create(path);
        //    }

        //}
        
        public static List<Department> ReadJsonFile()
        {
            using FileStream fileStream = new FileStream(path,FileMode.Open);
            using StreamReader streamReader = new StreamReader(fileStream);
            string datas = streamReader.ReadToEnd();
            
            List<Department> departments = JsonConvert.DeserializeObject<List<Department>>(datas);
            if(departments == null)
            {
                departments = new();
            }
            return departments;
        }

        public static void WriteJsonFile(List<Department> objects)
        {
            using FileStream fileStream = new FileStream(path,FileMode.Create);
            using StreamWriter streamWriter = new StreamWriter(fileStream);
            string datas = JsonConvert.SerializeObject(objects);
            streamWriter.Write(datas);
        }
    }
}