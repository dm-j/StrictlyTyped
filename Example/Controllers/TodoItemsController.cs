using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example.Models;
using TodoApi.Models;
using static Example.TodoItems;
using Example.Infrastructure;
using Example.Dtos;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            if (_context.TodoItems is null)
            {
                return NotFound();
            }
            
            return (await _context.TodoItems.ToListAsync()).AsDto<TodoItemDto, TodoItem>();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(Id id)
        {
            if (_context.TodoItems is null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            return todoItem.AsDto<TodoItemDto, TodoItem>();
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Id id, TodoItemDto todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            var update = await _context.FindAsync<TodoItem>(id);
            
            if (update is null)
            {
                return NotFound();
            }
            
            update.UpdateFrom(todoItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_todoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(TodoItemDto todoItem)
        {
            var value = todoItem.AsValue();
            _context.TodoItems.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = value.Id }, value.AsDto<TodoItemDto, TodoItem>());
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Id id)
        {
            if (_context.TodoItems is null)
            {
                return NotFound();
            }
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool _todoItemExists(Id id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
