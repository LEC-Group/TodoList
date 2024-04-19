using Microsoft.AspNetCore.Mvc;
using TodoList.Business;
using TodoList.Models;

namespace TodoList.WebApp.Controllers;

public class TodoItemController(ILogger<TodoItemController> logger, TodoItemService todoItemService) : BaseController
{
    #region Variables

    private readonly ILogger<TodoItemController> _Logger = logger;

    private readonly TodoItemService _TodoItemService = todoItemService;

    #endregion

    #region Methods

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<TodoModel>>> All(int todoId)
    {
        var models = await _TodoItemService.AllAsync(todoId);
        return Ok(models);
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create(TodoItemCreateModel model)
    {
        await _TodoItemService.CreateAsync(model);
        return Ok();
    }

    [HttpDelete("Remove")]
    public async Task<ActionResult> Remove(int id)
    {
        await _TodoItemService.RemoveAsync(id);
        return Ok();
    }

    #endregion
}