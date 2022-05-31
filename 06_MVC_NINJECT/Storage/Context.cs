using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=PhonebookContext")
        {
        }

        public virtual DbSet<Record> Records { get; set; }
    }
}
