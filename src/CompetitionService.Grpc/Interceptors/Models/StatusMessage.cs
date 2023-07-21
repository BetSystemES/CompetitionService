namespace CompetitionService.Grpc.Interceptors.Models
{
    /// <summary>
    /// Stastus message.
    /// </summary>
    public class StatusMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusMessage"/> class.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <param name="details">The details.</param>
        public StatusMessage(string reason, IEnumerable<GrpcExceptionDetail> details)
        {
            IsSuccessful = false;
            Reason = reason;
            Details = details;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is successful; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public string? Reason { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public IEnumerable<GrpcExceptionDetail> Details { get; set; }
    }
}
