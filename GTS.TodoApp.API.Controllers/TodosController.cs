using GTS.TodoApp.API.Controllers._Common;
using GTS.TodoApp.Core.Application.Abstraction.Services;
using GTS.TodoApp.Core.Application.Specifications;
using GTS.TodoApp.Shared.DTOs;
using GTS.TodoApp.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GTS.TodoApp.API.Controllers
{
    public class TodosController(IServiceManager _serviceManager) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<TodoDTO>>>> GetAllWithSpecs([FromQuery]SpecParams specParams)
        {
            var todos = await _serviceManager.TodoService.GetAllWithSpecsAsync(specParams);

            return Ok(todos);
        }

        [HttpGet("todo/{id}")]
        public async Task<ActionResult<Result<TodoDTO>>> GetTodoById(Guid id)
        {
            var result = await _serviceManager.TodoService.GetTodoByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<TodoDTO>>> CreateNewTodo(TodoDTO todoDTO)
        {
            var result = await _serviceManager.TodoService.CreateTodoAsync(todoDTO);

            return Ok(result);

        }


        [HttpPost("completedTodo/{id}")]
        public async Task<ActionResult<Result<string>>> MarkAsCompleted(Guid id)
        {
            var result = await _serviceManager.TodoService.MarkAsCompleted(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<TodoDTO>>> UpdateTodo(TodoDTO todoDTO)
        {
            var result = await _serviceManager.TodoService.UpdateTodo(todoDTO);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Result<bool>>> DeleteTodo(TodoDTO todoDTO)
        {
            var result =await _serviceManager.TodoService.DeleteTodo(todoDTO);

           return Ok(result);
        }
    }
}