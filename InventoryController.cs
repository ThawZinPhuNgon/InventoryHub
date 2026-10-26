using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private static List<InventoryItem> items = new List<InventoryItem>
        {
            new InventoryItem { Id = 1, Name = "Laptop", Quantity = 15, Price = 1200.00m },
            new InventoryItem { Id = 2, Name = "Wireless Mouse", Quantity = 50, Price = 25.50m }
        };

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(items);
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] InventoryItem newItem)
        {
            if (newItem == null) return BadRequest("Invalid item data.");
            newItem.Id = items.Count + 1;
            items.Add(newItem);
            return CreatedAtAction(nameof(GetItems), new { id = newItem.Id }, newItem);
        }
    }

    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
