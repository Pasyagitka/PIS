using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IElementsDictionary<Record>
    {
        List<Record> GetAll();
        List<Record> GetAllOrdered();
        Record Get(int id);


        void Insert(string name, string number);
        void Update(int id, string name, string number);
        void Delete(int id);
    }
}
