using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
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