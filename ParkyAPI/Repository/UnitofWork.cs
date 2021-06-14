using Microsoft.Extensions.Options;
using ParkyAPI.Data;
using ParkyAPI.Repository.IRepository;
using ParkyAPI.Utility;
using System;


namespace ParkyAPI.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IOptions<AppSettings> _appsettings;

        public UnitofWork(ApplicationDbContext db, IOptions<AppSettings> appsettings) 
        {
            _db = db;
            _appsettings = appsettings;
            NationalPark = new NationalParkRepository(_db);
            Trail = new TrailRepository(_db);
            User = new UserRepository(_db,_appsettings);

        }
        

        public INationalParkRepository NationalPark { get; private set; }

        public ITrailRepository Trail { get; private set; }

        public IUserRepository User { get; private set; }
    }
}
