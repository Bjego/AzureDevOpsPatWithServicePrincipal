namespace AzureDevOpsPatGenerator
{
    public class AzureDevOps
    {
        public Uri Url { get; set; } = new Uri("about:blank");
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string TenantId { get; set; } = string.Empty;
    }
}