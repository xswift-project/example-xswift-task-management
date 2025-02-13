﻿using Microsoft.Net.Http.Headers;

namespace Module.Presentation.WebMVCApp
{
    public static class ServiceCollectionExtensions
    {
        public static void HttpClientService(
            this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            services.AddHttpClient(HttpClientNames.WebAPIClient, client =>
            {
                var uri = configuration.GetSection("HttpClientsUri")
                .GetSection(HttpClientNames.WebAPIClient).Value!;

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });
        }
    }
}
