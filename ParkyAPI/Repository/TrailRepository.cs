using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _db;

        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateTrail(Trail trail)
        {
            _db.Trail.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _db.Trail.Remove(trail);
            return Save();
        }

        public ICollection<Trail> GetTrails()
        {
            return _db.Trail.Include(c => c.NationalPark).OrderBy(a => a.Name).ToList();
        }

        public Trail GetTrail(int trailId)
        {
            return _db.Trail.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == trailId);
        }

        public bool TrailExists(string name)
        {
            bool value = _db.Trail.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            return _db.Trail.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Trail.Update(trail);
            return Save();
        }

       
        public ICollection<Trail> GetTrailsInNationalPark(int npId)
        {
            return _db.Trail.Include(c=>c.NationalPark).Where(c=>c.NationalParkId==npId).ToList();
        }
    }
}
