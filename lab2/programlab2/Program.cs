using System.IO;
using System.Text.Json;

public class Typeofworks
{
    public int Order_number { get; private set; }
    public int Job_line_number { get; private set; }
    public string Value { get; private set; }

    public int Job_id { get; private set; }

    public Workcatalog workcatalog { get; private set; }

    public Typeofworks() { }

    public Typeofworks(int Order_number, int Job_line_number, string Value, int Job_id, Workcatalog workcatalog)
    {
        this.Order_number = Order_number;
        this.Job_line_number = Job_line_number;
        this.Value = Value;
        this.Job_id = Job_id;
        this.workcatalog = workcatalog;
    }
}

public class Workcatalog
{
    public int Job_id { get; private set; }
    public string Name { get; private set; }
    public int price { get; private set; }

    public Workcatalog() { }

    public Workcatalog(int Job_id, string Name, int price)
    {
        this.Job_id = Job_id;
        this.Name = Name;
        this.price = price;
    }
}



public class JsonHandler<T> where T : class
{
    private string fileName;
    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };


    public JsonHandler() { }

    public JsonHandler(string fileName)
    {
        this.fileName = fileName;
    }


    public void SetFileName(string fileName)
    {
        this.fileName = fileName;
    }

    public void Write(List<T> list)
    {
        string jsonString = JsonSerializer.Serialize(list, options);

        if (new FileInfo(fileName).Length == 0)
        {
            File.WriteAllText(fileName, jsonString);
        }
        else
        {
            Console.WriteLine("Specified path file is not empty");
        }
    }

    public void Delete()
    {
        File.WriteAllText(fileName, string.Empty);
    }

    public void Rewrite(List<T> list)
    {
        string jsonString = JsonSerializer.Serialize(list, options);

        File.WriteAllText(fileName, jsonString);
    }

    public void Read(ref List<T> list)
    {
        if (File.Exists(fileName))
        {
            if (new FileInfo(fileName).Length != 0)
            {
                string jsonString = File.ReadAllText(fileName);
                list = JsonSerializer.Deserialize<List<T>>(jsonString);
            }
            else
            {
                Console.WriteLine("Specified path file is empty");
            }
        }
    }

    public void OutputJsonContents()
    {
        string jsonString = File.ReadAllText(fileName);

        Console.WriteLine(jsonString);
    }

    public void OutputSerializedList(List<T> list)
    {
        Console.WriteLine(JsonSerializer.Serialize(list, options));
    }
}



class Program
{
    static void Main(string[] args)
    {
        List<Typeofworks> partsList = new List<Typeofworks>();

        JsonHandler<Typeofworks> partsHandler = new JsonHandler<Typeofworks>("partsFile.json");

        partsList.Add(new Typeofworks(1, 1, " ", 1, new Workcatalog(1, "Alignment walls", 1000)));
        partsList.Add(new Typeofworks(1, 2, " ", 2, new Workcatalog(2, "Wallpaper Pasting", 650)));
        partsList.Add(new Typeofworks(2, 1, "Square meters", 3, new Workcatalog(3, "Laying tiles", 2000)));
        partsList.Add(new Typeofworks(2, 2, "Meters", 4, new Workcatalog(4, "Communication plumbing", 400)));
        partsHandler.Rewrite(partsList);
        partsHandler.OutputJsonContents();
    }
}