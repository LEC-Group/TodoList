namespace TodoList.Models;

public class TodoItemModel
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
}