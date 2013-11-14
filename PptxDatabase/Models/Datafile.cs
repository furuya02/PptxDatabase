using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PptxDatabase.Models {
    public class Datafile {
        public int Id { get; set; }

        public string Filename { get; set; }

        public int Size { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}