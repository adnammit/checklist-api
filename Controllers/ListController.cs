using System.Collections;
using ChecklistAPI.Data;
using ChecklistAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChecklistAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController(ILogger<ListController> logger, ChecklistDbContext dbContext) : ControllerBase
{
    private readonly ChecklistDbContext _dbContext = dbContext;
    private readonly ILogger<ListController> _logger = logger;

    private static readonly ListItem[] ListItems =
    [
        new ListItem {
            Name = "Tofu",
            Notes = "Extra Firm",
            Category = "Deli",
            Completed = false
        },
        new ListItem {
            Name = "Tomato",
            Quantity = 2,
            Category = "Produce",
            Completed = false
        },
        new ListItem {
            Name = "Bread",
            Notes = "Sourdough",
            Category = "Bakery",
            Completed = true
        },
        new ListItem {
            Name = "Beer",
            Category = "Beverage",
            Completed = false
        },
        new ListItem {
            Name = "Milk",
            Category = "Dairy",
            Completed = true
        },
        new ListItem {
            Name = "Chips",
            Notes = "Don't get the healthy kind, they taste like cardboard",
            Category = "Snacks",
            Completed = false
        },
        new ListItem {
            Name = "Eggs",
            Quantity = 12,
            Notes = "we're rich, bish!!",
            Category = "Dairy",
            Completed = true
        },
    ];

    // for a given list id, get all items for that list
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(ListItems);
        // var user = await _userRepository.GetByIdAsync(id);
        // return user == null ? NotFound() : Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ListItem>>> Get()
    {
        var items = await _dbContext.Item.ToListAsync();
        return items;
    }
}
