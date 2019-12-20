using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST.API.DTOs;
using REST.API.Helpers;
using REST.API.ResourceParameters;
using REST.API.Services;

namespace REST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareHomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHomeLibraryRepository _homeLibraryRepository;

        public CareHomeController(IMapper mapper, IHomeLibraryRepository homeLibraryRepository)
        {
            _mapper = mapper;
            _homeLibraryRepository = homeLibraryRepository;
        }

        // GET api/values
        [HttpGet(Name = "GetCareHomes")]
        [HttpHead]
        public ActionResult<IEnumerable<CareHomeDto>> GetCarehomes([FromQuery] HomeResourceParameters homeResourceParameters)
        {
            var careHomes = _homeLibraryRepository.GetHomes(homeResourceParameters);

            var previousPageLink = careHomes.HasPrevious ?
                CreateHomeResourceUri(homeResourceParameters, ResourceUriType.NextPage) : null;

            var nextPageLink = careHomes.HasNext ? 
                CreateHomeResourceUri(homeResourceParameters, ResourceUriType.NextPage) : null;

            var paginationMetadata = new 
            {
                totalCount = careHomes.TotalCount,
                pageSize = careHomes.PageSize,
                currentPage = careHomes.CurrentPage,
                totalPages = careHomes.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject( paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CareHomeDto>>(careHomes));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<CareHomeDto>(_homeLibraryRepository.GetEntityById(id)));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string CreateHomeResourceUri(
           HomeResourceParameters homeResourceParameters,
           ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetCareHomes", 
                        new {
                            pageNumber = homeResourceParameters.PageNumber - 1,
                            pageSize = homeResourceParameters.PageSize,
                            rating = homeResourceParameters.Rating,
                            searchQuery = homeResourceParameters.SearchQuery
                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetCareHomes", 
                        new {
                            pageNumber = homeResourceParameters.PageNumber + 1,
                            pageSize = homeResourceParameters.PageSize,
                            rating = homeResourceParameters.Rating,
                            searchQuery = homeResourceParameters.SearchQuery
                        });
                default:
                    return Url.Link("GetCareHomes", 
                        new {
                            pageNumber = homeResourceParameters.PageNumber,
                            pageSize = homeResourceParameters.PageSize,
                            rating = homeResourceParameters.Rating,
                            searchQuery = homeResourceParameters.SearchQuery
                        });
            }
        }
    }
}
