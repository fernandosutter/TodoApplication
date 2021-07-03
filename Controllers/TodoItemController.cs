using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplicationWebApi.Models;

namespace TodoApplicationWebApi.Controllers
{
    [Route("todoItems")]
    [ApiController]
    public class TodoItemController : Controller
    {
        private readonly TodoItemContext _context;

        public TodoItemController(TodoItemContext context)
        {
            _context = context;
        }

        //GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAllTasksAsync()
        {
            var todoItems = await _context.TodoItems.ToListAsync();

            if (todoItems == null)
            {
                return NotFound();
            }

            return Ok(todoItems);
        }
        //GET ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTaskByIdAsync(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<TodoItem>> InsertTaskAsync(TodoItem todoItem)
        {
            todoItem.CreatedAt = DateTime.Now;
            todoItem.LastUpdatedAt = DateTime.Now;
            todoItem.IsComplete = false;

            _context.TodoItems.Add(todoItem);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskById", new { id = todoItem.Id }, todoItem);
        }

        //PUT
        [HttpPut]
        public async Task<ActionResult> UpdateTaskAsync(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            todoItem.LastUpdatedAt = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (_context.TodoItems.Find(id) == null)
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

        //DELETE
        [HttpDelete]
        public async Task<ActionResult> DeleteTaskById(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            
            if (todoItem  == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
