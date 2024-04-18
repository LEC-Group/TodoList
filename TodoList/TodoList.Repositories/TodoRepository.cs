using TodoList.Repositories.Entities;

namespace TodoList.Repositories;

public class TodoRepository : BaseRepository<TodoListContext, Todo>
{
    public TodoRepository(TodoListContext context)
        : base(context)
    {
    }
}