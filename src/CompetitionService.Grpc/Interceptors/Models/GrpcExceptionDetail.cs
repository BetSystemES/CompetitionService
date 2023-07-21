namespace CompetitionService.Grpc.Interceptors.Models
{
    /// <summary>
    /// Grpc exeption detail.
    /// </summary>
    public class GrpcExceptionDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GrpcExceptionDetail"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="message">The message.</param>
        public GrpcExceptionDetail(string field, string message)
        {
            Field = field;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GrpcExceptionDetail"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public GrpcExceptionDetail(string message)
        {
            Field = null;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public string? Field { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
