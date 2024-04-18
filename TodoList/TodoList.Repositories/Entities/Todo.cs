namespace TodoList.Repositories.Entities;

public partial class Todo
{
    public int TodoId 
    { 
        get;
        set; 
    }

    public string Title
    {
        get; 
        set; 
    } = string.Empty;

    public ICollection<TodoItem> Items
    { 
        get;
        set;
    } = [];
}