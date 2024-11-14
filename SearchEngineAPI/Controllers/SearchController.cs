using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchEngineAPI.Models;


[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly SearchEngineContext _context;

    public SearchController(SearchEngineContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SearchItem>>> GetSearchResults(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("Query parameter is required.");

        var results = await _context.SearchItems
            .Where(item => item.Title.Contains(query) || item.Content.Contains(query))
            .ToListAsync();

        return Ok(results);
    }
}
