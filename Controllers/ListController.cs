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

    [HttpGet]
    public async Task<IEnumerable<ListItem>> Get()
    {
        var items = await _repo.GetAllAsync();
        return items;
    }

    [HttpGet("item/{id}")]
    public async Task<ListItem> GetById(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item;
    }
}
