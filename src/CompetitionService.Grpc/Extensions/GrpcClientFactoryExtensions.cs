using Grpc.Net.ClientFactory;

namespace CompetitionService.Grpc.Extensions;

/// <summary>
/// Extenions for <seealso cref="GrpcClientFactory"/>
/// </summary>
public static class GrpcClientFactoryExtensions
{
    /// <summary>
    /// Gets the specific GRPC client.
    /// </summary>
    /// <typeparam name="T">Grpc client type.</typeparam>
    /// <param name="grpcClientFactory">The GRPC client factory.</param>
    /// <returns>Instance of grpc client. </returns>
    public static T GetGrpcClient<T>(this GrpcClientFactory grpcClientFactory) where T : class
    {
        return grpcClientFactory.CreateClient<T>(typeof(T).Name);
    }
}
