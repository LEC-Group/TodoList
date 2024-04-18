using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Business.MappingProfiles;

namespace TodoList.Business;

public static class DependencyInjectionExtension
{
    public static void AddTodoListBusinessServices(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddScoped<TodoService, TodoService>();
        services.AddScoped<TodoItemService, TodoItemService>();

        // Register AutoMapper
        services.AddAutoMapper(typeof(TodoProfile));
    }
}