using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Repositories.Entities;

namespace TodoList.Repositories;

public static class DependencyInjectionExtension
{
    public static void AddQMSRepositoriesServices(this IServiceCollection services, IConfigurationRoot configuration, string connectionStringName = "DefaultConnection")
    {
        var connectionString = configuration.GetConnectionString(connectionStringName);

        services.AddDbContext<TodoListContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

        services.AddScoped<TodoRepository, TodoRepository>();
        services.AddScoped<TodoItemRepository, TodoItemRepository>();
    }
}