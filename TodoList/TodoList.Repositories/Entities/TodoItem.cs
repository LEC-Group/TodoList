namespace TodoList.Repositories.Entities;

public partial class TodoItem
{
    public int TodoItemId 
    { 
        get; 
        set; 
    }

    public string Title
    {
        get;
        set;
    } = string.Empty;

    public string Body
    {
        get;
        set;
    } = string.Empty;

    public bool IsDone
    {
        get;
        set;
    }

    public virtual Todo Todo
    {
        get;
        set;
    } = null!;
}