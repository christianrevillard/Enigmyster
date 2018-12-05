using Enigmyster.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Enigmyster.Models.DataManager
{
    public class RiddleManager: IDataRepository<Riddle, long>
    {
        DatabaseContext _context;

        public RiddleManager(DatabaseContext context)
        {
            _context = context;
        }

        public Riddle Get(long id)
        {
            return _context.Riddle.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Riddle> GetAll()
        {
            return _context.Riddle.ToList();
        }

        public long Add(Riddle riddle)
        {
            _context.Riddle.Add(riddle);
            long id = _context.SaveChanges();
            return id;
        }

        public long Delete(long id)
        {
            int deletedId = 0;
            var riddle = _context.Riddle.FirstOrDefault(b => b.Id == id);
            if (riddle != null)
            {
                _context.Riddle.Remove(riddle);
                deletedId = _context.SaveChanges();
            }
            return deletedId;
        }

        public long Update(long id, Riddle item)
        {
            long updatedId = 0;
            var riddle = _context.Riddle.Find(id);
            if (riddle != null)
            {
                riddle.Text = item.Text;
                riddle.Title = item.Title;
                riddle.Solution = item.Solution;
                updatedId = _context.SaveChanges();
            }
            return updatedId;
        }
    }
}
