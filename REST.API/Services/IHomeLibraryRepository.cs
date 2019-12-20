using System.Collections.Generic;
using System.Threading.Tasks;
using REST.API.Helpers;
using REST.API.ResourceParameters;
using REST.Domain.Entities;
using REST.Domain.Services;

namespace REST.API.Services
{
    public interface IHomeLibraryRepository : IAppRepository<CareHome>
    {
        PagedList<CareHome> GetHomes(HomeResourceParameters homesResourceParameters);
    }
}