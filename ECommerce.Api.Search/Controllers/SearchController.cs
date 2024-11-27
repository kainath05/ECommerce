using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    /*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Kainath Ahmed - 2268774
* Date: 		<27> <November> 2024
* Class Name: 	SearchController.cs
* Description: 	Gets a specific customerid with all their microservices like products, order and customer info. 
* Time for Task: 4 HOURS.
*/

    [ApiController]
    [Route("api/search")]
    public class SearchController :ControllerBase
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
             this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }
    }
}
