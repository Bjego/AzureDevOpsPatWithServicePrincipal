

// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace AzureDevOpsPatGenerator;

public class Program
{
    static async Task Main(string[] args)
    {
        var Configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .Build();
        const string azureDevOpsAppScope = "499b84ac-1321-427f-aa17-267ca6975798/.default";
        var azureDevOpsOptions = Configuration.GetSection(nameof(AzureDevOps)).Get<AzureDevOps>() ?? throw new ArgumentException($"{nameof(AzureDevOps)} not configured correctly");


        var credentials = new ClientSecretCredential(azureDevOpsOptions.TenantId, azureDevOpsOptions.ClientId, azureDevOpsOptions.ClientSecret);
        var accessToken = await credentials.GetTokenAsync(new Azure.Core.TokenRequestContext(new[] { azureDevOpsAppScope }));
        Console.WriteLine(accessToken.Token);
    }
}