namespace Soul.IdentityServer.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public string Error { get; }
        public string ErrorDescription { get; }
        public string ErrorUri { get; }

        public InvalidRequestException(string error, string errorDescription = null, string errorUri = null)
            : base(errorDescription)
        {
            Error = error;
            ErrorDescription = errorDescription;
            ErrorUri = errorUri;
        }
    }
}
