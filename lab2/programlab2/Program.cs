using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Serialization
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Scnd_name { get; set; }
        public long Phone { get; set; }
        public Call ID_ivr { get; set; }
        public Client() { }
        public Client(int id, string name, string scnd_name, long phone, Call id_ivr)
        {
            Id = id;
            Name = name;
            Scnd_name = scnd_name;
            Phone = phone;
            ID_ivr = id_ivr;
        }



        public class Call
        {   
            public int ID_ivr { get; set; }        
            public int Credit_limit { get; set; }
            public int Current_credit { get; set; }
            public Call() { }
            public Call(int id_ivr, int credit_limit, int current_credit)
            {
                ID_ivr = id_ivr;
                Credit_limit = credit_limit;
                Current_credit = current_credit;
            
            }

        }
    }

    public class JsonHandler<T> where T : class
    {
        private string NameFile;
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };


        public JsonHandler() { }

        public JsonHandler(string NameFile)
        {
            this.NameFile = NameFile;
        }


        public void SetFileName(string NameFile)
        {
            this.NameFile = NameFile;
        }

        public void Write(List<T> list)
        {
            string jsonString = JsonSerializer.Serialize(list, options);

            if (new FileInfo(NameFile).Length == 0)
            {
                File.WriteAllText(NameFile, jsonString);
            }
            else
            {
                Console.WriteLine("Указанный путь к файлу не пустой");
            }
        }

        public void Delete()
        {
            File.WriteAllText(NameFile, string.Empty);
        }

        public void Rewrite(List<T> list)
        {
            string jsonString = JsonSerializer.Serialize(list, options);

            File.WriteAllText(NameFile, jsonString);
        }

        public void Read(ref List<T> list)
        {
            if (File.Exists(NameFile))
            {
                if (new FileInfo(NameFile).Length != 0)
                {
                    string jsonString = File.ReadAllText(NameFile);
                    list = JsonSerializer.Deserialize<List<T>>(jsonString);
                }
                else
                {
                    Console.WriteLine("Указанный путь к файлу не пустой");
                }
            }
        }

        public void OutputJsonContents()
        {
            string jsonString = File.ReadAllText(NameFile);

            Console.WriteLine(jsonString);
        }

        public void OutputSerializedList(List<T> list)
        {
            Console.WriteLine(JsonSerializer.Serialize(list, options));
        }
    }

   public class Program
    {
        static void Main(string[] args)
        {
            List<Client> partsList = new List<Client>();

            JsonHandler<Client> partsHandler = new JsonHandler<Client>("FileClient.json");

            partsList.Add(new Client(100, "Kiril", "Bolshoy", 89103834323, new Client.Call(15, 123123123, 15151515)));
            partsList.Add(new Client(100, "Kiril", "Bolshoy", 89103834323, new Client.Call(15, 123123123, 15151515)));
            partsList.Add(new Client(100, "Kiril", "Bolshoy", 89103834323, new Client.Call(15, 123123123, 15151515)));
            partsList.Add(new Client(100, "Kiril", "Bolshoy", 89103834323, new Client.Call(15, 123123123, 15151515)));
            partsList.Add(new Client(100, "Kiril", "Bolshoy", 89103834323, new Client.Call(15, 123123123, 15151515)));

            partsHandler.Rewrite(partsList);
            partsHandler.OutputJsonContents();
        }
    }
}