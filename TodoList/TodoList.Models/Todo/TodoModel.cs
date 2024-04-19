namespace TodoList.Models;

public class TodoModel
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

    public int ItemsCount
    {
        get;
        set;
    }
}