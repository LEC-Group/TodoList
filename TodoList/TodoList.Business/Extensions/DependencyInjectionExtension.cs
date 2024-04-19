using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Business.MappingProfiles;
using TodoList.Repositories;

namespace TodoList.Business;

public static class DependencyInjectionExtension
{
    public static void AddTodoListBusinessServices(this IServiceCollection services, IConfigurationRoot configuration, string connectionStringName = "DefaultConnection")
    {
        services.AddScoped<TodoService, TodoService>();
        services.AddScoped<TodoItemService, TodoItemService>();

        // Register AutoMapper
        services.AddAutoMapper(typeof(TodoProfile));

        // Add Repositories Services
        services.AddTodoListRepositoriesServices(configuration, connectionStringName);
    }
}