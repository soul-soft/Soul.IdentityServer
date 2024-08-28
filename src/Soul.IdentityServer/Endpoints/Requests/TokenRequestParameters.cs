namespace Soul.IdentityServer.Endpoints
{
    public class TokenRequestParameters
    {
        /// <summary>
        /// 授权类型，通常为 "authorization_code" 或 "refresh_token"。
        /// </summary>
        public string? GrantType { get; set; }

        /// <summary>
        /// 从授权端点获取的授权码。
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 与授权请求中使用的重定向 URI 必须一致。
        /// </summary>
        public string? RedirectUri { get; set; }

        /// <summary>
        /// 客户端的唯一标识符。
        /// </summary>
        public string? ClientId { get; set; }

        /// <summary>
        /// 客户端密钥，用于机密客户端。
        /// </summary>
        public string? ClientSecret { get; set; }

        /// <summary>
        /// 请求的权限范围。
        /// </summary>
        public string[] Scope { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 用于获取新访问令牌的刷新令牌。
        /// </summary>
        public string? RefreshToken { get; set; }
    }

}
