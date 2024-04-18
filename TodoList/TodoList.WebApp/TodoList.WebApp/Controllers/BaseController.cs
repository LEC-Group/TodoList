using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    #region Constructor

    public BaseController()
    {
    }

    #endregion
}