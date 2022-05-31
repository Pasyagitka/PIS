using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MVCApplication.Models
{
    public class Phonebook
    {
        private List<Record> data = new List<Record>();
        private static string _jsonFile = @"D:\6 semester\Laboratory\PIS\MVCApplication\MVCApplication\App_Data\Phonebook.json";

        public List<Record> GetAll()
        {
            return JsonConvert.DeserializeObject<List<Record>>(File.ReadAllText(_jsonFile));
        }

        public List<Record> GetAllOrdered()
        {
            return GetAll().OrderBy(x => x.name).ToList();
        }

        public Record Get(int id)
        {
            return GetAll().Where(x => x.id == id).First();
        }

        public void Insert(string name, string number)
        {
            data = GetAll();
            data.Add(new Record { id = data.Last().id + 1, name = name, number = number });
            SaveChanges(data);
        }

        public void Update(int id, string name, string number)
        {
            data = GetAll();
            int i = data.FindIndex(x => x.id == id);
            data[i].name = name;
            data[i].number = number;
            SaveChanges(data);
        }

        public void Delete(int id)
        {
            data = GetAll();
            data.RemoveAt(data.FindIndex(x => x.id == id));
            SaveChanges(data);
        }

        private void SaveChanges(List<Record> inTelephones)
        {
            File.WriteAllText(_jsonFile, JsonConvert.SerializeObject(inTelephones));
        }
    }
}