using Microsoft.AspNetCore.Mvc;
using TodoList.Business;
using TodoList.Models;

namespace TodoList.WebApp.Controllers;

public class TodoController(ILogger<TodoController> logger, TodoService todoService) : BaseController
{
    #region Variables

    private readonly ILogger<TodoController> _Logger = logger;

    private readonly TodoService _TodoService = todoService;

    #endregion

    #region Methods

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<TodoModel>>> All()
    {
        var models = await _TodoService.AllAsync();
        return Ok(models);
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create(TodoCreateModel model)
    {
        await _TodoService.CreateAsync(model);
        return Ok();
    }

    [HttpDelete("Remove")]
    public async Task<ActionResult> Remove(int todoId)
    {
        await _TodoService.RemoveAsync(todoId);
        return Ok();
    }

    #endregion
}