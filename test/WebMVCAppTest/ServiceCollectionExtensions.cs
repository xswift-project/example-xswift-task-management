﻿using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

namespace WebMVCAppTest
{
    public static class ServiceCollectionExtensions
    {
        public static void HttpClientService(
            this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            services.AddTransient<AuthenticationDelegatingHandler>();

            //--

            services.AddHttpClient(HttpClientNames.WebMVCAppClient, client =>
            {
                var uri = configuration.GetSection("HttpClientsUri")
                .GetSection(HttpClientNames.WebMVCAppClient).Value!;

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            //--

            services.AddHttpClient(HttpClientNames.SecurityTokenServiceClient, client =>
            {
                var uri = configuration.GetSection("HttpClientsUri")
                .GetSection(HttpClientNames.SecurityTokenServiceClient).Value!;
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            //--

            services.AddHttpContextAccessor();
        }
    }
}