namespace HRManagementApplication.FileHelper;

public static class FileGuider
{

    public static string path = null;
    public static List<Department> ReadJsonFile()
    {
        using FileStream fileStream = new FileStream(path, FileMode.Open);
        using StreamReader streamReader = new StreamReader(fileStream);
        string datas = streamReader.ReadToEnd();

        // List<Department> departments = JsonConvert.DeserializeObject<List<Department>>(datas);
        // if (departments == null)
        // {
        //     departments = new();
        // }
        var departments = new List<Department>();
        return departments;
    }

    public static void WriteJsonFile(List<Department> objects)
    {
        using FileStream fileStream = new FileStream(path, FileMode.Create);
        using StreamWriter streamWriter = new StreamWriter(fileStream);
        // string datas = JsonConvert.SerializeObject(objects);
        var datas = "null";
        streamWriter.Write(datas);
    }
}
