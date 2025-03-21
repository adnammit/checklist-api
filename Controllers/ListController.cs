using ChecklistAPI.Data;
using ChecklistAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChecklistAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController(ILogger<ListController> logger, ChecklistDbContext dbContext, ItemRepository repo) : ControllerBase
{
    private readonly ChecklistDbContext _dbContext = dbContext;
    private readonly ItemRepository _repo = repo;
    private readonly ILogger<ListController> _logger = logger;

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<ListItem>>> GetEF()
    // {
    //     var items = await _dbContext.Item.ToListAsync();
    //     return items;
    // }

    // dummy endpoint for quick testing
    [HttpGet]
    public async Task<IEnumerable<ListItem>> GetAll()
    {
        var items = await _repo.GetAll();
        return items;
    }

    // TODO change return value to whole list entity
    [HttpGet("{id}")]
    public async Task<IEnumerable<ListItem>> GetList(int id)
    {
        var items = await _repo.GetAll();
        return items;
    }

    [HttpPost("item")]
    public async Task<ActionResult<ListItem>> CreateListItem([FromBody] ListItem item)
    {
        try
        {
            var newItem = await _repo.Create(item);
            return newItem;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error creating item");
            return BadRequest(e.Message);
        }
    }

    [HttpGet("item/{id}")]
    public async Task<ActionResult<ListItem>> GetListItem(int id)
    {
        try
        {
            var item = await _repo.GetById(id);
            return item;
        }
        catch (KeyNotFoundException e)
        {
            _logger.LogError(e, "Item not found");
            return NotFound();
        }
    }

    [HttpPut("item/{id}")]
    public async Task<ActionResult> UpdateListItem(int id, [FromBody] ListItem item)
    {
        if (id != item.Id) return BadRequest("Id mismatch"); // this seems silly? 
        var success = await _repo.Update(item);
        if (success) return Ok();
        return NotFound(); // maybe not 100% correct, but good enough for now
    }

    [HttpDelete("item/{id}")]
    public async Task<ActionResult> DeleteListItem(int id)
    {
        var success = await _repo.Delete(id);
        if (success) return Ok();
        return NotFound(); // maybe not 100% correct, but good enough for now
    }
}
