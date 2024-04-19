namespace TodoList.Models;

public class TodoItemCreateModel
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

    public string Body
    {
        get;
        set;
    } = string.Empty;
}