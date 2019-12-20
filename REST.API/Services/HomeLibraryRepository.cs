using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REST.API.Helpers;
using REST.API.ResourceParameters;
using REST.Domain.Entities;
using REST.Infrastructure.Persistence;

namespace REST.API.Services
{
    public class HomeLibraryRepository : IHomeLibraryRepository
    {
        private readonly CareHomeDbContext _context;

        public HomeLibraryRepository(CareHomeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(CareHome entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EntityExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CareHome>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public CareHome GetEntityById(int id)
        {
            return  _context.Homes.SingleOrDefault(x => x.Id == id);
        }

        public PagedList<CareHome> GetHomes(HomeResourceParameters homesResourceParameters)
        {
            if (homesResourceParameters == null) 
            {
                throw new ArgumentNullException(nameof(homesResourceParameters));
            }

            var collection = _context.Homes as IQueryable<CareHome>;

            if (homesResourceParameters.Rating != 0)
            {
                var rating = homesResourceParameters.Rating;
                collection = collection.Where(h => h.Rating == rating);
            }

            if (!string.IsNullOrWhiteSpace(homesResourceParameters.SearchQuery))
            {
                var searchQuery = homesResourceParameters.SearchQuery.Trim();
                collection = collection.Where(h => h.Name.Contains(searchQuery) 
                    || h.Address.Contains(searchQuery)
                    || h.City.Contains(searchQuery));
            }

            return PagedList<CareHome>.Create(collection, 
                homesResourceParameters.PageNumber,
                homesResourceParameters.PageSize);    
        }

        public void Remove(CareHome entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}