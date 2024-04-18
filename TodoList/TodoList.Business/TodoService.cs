using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Business;

public class TodoService(TodoRepository todoRepository, IMapper mapper)
{
	#region Variables

	private readonly TodoRepository _TodoRepository = todoRepository;
    private readonly IMapper _Mapper = mapper;

    #endregion

    #region Methods

    public async Task<IEnumerable<TodoModel>> AllAsync()
    {
        var entities = _TodoRepository.Set();
        var models = await _Mapper.ProjectTo<TodoModel>(entities).ToListAsync();
        return models;
    }

    public async Task<TodoModel?> FindAsync(int id)
	{
        var entity = await _TodoRepository.FindAsync(id);
        var model = _Mapper.Map<TodoModel>(entity);
        return model;
    } 

	#endregion
}