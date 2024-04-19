using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Repositories;
using TodoList.Repositories.Entities;

namespace TodoList.Business;

public class TodoItemService(TodoItemRepository todoItemRepository, IMapper mapper)
{
	#region Variables

	private readonly TodoItemRepository _TodoItemRepository = todoItemRepository;
    private readonly IMapper _Mapper = mapper;

    #endregion

    #region Methods

    public async Task<IEnumerable<TodoItemModel>> AllAsync(int todoId)
    {
        var entities = _TodoItemRepository.Set().Where(d => d.TodoId == todoId).OrderBy(d => d.TodoItemId);
        var models = await _Mapper.ProjectTo<TodoItemModel>(entities).ToListAsync();
        return models;
    }

    public async Task CreateAsync(TodoItemCreateModel model)
    {
        await _TodoItemRepository.AddAsync(new TodoItem()
        {
            Title = model.Title,
            Body = model.Body,
            IsDone = false,
            TodoId = model.TodoId,
        });
        await _TodoItemRepository.SaveChangesAsync();
    }

    public async Task RemoveAsync(int todoItemId)
    {
        var entity = await _TodoItemRepository.FindAsync(todoItemId);
        if (entity != null)
            _TodoItemRepository.Remove(entity);

        await _TodoItemRepository.SaveChangesAsync();
    }

    public async Task<TodoItemCreateModel?> FindAsync(int id)
    {
        var entity = await _TodoItemRepository.FindAsync(id);
        var model = _Mapper.Map<TodoItemCreateModel>(entity);
        return model;
    }

    #endregion
}