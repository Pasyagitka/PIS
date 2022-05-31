using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class PhonebookStorageEF : DbContext, IElementsDictionary<Record>
    {
        Context _context = new Context();

        public List<Record> GetAll()
        {
            return _context.Records.ToList();
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
            int id = GetAll().LastOrDefault().id;
            _context.Records.Add(new Record { id = id + 1, name = name, number = number });
            _context.SaveChanges();
        }

        public void Update(int id, string name, string number)
        {
            int i = GetAll().FindIndex(x => x.id == id);
            GetAll().ElementAt(i).name = name;
            GetAll().ElementAt(i).number = number;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Records.Remove(GetAll().First(x => x.id == id));
            _context.SaveChanges();
        }
    }
}
