﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TodoList.Api.Models;
using TodoList.Api.ServiceInterfaces;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(ITodoItemService todoItemService, ILogger<TodoItemsController> logger)
        {
            _todoItemService = todoItemService;
            _logger = logger;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var results = await _todoItemService.GetTodoItemList();

            return Ok(results);
        }

        // GET: api/TodoItems/...
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            var result = await _todoItemService.GetTodoItemByID(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/TodoItems/... 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            var response = await _todoItemService.UpdateTodoItem(todoItem);

            if (!response.Success)
                return NotFound(response.Message);

            return NoContent();
        }

        // POST: api/TodoItems 
        [HttpPost]
        public async Task<IActionResult> PostTodoItem(TodoItem todoItem)
        {
            var response = await _todoItemService.InsertTodoItem(todoItem);

            if (!response.Success)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        } 
    }
}
