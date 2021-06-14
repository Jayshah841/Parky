using ParkyWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkyWeb.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly IHttpClientFactory _clientFactory;

        public UnitofWork(IHttpClientFactory clientFactory) 
        {
            _clientFactory = clientFactory;
            Trail = new TrailRepository(_clientFactory);
            User = new UserRepository(_clientFactory);
        }
        

        public INationalParkRepository NationalPark => new NationalParkRepository(_clientFactory);

        public ITrailRepository Trail { get; private set; }

        public IUserRepository User { get; private set; }


    }
}
