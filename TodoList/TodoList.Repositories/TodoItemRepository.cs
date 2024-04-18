using TodoList.Repositories.Entities;

namespace TodoList.Repositories;

public class TodoItemRepository : BaseRepository<TodoListContext, TodoItem>
{
    public TodoItemRepository(TodoListContext context)
        : base(context)
    {
    }
}