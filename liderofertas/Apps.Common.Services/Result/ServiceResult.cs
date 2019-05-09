using System;
namespace Apps.Common.Services.Result
{
    /// <summary>
    /// Service result.
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Apps.Common.Services.Result.ServiceResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public object Response { get; set; }

        /// <summary>
        /// Gets or sets the token response.
        /// </summary>
        /// <value>The token response.</value>
        public string TokenResponse { get; set; }
    }
}
