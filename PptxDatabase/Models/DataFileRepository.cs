using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PptxDatabase.Models {
    public class DataFileRepository {
        private readonly MyContext _context = new MyContext();

        public Datafile Find(int id) {
            return _context.Datafiles.Find(id);
        }

        public void Add(Datafile datafile) {
            _context.Datafiles.Add(datafile);
        }

        public IList<Datafile> GetAll() {
            return _context.Datafiles.ToList();
        }


        public void Save(){
            _context.SaveChanges();
        }

        public void Del(int id){
            _context.Datafiles.Remove(_context.Datafiles.Find(id));
        }
    }
}