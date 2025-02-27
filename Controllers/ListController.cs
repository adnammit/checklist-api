using System.Collections;
using ChecklistAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ChecklistAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController(ILogger<ListController> logger) : ControllerBase
{
    // private readonly IRepository<User> _userRepository;

    // TODO replace with repo pattern
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

    private readonly ILogger<ListController> _logger = logger;

    // for a given list id, get all items for that list
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(ListItems);
        // var user = await _userRepository.GetByIdAsync(id);
        // return user == null ? NotFound() : Ok(user);
    }
}
