using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Record
    {
        public int id { get; set; }
        public string name { get; set; }
        public string number { get; set; } 
    }
}
