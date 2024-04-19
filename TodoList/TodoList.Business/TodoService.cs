using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Repositories;
using TodoList.Repositories.Entities;

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
        var entities = _TodoRepository.Set().OrderBy(d => d.Title);
        var models = await _Mapper.ProjectTo<TodoModel>(entities).ToListAsync();
        return models;
    }

    public async Task CreateAsync(TodoCreateModel model)
    {
        await _TodoRepository.AddAsync(new Todo()
        {
            Title = model.Title,
        });
        await _TodoRepository.SaveChangesAsync();
    }

    public async Task RemoveAsync(int todoId)
    {
        var entity = await _TodoRepository.FindAsync(todoId);
        if (entity != null) 
            _TodoRepository.Remove(entity);

        await _TodoRepository.SaveChangesAsync();
    }

    public async Task<TodoModel?> FindAsync(int id)
	{
        var entity = await _TodoRepository.FindAsync(id);
        var model = _Mapper.Map<TodoModel>(entity);
        return model;
    } 

	#endregion
}