using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository.IRepository
{
    public interface IUnitofWork
    {
        INationalParkRepository NationalPark { get; }

        ITrailRepository Trail { get; }

        IUserRepository User { get; }
    }
}
