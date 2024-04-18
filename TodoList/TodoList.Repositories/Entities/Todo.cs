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

    public virtual ICollection<TodoItem> Items
    { 
        get;
        set;
    } = [];
}