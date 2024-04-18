using Microsoft.AspNetCore.Components;

namespace TodoList.WebApp.Client.Services;

public class HttpService
{
    public HttpService(HttpClient httpClient, NavigationManager navigationManager)
    {
        if (httpClient.BaseAddress == null)
            httpClient.BaseAddress = new Uri(navigationManager.BaseUri);

        HttpClient = httpClient;
    }

    public HttpClient HttpClient
    {
        get;
        private set;
    }
}