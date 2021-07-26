using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly TaskContext _context;

        public TaskItemsController(TaskContext context)
        {
            _context = context;
        }

        // GET: /TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: /TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(int id)
        {
            var taskItem = await _context.TodoItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // PUT: /TaskItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, TaskItem taskItem)
        {
            if (id != taskItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(taskItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(id))
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

        // POST: /TaskItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
        {
            _context.TodoItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskItem", new { id = taskItem.ID }, taskItem);
        }

        // DELETE: /TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var taskItem = await _context.TodoItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.ID == id);
        }
    }
}
