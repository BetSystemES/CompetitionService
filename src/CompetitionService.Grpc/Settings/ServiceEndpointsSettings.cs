namespace CompetitionService.Grpc.Settings
{
    /// <summary>
    /// Service endpoints
    /// </summary>
    public class ServiceEndpointsSettings
    {
        public List<ServiceEndpoint> ServiceEndpoints { get; set; }
    }

    /// <summary>
    /// Service endpoint model.
    /// </summary>
    public class ServiceEndpoint
    {
        public string? Name { get; set; }

        public string? Url { get; set; }

        public string? HealthCheckUrl { get; set; }
    }
}
