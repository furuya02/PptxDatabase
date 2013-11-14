using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PptxDatabase.Models {
    public class MyContext : DbContext{
        public DbSet<Datafile> Datafiles { get; set; }
    }
}